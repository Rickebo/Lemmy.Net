namespace Lemmy.Net.Types
{

    public class GetSiteMetadataResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("metadata")]
        public SiteMetadata Metadata { get; set; }

    }
}

