using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

public sealed class UploadImageResponse
{
    [JsonPropertyName("delete_url")]
    public string? DeleteUrl { get; set; }

    [JsonPropertyName("files")]
    public List<ImageFile>? Files { get; set; }

    [JsonPropertyName("msg")]
    public string Msg { get; set; } = null!;

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
