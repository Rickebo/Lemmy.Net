using Lemmy.Net.Types;
using LemmyApi;

var api = new LemmyHttp(
    Environment.GetEnvironmentVariable("LEMMY_API_URL") ?? "https://lemmy.ml"
);

await foreach (var community in api.ListAllCommunities(new ListCommunities()))
    Console.WriteLine(community.Community.Name + "@" + new Uri(community.Community.ActorId).Host);
