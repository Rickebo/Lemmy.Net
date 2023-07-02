namespace Lemmy.Net.Types
{

    public class ModFeaturePost
    {
        [System.Text.Json.Serialization.JsonPropertyName("featured")]
        public bool Featured { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("is_featured_community")]
        public bool IsFeaturedCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_person_id")]
        public long ModPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("when_")]
        public string When { get; set; }

    }
}

