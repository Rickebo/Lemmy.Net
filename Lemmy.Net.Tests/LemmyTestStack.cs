using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using DotNet.Testcontainers.Networks;
using Testcontainers.PostgreSql;

namespace Lemmy.Net.Tests;

public sealed class LemmyTestStack
{
    private const string AdminName = "lemmy_admin";
    private const string AdminPassword = "integration-test-password";
    private const string PictrsApiKey = "integration-test-pictrs-key";
    private INetwork? _network;
    private PostgreSqlContainer? _postgres;
    private IContainer? _pictrs;
    private IContainer? _lemmy;
    private string? _configDirectory;

    public string BaseUrl { get; private set; } = null!;
    public LemmyHttp AdminClient { get; private set; } = null!;
    public LemmyHttp CreateClient() => new(BaseUrl);

    public async Task Start()
    {
        _configDirectory = Path.Combine(Path.GetTempPath(), $"lemmy-net-{Guid.NewGuid():N}");
        Directory.CreateDirectory(_configDirectory);
        await File.WriteAllTextAsync(Path.Combine(_configDirectory, "config.hjson"), Config);
        _network = new NetworkBuilder().Build();
        _postgres = new PostgreSqlBuilder("postgres:16-alpine")
            .WithDatabase("lemmy").WithUsername("lemmy").WithPassword("password")
            .WithNetwork(_network).WithNetworkAliases("postgres")
            .WithLabel("lemmy-net.integration", "true").Build();
        _pictrs = new ContainerBuilder("asonix/pictrs:0.5.16")
            .WithNetwork(_network).WithNetworkAliases("pictrs")
            .WithEnvironment("PICTRS__API_KEY", PictrsApiKey)
            .WithEnvironment("RUST_LOG", "info")
            .WithLabel("lemmy-net.integration", "true").Build();
        try
        {
            await Task.WhenAll(_postgres.StartAsync(), _pictrs.StartAsync());
            _lemmy = new ContainerBuilder("dessalines/lemmy:0.19.20")
                .WithNetwork(_network).WithNetworkAliases("lemmy")
                .WithPortBinding(8536, true)
                .WithBindMount(_configDirectory, "/config", AccessMode.ReadOnly)
                .WithEnvironment("LEMMY_CONFIG_LOCATION", "/config/config.hjson")
                .WithEnvironment("RUST_LOG", "warn,lemmy_server=info")
                .WithLabel("lemmy-net.integration", "true").Build();
            await _lemmy.StartAsync();
            BaseUrl = $"http://127.0.0.1:{_lemmy.GetMappedPublicPort(8536)}";
            await WaitUntilReady();
            AdminClient = CreateClient();
            if (!await AdminClient.Login(AdminName, AdminPassword))
                throw new InvalidOperationException("Could not authenticate the integration-test admin.");
        }
        catch
        {
            await WriteLogs();
            throw;
        }
    }

    public async Task Stop()
    {
        await WriteLogs();
        AdminClient?.Dispose();
        if (_lemmy is not null) await _lemmy.DisposeAsync();
        if (_pictrs is not null) await _pictrs.DisposeAsync();
        if (_postgres is not null) await _postgres.DisposeAsync();
        if (_network is not null) await _network.DisposeAsync();
        if (_configDirectory is not null && Directory.Exists(_configDirectory))
            Directory.Delete(_configDirectory, true);
    }

    private async Task WaitUntilReady()
    {
        using var client = CreateClient();
        using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(3));
        Exception? lastError = null;
        while (!timeout.IsCancellationRequested)
        {
            try
            {
                if ((await client.GetSite(timeout.Token))?.SiteView.Site.Name == "Lemmy.Net tests")
                    return;
            }
            catch (Exception error) when (error is HttpRequestException or ApiException)
            {
                lastError = error;
            }
            await Task.Delay(TimeSpan.FromSeconds(2), timeout.Token);
        }
        throw new TimeoutException("Lemmy did not become ready.", lastError);
    }

    private async Task WriteLogs()
    {
        var output = Environment.GetEnvironmentVariable("LEMMY_TEST_LOG_DIR")
            ?? Path.Combine(TestContext.CurrentContext.WorkDirectory, "container-logs");
        output = Path.GetFullPath(output);
        Directory.CreateDirectory(output);
        foreach (var (name, container) in new[] { ("postgres", (IContainer?)_postgres), ("pictrs", _pictrs), ("lemmy", _lemmy) })
        {
            if (container is null) continue;
            try
            {
                var (stdout, stderr) = await container.GetLogsAsync();
                await File.WriteAllTextAsync(Path.Combine(output, $"{name}.log"), stdout + stderr);
            }
            catch (Exception error)
            {
                TestContext.Progress.WriteLine($"Could not collect {name} logs: {error.Message}");
            }
        }
    }

    private const string Config = """
        {
          setup: {
            admin_username: "lemmy_admin"
            admin_password: "integration-test-password"
            site_name: "Lemmy.Net tests"
          }
          database: {
            host: "postgres"
            port: 5432
            user: "lemmy"
            password: "password"
            database: "lemmy"
          }
          hostname: "lemmy"
          bind: "0.0.0.0"
          port: 8536
          tls_enabled: false
          pictrs: {
            url: "http://pictrs:8080/"
            api_key: "integration-test-pictrs-key"
            image_mode: "None"
          }
        }
        """;
}
