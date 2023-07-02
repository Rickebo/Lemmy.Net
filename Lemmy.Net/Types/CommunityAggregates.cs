namespace Lemmy.Net.Types
{

    public class CommunityAggregates
    {
        [System.Text.Json.Serialization.JsonPropertyName("comments")]
        public long Comments { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hot_rank")]
        public long HotRank { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("posts")]
        public long Posts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("subscribers")]
        public long Subscribers { get; set; }

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

