namespace Lemmy.Net.Types
{

    public class SiteView
    {
        [System.Text.Json.Serialization.JsonPropertyName("counts")]
        public SiteAggregates Counts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local_site")]
        public LocalSite LocalSite { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local_site_rate_limit")]
        public LocalSiteRateLimit LocalSiteRateLimit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("site")]
        public Site Site { get; set; }

    }
}

