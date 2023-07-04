using Lemmy.Net;
using Lemmy.Net.Types;

var api = new LemmyHttp(
    Environment.GetEnvironmentVariable("LEMMY_API_URL") ?? "https://lemmy.ml"
);

await foreach (var community in api.ListAllCommunities())
    Console.WriteLine(community.Community.Name + "@" + new Uri(community.Community.ActorId).Host);
