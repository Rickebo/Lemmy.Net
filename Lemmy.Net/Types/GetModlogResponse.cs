namespace Lemmy.Net.Types
{

    public class GetModlogResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("added")]
        public List<ModAddView> Added { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("added_to_community")]
        public List<ModAddCommunityView> AddedToCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin_purged_comments")]
        public List<AdminPurgeCommentView> AdminPurgedComments { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin_purged_communities")]
        public List<AdminPurgeCommunityView> AdminPurgedCommunities { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin_purged_persons")]
        public List<AdminPurgePersonView> AdminPurgedPersons { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin_purged_posts")]
        public List<AdminPurgePostView> AdminPurgedPosts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banned")]
        public List<ModBanView> Banned { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banned_from_community")]
        public List<ModBanFromCommunityView> BannedFromCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("featured_posts")]
        public List<ModFeaturePostView> FeaturedPosts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hidden_communities")]
        public List<ModHideCommunityView> HiddenCommunities { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("locked_posts")]
        public List<ModLockPostView> LockedPosts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed_comments")]
        public List<ModRemoveCommentView> RemovedComments { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed_communities")]
        public List<ModRemoveCommunityView> RemovedCommunities { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed_posts")]
        public List<ModRemovePostView> RemovedPosts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("transferred_to_community")]
        public List<ModTransferCommunityView> TransferredToCommunity { get; set; }

    }
}

