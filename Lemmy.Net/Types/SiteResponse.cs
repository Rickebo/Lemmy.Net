namespace Lemmy.Net.Types
{

    public class SiteResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("site_view")]
        public SiteView SiteView { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("taglines")]
        public List<Tagline> Taglines { get; set; }

    }
}

