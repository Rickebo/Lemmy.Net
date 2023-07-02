namespace Lemmy.Net.Types
{

    public class SiteAggregates
    {
        [System.Text.Json.Serialization.JsonPropertyName("comments")]
        public long Comments { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("communities")]
        public long Communities { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("posts")]
        public long Posts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("site_id")]
        public long SiteId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("users")]
        public long Users { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("users_active_day")]
        public long UsersActiveDay { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("users_active_half_year")]
        public long UsersActiveHalfYear { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("users_active_month")]
        public long UsersActiveMonth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("users_active_week")]
        public long UsersActiveWeek { get; set; }

    }
}

