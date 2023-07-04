using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class GetSiteMetadata
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("url")]
        public string Url { get; set; }

    }
}

