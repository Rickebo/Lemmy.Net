using Lemmy.Net;

var api = new LemmyHttp(
    Environment.GetEnvironmentVariable("LEMMY_API_URL") ?? "https://lemmy.ml"
);

var instances = await api.GetFederatedInstances();
const string indent = "    ";

if (instances?.FederatedInstances is { } federatedInstances)
{
    var types = new[]
    {
        ("Linked", federatedInstances.Linked),
        ("Allowed", federatedInstances.Allowed),
        ("Blocked", federatedInstances.Blocked)
    };

    foreach (var (type, typeInstances) in types)
    {
        Console.WriteLine($"{type} instances:");
        foreach (var instance in typeInstances ?? [])
            Console.WriteLine($"{indent}{instance.Domain}");

        Console.WriteLine();
    }
}
