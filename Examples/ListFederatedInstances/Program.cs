using Lemmy.Net;

var api = new LemmyHttp(
    Environment.GetEnvironmentVariable("LEMMY_API_URL") ?? "https://lemmy.ml"
);

var instances = await api.GetFederatedInstances();
const string indent = "    ";

if (instances != null)
{
    var types = new[]
    {
        ("Linked", instances.FederatedInstances.Linked),
        ("Allowed", instances.FederatedInstances.Allowed),
        ("Blocked", instances.FederatedInstances.Blocked)
    };

    foreach (var (type, typeInstances) in types)
    {
        Console.WriteLine($"{type} instances:");
        foreach (var instance in instances.FederatedInstances.Linked)
            Console.WriteLine($"{indent}{instance.Domain}");

        Console.WriteLine();
    }
}
