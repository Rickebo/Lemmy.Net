using System.Runtime.CompilerServices;
using System.Text.Json;
using Lemmy.Net.Types;

namespace LemmyApi;

public class LemmyHttp : LemmyHttpClient
{
    public LemmyHttp(
        string apiUrl,
        Dictionary<string, string>? headers = null,
        string? pictrsUrl = null,
        JsonSerializerOptions? jsonSerializerOptions = null
    ) : base(
        apiUrl,
        headers,
        pictrsUrl,
        jsonSerializerOptions
    )
    {
    }

    public async Task<bool> Login(
        string usernameOrEmail,
        string password,
        string? totp2faToken = null,
        CancellationToken cancellationToken = default
    )
    {
        var request = new Login()
        {
            UsernameOrEmail = usernameOrEmail,
            Password = password,
            Totp2faToken = totp2faToken
        };

        var response = await Login(request, cancellationToken: cancellationToken);

        if (response == null || string.IsNullOrEmpty(response.Jwt))
            return false;

        AuthToken = response.Jwt;
        return true;
    }

    public async IAsyncEnumerable<PostView> GetAllPosts(
        GetPosts request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => GetPosts(currentRequest, cancellationToken),
                response => response!.Posts,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<CommentView> GetAllComments(
        GetComments request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => GetComments(currentRequest, cancellationToken),
                response => response!.Comments,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<T> GetAllModlog<T>(
        GetModlog request,
        Func<GetModlogResponse, IEnumerable<T>> selector,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => GetModlog(currentRequest, cancellationToken),
                selector,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<T> GetAllPersonDetails<T>(
        GetPersonDetails request,
        Func<GetPersonDetailsResponse, IEnumerable<T>> selector,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => GetPersonDetails(currentRequest, cancellationToken),
                selector,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<PersonMentionView> GetAllPersonMentions(
        GetPersonMentions request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => GetPersonMentions(currentRequest, cancellationToken),
                response => response.Mentions,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<PrivateMessageView> GetAllPrivateMessages(
        GetPrivateMessages request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => GetPrivateMessages(currentRequest, cancellationToken),
                response => response.PrivateMessages,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<CommentReplyView> GetAllReplies(
        GetReplies request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => GetReplies(currentRequest, cancellationToken),
                response => response.Replies,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<CommentReportView> ListAllCommentReports(
        ListCommentReports request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => ListCommentReports(currentRequest, cancellationToken),
                response => response.CommentReports,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<CommunityView> ListAllCommunities(
        ListCommunities request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => ListCommunities(currentRequest, cancellationToken),
                response => response.Communities,
                cancellationToken
            )
        )
            yield return post;
    }

    public async IAsyncEnumerable<PostReportView> ListAllPostReports(
        ListPostReports request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => ListPostReports(currentRequest, cancellationToken),
                response => response.PostReports,
                cancellationToken
            )
        )
            yield return post;
    }



    public async IAsyncEnumerable<PrivateMessageReportView> ListAllPrivateMessageReports(
        ListPrivateMessageReports request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => ListPrivateMessageReports(currentRequest, cancellationToken),
                response => response.PrivateMessageReports,
                cancellationToken
            )
        )
            yield return post;
    }


    public async IAsyncEnumerable<RegistrationApplicationView> ListAllRegistrationApplications(
        ListRegistrationApplications request,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var post in Paginate(
                request,
                currentRequest => ListRegistrationApplications(currentRequest, cancellationToken),
                response => response.RegistrationApplications,
                cancellationToken
            )
        )
            yield return post;
    }

    protected async IAsyncEnumerable<TEntry> Paginate<TRequest, TPage, TEntry>(
        TRequest seed,
        Func<TRequest, Task<TPage?>> pageReader,
        Func<TPage, IEnumerable<TEntry>> entryReader,
        [EnumeratorCancellation]
        CancellationToken cancellationToken = default
    ) where TRequest : IPaginatedResult
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var page = await pageReader(seed);
            seed.Page += 1;

            if (page == null)
                yield break;

            var any = false;
            foreach (var entry in entryReader(page))
            {
                any = true;
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return entry;
            }

            if (!any)
                yield break;
        }
    }

    #region From lemmy-js-client, ported to C#

    /**
   * Gets the site, and your user data.
   *
   * `HTTP.GET /site`
   */
    public async Task<GetSiteResponse?> GetSite(
        GetSite? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetSite, GetSiteResponse>(
            "site",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Create your site.
   *
   * `HTTP.POST /site`
   */
    public async Task<SiteResponse?> CreateSite(CreateSite request, CancellationToken cancellationToken = default) =>
        await Post<CreateSite, SiteResponse>(
            "site",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Edit your site.
   *
   * `HTTP.PUT /site`
   */
    public async Task<SiteResponse?> EditSite(EditSite request, CancellationToken cancellationToken = default) =>
        await Put<EditSite, SiteResponse>(
            "site",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Leave the Site admins.
   *
   * `HTTP.POST /user/leave_admin`
   */
    public async Task<GetSiteResponse?> LeaveAdmin(LeaveAdmin request, CancellationToken cancellationToken = default) =>
        await Post<LeaveAdmin, GetSiteResponse>(
            "user/leave_admin",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get the modlog.
   *
   * `HTTP.GET /modlog`
   */
    public async Task<GetModlogResponse?> GetModlog(
        GetModlog? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetModlog, GetModlogResponse>(
            "modlog",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Search lemmy.
   *
   * `HTTP.GET /search`
   */
    public async Task<SearchResponse?> Search(Search request, CancellationToken cancellationToken = default) =>
        await Get<Search, SearchResponse>(
            "search",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Fetch a non-local / federated object.
   *
   * `HTTP.GET /resolve_object`
   */
    public async Task<ResolveObjectResponse?> ResolveObject(
        ResolveObject request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<ResolveObject, ResolveObjectResponse>(
            "resolve_object",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Create a new community.
   *
   * `HTTP.POST /community`
   */
    public async Task<CommunityResponse?> CreateCommunity(
        CreateCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<CreateCommunity, CommunityResponse>(
            "community",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get / fetch a community.
   *
   * `HTTP.GET /community`
   */
    public async Task<GetCommunityResponse?> GetCommunity(
        GetCommunity? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetCommunity, GetCommunityResponse>(
            "community",
            request ?? new(),
            cancellationToken: cancellationToken
        );


    /**
   * Edit a community.
   *
   * `HTTP.PUT /community`
   */
    public async Task<CommunityResponse?> EditCommunity(
        EditCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<EditCommunity, CommunityResponse>(
            "community",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * List communities, with various filters.
   *
   * `HTTP.GET /community/list`
   */
    public async Task<ListCommunitiesResponse?> ListCommunities(
        ListCommunities? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<ListCommunities, ListCommunitiesResponse>(
            "community/list",
            request ?? new(),
            cancellationToken: cancellationToken
        );


    /**
   * Follow / subscribe to a community.
   *
   * `HTTP.POST /community/follow`
   */
    public async Task<CommunityResponse?> FollowCommunity(
        FollowCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<FollowCommunity, CommunityResponse>(
            "community/follow",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Block a community.
   *
   * `HTTP.POST /community/block`
   */
    public async Task<BlockCommunityResponse?> BlockCommunity(
        BlockCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<BlockCommunity, BlockCommunityResponse>(
            "community/block",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Delete a community.
   *
   * `HTTP.POST /community/delete`
   */
    public async Task<CommunityResponse?> DeleteCommunity(
        DeleteCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<DeleteCommunity, CommunityResponse>(
            "community/delete",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * A moderator remove for a community.
   *
   * `HTTP.POST /community/remove`
   */
    public async Task<CommunityResponse?> RemoveCommunity(
        RemoveCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<RemoveCommunity, CommunityResponse>(
            "community/remove",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Transfer your community to an existing moderator.
   *
   * `HTTP.POST /community/transfer`
   */
    public async Task<GetCommunityResponse?> TransferCommunity(
        TransferCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<TransferCommunity, GetCommunityResponse>(
            "community/transfer",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Ban a user from a community.
   *
   * `HTTP.POST /community/ban_user`
   */
    public async Task<BanFromCommunityResponse?> BanFromCommunity(
        BanFromCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<BanFromCommunity, BanFromCommunityResponse>(
            "community/ban_user",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Add a moderator to your community.
   *
   * `HTTP.POST /community/mod`
   */
    public async Task<AddModToCommunityResponse?> AddModToCommunity(
        AddModToCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<AddModToCommunity, AddModToCommunityResponse>(
            "community/mod",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Create a post.
   *
   * `HTTP.POST /post`
   */
    public async Task<PostResponse?> CreatePost(CreatePost request, CancellationToken cancellationToken = default) =>
        await Post<CreatePost, PostResponse>(
            "post",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get / fetch a post.
   *
   * `HTTP.GET /post`
   */
    public async Task<GetPostResponse?> GetPost(
        GetPost? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetPost, GetPostResponse>(
            "post",
            request ?? new(),
            cancellationToken: cancellationToken
        );


    /**
   * Edit a post.
   *
   * `HTTP.PUT /post`
   */
    public async Task<PostResponse?> EditPost(EditPost request, CancellationToken cancellationToken = default) =>
        await Put<EditPost, PostResponse>(
            "post",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Delete a post.
   *
   * `HTTP.POST /post/delete`
   */
    public async Task<PostResponse?> DeletePost(DeletePost request, CancellationToken cancellationToken = default) =>
        await Post<DeletePost, PostResponse>(
            "post/delete",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * A moderator remove for a post.
   *
   * `HTTP.POST /post/remove`
   */
    public async Task<PostResponse?> RemovePost(RemovePost request, CancellationToken cancellationToken = default) =>
        await Post<RemovePost, PostResponse>(
            "post/remove",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Mark a post as read.
   *
   * `HTTP.POST /post/mark_as_read`
   */
    public async Task<PostResponse?> MarkPostAsRead(
        MarkPostAsRead request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<MarkPostAsRead, PostResponse>(
            "post/mark_as_read",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * A moderator can lock a post ( IE disable new comments ).
   *
   * `HTTP.POST /post/lock`
   */
    public async Task<PostResponse?> LockPost(LockPost request, CancellationToken cancellationToken = default)
        => await Post<LockPost, PostResponse>(
            "post/lock",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * A moderator can feature a community post ( IE stick it to the top of a community ).
   *
   * `HTTP.POST /post/feature`
   */
    public async Task<PostResponse?> FeaturePost(FeaturePost request, CancellationToken cancellationToken = default) =>
        await Post<FeaturePost, PostResponse>(
            "post/feature",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get / fetch posts, with various filters.
   *
   * `HTTP.GET /post/list`
   */
    public async Task<GetPostsResponse?> GetPosts(
        GetPosts? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetPosts, GetPostsResponse>(
            "post/list",
            request ?? new(),
            cancellationToken: cancellationToken
        );


    /**
   * Like / vote on a post.
   *
   * `HTTP.POST /post/like`
   */
    public async Task<PostResponse?> LikePost(CreatePostLike request, CancellationToken cancellationToken = default) =>
        await Post<CreatePostLike, PostResponse>(
            "post/like",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Save a post.
   *
   * `HTTP.PUT /post/save`
   */
    public async Task<PostResponse?> SavePost(SavePost request, CancellationToken cancellationToken = default) =>
        await Put<SavePost, PostResponse>(
            "post/save",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Report a post.
   *
   * `HTTP.POST /post/report`
   */
    public async Task<PostReportResponse?> CreatePostReport(
        CreatePostReport request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<CreatePostReport, PostReportResponse>(
            "post/report",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Resolve a post report. Only a mod can do this.
   *
   * `HTTP.PUT /post/report/resolve`
   */
    public async Task<PostReportResponse?> ResolvePostReport(
        ResolvePostReport request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<ResolvePostReport, PostReportResponse>(
            "post/report/resolve",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * List post reports.
   *
   * `HTTP.GET /post/report/list`
   */
    public async Task<ListPostReportsResponse?> ListPostReports(
        ListPostReports request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<ListPostReports, ListPostReportsResponse>(
            "post/report/list",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Fetch metadata for any given site.
   *
   * `HTTP.GET /post/site_metadata`
   */
    public async Task<GetSiteMetadataResponse?> GetSiteMetadata(
        GetSiteMetadata request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetSiteMetadata, GetSiteMetadataResponse>(
            "post/site_metadata",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Create a comment.
   *
   * `HTTP.POST /comment`
   */
    public async Task<CommentResponse?> CreateComment(
        CreateComment request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<CreateComment, CommentResponse>(
            "comment",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Edit a comment.
   *
   * `HTTP.PUT /comment`
   */
    public async Task<CommentResponse?> EditComment(
        EditComment request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<EditComment, CommentResponse>(
            "comment",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Delete a comment.
   *
   * `HTTP.POST /comment/delete`
   */
    public async Task<CommentResponse?> DeleteComment(
        DeleteComment request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<DeleteComment, CommentResponse>(
            "comment/delete",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * A moderator remove for a comment.
   *
   * `HTTP.POST /comment/remove`
   */
    public async Task<CommentResponse?> RemoveComment(
        RemoveComment request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<RemoveComment, CommentResponse>(
            "comment/remove",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Mark a comment as read.
   *
   * `HTTP.POST /comment/mark_as_read`
   */
    public async Task<CommentReplyResponse?> MarkCommentReplyAsRead(
        MarkCommentReplyAsRead request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<MarkCommentReplyAsRead, CommentReplyResponse>(
            "comment/mark_as_read",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Like / vote on a comment.
   *
   * `HTTP.POST /comment/like`
   */
    public async Task<CommentResponse?> LikeComment(
        CreateCommentLike request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<CreateCommentLike, CommentResponse>(
            "comment/like",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Save a comment.
   *
   * `HTTP.PUT /comment/save`
   */
    public async Task<CommentResponse?> SaveComment(
        SaveComment request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<SaveComment, CommentResponse>(
            "comment/save",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Distinguishes a comment (speak as moderator)
   *
   * `HTTP.POST /comment/distinguish`
   */
    public async Task<CommentResponse?> DistinguishComment(
        DistinguishComment request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<DistinguishComment, CommentResponse>(
            "comment/distinguish",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get / fetch comments.
   *
   * `HTTP.GET /comment/list`
   */
    public async Task<GetCommentsResponse?> GetComments(
        GetComments? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetComments, GetCommentsResponse>(
            "comment/list",
            request ?? new(),
            cancellationToken: cancellationToken
        );


    /**
   * Get / fetch comment.
   *
   * `HTTP.GET /comment`
   */
    public async Task<CommentResponse?> GetComment(GetComment request, CancellationToken cancellationToken = default) =>
        await Get<GetComment, CommentResponse>(
            "comment",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Report a comment.
   *
   * `HTTP.POST /comment/report`
   */
    public async Task<CommentReportResponse?> CreateCommentReport(
        CreateCommentReport request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<CreateCommentReport, CommentReportResponse>(
            "comment/report",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Resolve a comment report. Only a mod can do this.
   *
   * `HTTP.PUT /comment/report/resolve`
   */
    public async Task<CommentReportResponse?> ResolveCommentReport(
        ResolveCommentReport request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<ResolveCommentReport, CommentReportResponse>(
            "comment/report/resolve",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * List comment reports.
   *
   * `HTTP.GET /comment/report/list`
   */
    public async Task<ListCommentReportsResponse?> ListCommentReports(
        ListCommentReports request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<ListCommentReports, ListCommentReportsResponse>(
            "comment/report/list",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get / fetch private messages.
   *
   * `HTTP.GET /private_message/list`
   */
    public async Task<PrivateMessagesResponse?> GetPrivateMessages(
        GetPrivateMessages request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetPrivateMessages, PrivateMessagesResponse>(
            "private_message/list",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Create a private message.
   *
   * `HTTP.POST /private_message`
   */
    public async Task<PrivateMessageResponse?> CreatePrivateMessage(
        CreatePrivateMessage request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<CreatePrivateMessage, PrivateMessageResponse>(
            "private_message",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Edit a private message.
   *
   * `HTTP.PUT /private_message`
   */
    public async Task<PrivateMessageResponse?> EditPrivateMessage(
        EditPrivateMessage request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<EditPrivateMessage, PrivateMessageResponse>(
            "private_message",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Delete a private message.
   *
   * `HTTP.POST /private_message/delete`
   */
    public async Task<PrivateMessageResponse?> DeletePrivateMessage(
        DeletePrivateMessage request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<DeletePrivateMessage, PrivateMessageResponse>(
            "private_message/delete",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Mark a private message as read.
   *
   * `HTTP.POST /private_message/mark_as_read`
   */
    public async Task<PrivateMessageResponse?> MarkPrivateMessageAsRead(
        MarkPrivateMessageAsRead request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<MarkPrivateMessageAsRead, PrivateMessageResponse>(
            "private_message/mark_as_read",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Create a report for a private message.
   *
   * `HTTP.POST /private_message/report`
   */
    public async Task<PrivateMessageReportResponse?> CreatePrivateMessageReport(
        CreatePrivateMessageReport request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<CreatePrivateMessageReport, PrivateMessageReportResponse>(
            "private_message/report",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Resolve a report for a private message.
   *
   * `HTTP.PUT /private_message/report/resolve`
   */
    public async Task<PrivateMessageReportResponse?> ResolvePrivateMessageReport(
        ResolvePrivateMessageReport request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<ResolvePrivateMessageReport, PrivateMessageReportResponse>(
            "private_message/report/resolve",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * List private message reports.
   *
   * `HTTP.GET /private_message/report/list`
   */
    public async Task<ListPrivateMessageReportsResponse?> ListPrivateMessageReports(
        ListPrivateMessageReports request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<ListPrivateMessageReports, ListPrivateMessageReportsResponse>(
            "private_message/report/list",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Register a new user.
   *
   * `HTTP.POST /user/register`
   */
    public async Task<LoginResponse?> Register(Register request, CancellationToken cancellationToken = default) =>
        await Post<Register, LoginResponse>(
            "user/register",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Log into lemmy.
   *
   * `HTTP.POST /user/login`
   */
    public async Task<LoginResponse?> Login(Login request, CancellationToken cancellationToken = default) =>
        await Post<Login, LoginResponse>(
            "user/login",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get the details for a person.
   *
   * `HTTP.GET /user`
   */
    public async Task<GetPersonDetailsResponse?> GetPersonDetails(
        GetPersonDetails? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetPersonDetails, GetPersonDetailsResponse>(
            "user",
            request ?? new(),
            cancellationToken: cancellationToken
        );


    /**
   * Get mentions for your user.
   *
   * `HTTP.GET /user/mention`
   */
    public async Task<GetPersonMentionsResponse?> GetPersonMentions(
        GetPersonMentions request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetPersonMentions, GetPersonMentionsResponse>(
            "user/mention",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Mark a person mention as read.
   *
   * `HTTP.POST /user/mention/mark_as_read`
   */
    public async Task<PersonMentionResponse?> MarkPersonMentionAsRead(
        MarkPersonMentionAsRead request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<MarkPersonMentionAsRead, PersonMentionResponse>(
            "user/mention/mark_as_read",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get comment replies.
   *
   * `HTTP.GET /user/replies`
   */
    public async Task<GetRepliesResponse?> GetReplies(
        GetReplies request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetReplies, GetRepliesResponse>(
            "user/replies",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Ban a person from your site.
   *
   * `HTTP.POST /user/ban`
   */
    public async Task<BanPersonResponse?> BanPerson(BanPerson request, CancellationToken cancellationToken = default) =>
        await Post<BanPerson, BanPersonResponse>(
            "user/ban",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get a list of banned users
   *
   * `HTTP.GET /user/banned`
   */
    public async Task<BannedPersonsResponse?> GetBannedPersons(
        GetBannedPersons request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetBannedPersons, BannedPersonsResponse>(
            "user/banned",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Block a person.
   *
   * `HTTP.POST /user/block`
   */
    public async Task<BlockPersonResponse?> BlockPerson(
        BlockPerson request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<BlockPerson, BlockPersonResponse>(
            "user/block",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Fetch a Captcha.
   *
   * `HTTP.GET /user/get_captcha`
   */
    public async Task<GetCaptchaResponse?> GetCaptcha(
        GetCaptcha? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetCaptcha, GetCaptchaResponse>(
            "user/get_captcha",
            request ?? new(),
            cancellationToken: cancellationToken
        );


    /**
   * Delete your account.
   *
   * `HTTP.POST /user/delete_account`
   */
    public async Task<DeleteAccountResponse?> DeleteAccount(
        DeleteAccount request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<DeleteAccount, DeleteAccountResponse>(
            "user/delete_account",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Reset your password.
   *
   * `HTTP.POST /user/password_reset`
   */
    public async Task<PasswordResetResponse?> PasswordReset(
        PasswordReset request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<PasswordReset, PasswordResetResponse>(
            "user/password_reset",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Change your password from an email / token based reset.
   *
   * `HTTP.POST /user/password_change`
   */
    public async Task<LoginResponse?> PasswordChangeAfterReset(
        PasswordChangeAfterReset request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<PasswordChangeAfterReset, LoginResponse>(
            "user/password_change",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Mark all replies as read.
   *
   * `HTTP.POST /user/mark_all_as_read`
   */
    public async Task<GetRepliesResponse?> MarkAllAsRead(
        MarkAllAsRead request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<MarkAllAsRead, GetRepliesResponse>(
            "user/mark_all_as_read",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Save your user settings.
   *
   * `HTTP.PUT /user/save_user_settings`
   */
    public async Task<LoginResponse?> SaveUserSettings(
        SaveUserSettings request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<SaveUserSettings, LoginResponse>(
            "user/save_user_settings",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Change your user password.
   *
   * `HTTP.PUT /user/change_password`
   */
    public async Task<LoginResponse?> ChangePassword(
        ChangePassword request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<ChangePassword, LoginResponse>(
            "user/change_password",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get counts for your reports
   *
   * `HTTP.GET /user/report_count`
   */
    public async Task<GetReportCountResponse?> GetReportCount(
        GetReportCount request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetReportCount, GetReportCountResponse>(
            "user/report_count",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get your unread counts
   *
   * `HTTP.GET /user/unread_count`
   */
    public async Task<GetUnreadCountResponse?> GetUnreadCount(
        GetUnreadCount request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetUnreadCount, GetUnreadCountResponse>(
            "user/unread_count",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Verify your email
   *
   * `HTTP.POST /user/verify_email`
   */
    public async Task<VerifyEmailResponse?> VerifyEmail(
        VerifyEmail request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<VerifyEmail, VerifyEmailResponse>(
            "user/verify_email",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Add an admin to your site.
   *
   * `HTTP.POST /admin/add`
   */
    public async Task<AddAdminResponse?> AddAdmin(AddAdmin request, CancellationToken cancellationToken = default) =>
        await Post<AddAdmin, AddAdminResponse>(
            "admin/add",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Get the unread registration applications count.
   *
   * `HTTP.GET /admin/registration_application/count`
   */
    public async Task<GetUnreadRegistrationApplicationCountResponse?> GetUnreadRegistrationApplicationCount(
        GetUnreadRegistrationApplicationCount request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetUnreadRegistrationApplicationCount, GetUnreadRegistrationApplicationCountResponse>(
            "admin/registration_application/count",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * List the registration applications.
   *
   * `HTTP.GET /admin/registration_application/list`
   */
    public async Task<ListRegistrationApplicationsResponse?> ListRegistrationApplications(
        ListRegistrationApplications request,
        CancellationToken cancellationToken = default
    ) =>
        await Get<ListRegistrationApplications, ListRegistrationApplicationsResponse>(
            "admin/registration_application/list",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Approve a registration application
   *
   * `HTTP.PUT /admin/registration_application/approve`
   */
    public async Task<RegistrationApplicationResponse?> ApproveRegistrationApplication(
        ApproveRegistrationApplication request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<ApproveRegistrationApplication, RegistrationApplicationResponse>(
            "admin/registration_application/approve",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Purge / Delete a person from the database.
   *
   * `HTTP.POST /admin/purge/person`
   */
    public async Task<PurgeItemResponse?> PurgePerson(
        PurgePerson request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<PurgePerson, PurgeItemResponse>(
            "admin/purge/person",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Purge / Delete a community from the database.
   *
   * `HTTP.POST /admin/purge/community`
   */
    public async Task<PurgeItemResponse?> PurgeCommunity(
        PurgeCommunity request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<PurgeCommunity, PurgeItemResponse>(
            "admin/purge/community",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Purge / Delete a post from the database.
   *
   * `HTTP.POST /admin/purge/post`
   */
    public async Task<PurgeItemResponse?> PurgePost(PurgePost request, CancellationToken cancellationToken = default) =>
        await Post<PurgePost, PurgeItemResponse>(
            "admin/purge/post",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Purge / Delete a comment from the database.
   *
   * `HTTP.POST /admin/purge/comment`
   */
    public async Task<PurgeItemResponse?> PurgeComment(
        PurgeComment request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<PurgeComment, PurgeItemResponse>(
            "admin/purge/comment",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Create a new custom emoji
   *
   * `HTTP.POST /custom_emoji`
   */
    public async Task<CustomEmojiResponse?> CreateCustomEmoji(
        CreateCustomEmoji request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<CreateCustomEmoji, CustomEmojiResponse>(
            "custom_emoji",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Edit an existing custom emoji
   *
   * `HTTP.PUT /custom_emoji`
   */
    public async Task<CustomEmojiResponse?> EditCustomEmoji(
        EditCustomEmoji request,
        CancellationToken cancellationToken = default
    ) =>
        await Put<EditCustomEmoji, CustomEmojiResponse>(
            "custom_emoji",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Delete a custom emoji
   *
   * `HTTP.Post /custom_emoji/delete`
   */
    public async Task<DeleteCustomEmojiResponse?> DeleteCustomEmoji(
        DeleteCustomEmoji request,
        CancellationToken cancellationToken = default
    ) =>
        await Post<DeleteCustomEmoji, DeleteCustomEmojiResponse>(
            "custom_emoji/delete",
            request,
            cancellationToken: cancellationToken
        );


    /**
   * Fetch federated instances.
   *
   * `HTTP.Get /federated_instances`
   */
    public async Task<GetFederatedInstancesResponse?> GetFederatedInstances(
        GetFederatedInstances? request = null,
        CancellationToken cancellationToken = default
    ) =>
        await Get<GetFederatedInstances, GetFederatedInstancesResponse>(
            "federated_instances",
            request,
            cancellationToken: cancellationToken
        );

    #endregion
}