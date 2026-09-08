using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

public sealed class ImageFile
{
    [JsonPropertyName("delete_token")]
    public string DeleteToken { get; set; } = null!;

    [JsonPropertyName("file")]
    public string File { get; set; } = null!;
}
