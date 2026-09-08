# Lemmy.Net

[![NuGet](https://img.shields.io/nuget/v/Lemmy.Net)](https://www.nuget.org/packages/Lemmy.Net)
[![CI](https://github.com/Rickebo/Lemmy.Net/actions/workflows/ci.yml/badge.svg)](https://github.com/Rickebo/Lemmy.Net/actions/workflows/ci.yml)

A strongly typed .NET client for the Lemmy v3 API.

## Support

Lemmy.Net targets .NET 10 and tracks the API used by Lemmy 0.19.20. Its generated
models are pinned to commit `48bd89285e8c3da85cddb020ce8dbc3c94846670`
of the upstream [`lemmy-js-client`](https://github.com/LemmyNet/lemmy-js-client)
v0.19 branch.

The .NET Lemmy ecosystem remains small. As of September 2026, the other public
NuGet clients (`Lemmy.Net.Client` and `dotNETLemmy.API`) have not received code
updates since 2023. There is no maintained, dominant replacement for this
library, so continued maintenance is useful rather than redundant.

## Installation

```shell
dotnet add package Lemmy.Net
```

## Usage

```csharp
using Lemmy.Net;

using var client = new LemmyHttp("https://lemmy.ml");

await foreach (var postView in client.GetAllPosts())
{
    Console.WriteLine(postView.Post.Name);
}
```

Authenticated requests use a bearer token:

```csharp
if (!await client.Login("username", "password"))
    throw new InvalidOperationException("Login failed.");

var replies = await client.GetReplies(new() { UnreadOnly = true });
```

See the [examples](Examples) and the upstream
[`lemmy-js-client` API documentation](https://join-lemmy.org/api/classes/LemmyHttp.html)
for the corresponding request and response types.

## Regenerating API models

The model generator is deliberately dependency-light. It downloads an exact
upstream commit, converts the `ts-rs` TypeScript declarations to nullable C#
models, and replaces generated files in `Lemmy.Net/Types` while preserving the
few handwritten support types.

Requirements are Node.js, `curl`, and `tar`:

```shell
./utils/generate-models.sh
dotnet test Lemmy.Net.sln
```

To update Lemmy support, change `upstream_commit` in
[`utils/generate-models.sh`](utils/generate-models.sh), regenerate, then adapt
the handwritten methods in `Lemmy.Net/LemmyHttp.cs` to upstream endpoint
changes. CI reruns generation and fails if committed models have drifted.

## Development and releases

Changes are made through pull requests. The CI workflow uses GitHub-hosted
runners to regenerate models, build, test, and pack the library. Conventional
commit messages drive Release Please on the default branch.

When a Release Please PR is merged, the release workflow:

1. creates the GitHub release and changelog;
2. publishes the NuGet and symbol packages to NuGet.org using the
   `NUGET_API_KEY` repository secret;
3. publishes the same package files as an OCI artifact at
   `ghcr.io/rickebo/lemmy.net:<version>`; and
4. attaches the package files to the GitHub release.

GHCR is an OCI registry rather than a NuGet feed. Consumers should install from
NuGet.org; the GHCR artifact exists for provenance and mirroring.
