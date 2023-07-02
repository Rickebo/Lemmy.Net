namespace Lemmy.Net.Types
{

    public class Post
    {
        [System.Text.Json.Serialization.JsonPropertyName("ap_id")]
        public string ApId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("body")]
        public string Body { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_id")]
        public long CreatorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("embed_description")]
        public string EmbedDescription { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("embed_title")]
        public string EmbedTitle { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("embed_video_url")]
        public string EmbedVideoUrl { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("featured_community")]
        public bool FeaturedCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("featured_local")]
        public bool FeaturedLocal { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("language_id")]
        public long LanguageId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local")]
        public bool Local { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("locked")]
        public bool Locked { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nsfw")]
        public bool Nsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed")]
        public bool Removed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("url")]
        public string Url { get; set; }

    }
}

