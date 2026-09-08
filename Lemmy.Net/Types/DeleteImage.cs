namespace Lemmy.Net.Types;

public sealed class DeleteImage
{
    public required string Token { get; init; }

    public required string FileName { get; init; }
}
