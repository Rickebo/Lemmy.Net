# Lemmy.Net
[![Nuget](https://img.shields.io/nuget/v/Lemmy.Net)](https://www.nuget.org/packages/Lemmy.Net)

A .NET 7 library for interacting with the Lemmy API, based on [lemmy-js-client](https://github.com/LemmyNet/lemmy-js-client) and written in C#.

## Prerequisites
- [.NET 7](https://dotnet.microsoft.com/download/dotnet/7.0) or later

## Documentation
See the [lemmy-js-client docs](https://join-lemmy.org/api/classes/LemmyHttp.html) for documentation.

## Installation

### NuGet
Either find and install the [Lemmy.Net package](https://www.nuget.org/packages/Lemmy.Net) in your IDE's NuGet package manager, or run the following command in your project directory:
```sh
dotnet add package Lemmy.Net
```



## Example usage
See [Examples](Examples) for fully-working example projects on how the API can be used.

To print post titles from the [lemmy.ml](https://lemmy.ml) instance, one by one until the user presses any key other than`n`:
```cs
using Lemmy.Net;

var client = new LemmyHttp("https://lemmy.ml");
await foreach (var postView in api.GetAllPosts())
{
    Console.WriteLine(postView.Post.Name);
    
    if (Console.ReadKey().KeyChar != 'n')
        return;
}
```

To list all communities on the [ds9.lemmy.ml](https://dev.lemmy.ml) instance:
```cs
var api = new LemmyHttp(
    "https://ds9.lemmy.ml"
);

await foreach (var communityView in api.ListAllCommunities())
    Console.WriteLine(communityView.Community.Name + "@" + new Uri(communityView.Community.ActorId).Host);
```