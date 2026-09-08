namespace Lemmy.Net.Types;

public sealed class UploadImage
{
    public required Stream Image { get; init; }

    public required string FileName { get; init; }

    public string? ContentType { get; init; }
}
