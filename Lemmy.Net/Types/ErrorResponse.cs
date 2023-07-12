using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}