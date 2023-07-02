namespace Lemmy.Net.Types
{

    public class ModRemoveCommentView
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment")]
        public Comment Comment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("commenter")]
        public Person Commenter { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_remove_comment")]
        public ModRemoveComment ModRemoveComment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderator")]
        public Person Moderator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public Post Post { get; set; }

    }
}

