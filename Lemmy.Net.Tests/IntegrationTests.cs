using Lemmy.Net.Types;

namespace Lemmy.Net.Tests;

[Category("Integration")]
[NonParallelizable]
public sealed class IntegrationTests
{
    private readonly LemmyTestStack _stack = new();
#pragma warning disable NUnit1032 // Shared authenticated client is disposed by OneTimeTearDown.
    private LemmyHttp User { get; set; } = null!;
#pragma warning restore NUnit1032
    private long _userId;
    private long _otherUserId;
    private long _communityId;
    private long _postId;
    private long _commentId;

    [OneTimeSetUp]
    public Task StartStack() => _stack.Start();

    [OneTimeTearDown]
    public async Task StopStack()
    {
        User?.Dispose();
        await _stack.Stop();
    }

    [Test]
    [Order(1)]
    public async Task GetSiteAndAuthenticateAdmin()
    {
        using var anonymous = _stack.CreateClient();
        var site = await anonymous.GetSite();
        Assert.That(site!.SiteView.Site.Name, Is.EqualTo("Lemmy.Net tests"));

        Assert.That((await _stack.AdminClient.GetSite())!.MyUser, Is.Not.Null);

        var edited = await _stack.AdminClient.EditSite(new EditSite
        {
            RegistrationMode = RegistrationMode.Open,
            RateLimitMessage = 100,
            RateLimitMessagePerSecond = 100,
            RateLimitPost = 100,
            RateLimitPostPerSecond = 100,
            RateLimitRegister = 100,
            RateLimitRegisterPerSecond = 100,
            RateLimitImage = 100,
            RateLimitImagePerSecond = 100,
            RateLimitComment = 100,
            RateLimitCommentPerSecond = 100,
            RateLimitSearch = 100,
            RateLimitSearchPerSecond = 100
        });
        Assert.That(edited!.SiteView.LocalSite.RegistrationMode, Is.EqualTo(RegistrationMode.Open));
    }

    [Test]
    [Order(2)]
    public async Task RegisterAndExerciseUserDiscovery()
    {
        User = _stack.CreateClient();
        var registered = await User.Register(new Register
        {
            Username = "integration_user",
            Password = "integration-user-password",
            PasswordVerify = "integration-user-password"
        });
        Assert.That(registered!.Jwt, Is.Not.Empty);
        User.Authenticate(registered.Jwt!);

        var details = await User.GetPersonDetails(new GetPersonDetails { Username = "integration_user" });
        _userId = details!.PersonView.Person.Id;
        using (var other = _stack.CreateClient())
        {
            await other.Register(new Register
            {
                Username = "integration_other",
                Password = "integration-other-password",
                PasswordVerify = "integration-other-password"
            });
        }
        _otherUserId = (await _stack.AdminClient.GetPersonDetails(
            new GetPersonDetails { Username = "integration_other" }
        ))!.PersonView.Person.Id;
        Assert.That((await User.Search(new Search { Q = "integration_user", Type = SearchType.Users }))!.Users, Is.Not.Empty);
        Assert.That((await User.ResolveObject(new ResolveObject { Q = details.PersonView.Person.ActorId }))!.Person, Is.Not.Null);
        Assert.That(await User.ValidateAuth(), Is.Not.Null);
        Assert.That(await User.ListLogins(), Is.Not.Empty);
        Assert.That(await User.GetUnreadCount(), Is.Not.Null);
        Assert.That(await _stack.AdminClient.GetReportCount(new GetReportCount()), Is.Not.Null);
        Assert.That(await _stack.AdminClient.GetUnreadRegistrationApplicationCount(), Is.Not.Null);
        Assert.That((await User.GetPersonMentions(new GetPersonMentions()))!.Mentions, Is.Empty);
        Assert.That((await User.GetReplies(new GetReplies()))!.Replies, Is.Empty);
        Assert.That(await CountAsync(User.GetAllPersonMentions()), Is.Zero);
        Assert.That(await CountAsync(User.GetAllReplies()), Is.Zero);
        Assert.That(await User.MarkAllAsRead(), Is.Not.Null);
        Assert.That(await User.GetCaptcha(), Is.Not.Null);
        Assert.That(await User.SaveUserSettings(new SaveUserSettings { Bio = "Integration test user" }), Is.Not.Null);
    }

    [Test]
    [Order(3)]
    public async Task ExerciseCommunityPostAndCommentFeatures()
    {
        var admin = _stack.AdminClient;
        var community = await admin.CreateCommunity(new CreateCommunity
        {
            Name = "integration",
            Title = "Integration"
        });
        _communityId = community!.CommunityView.Community.Id;

        Assert.That((await admin.GetCommunity(new GetCommunity { Id = _communityId }))!.CommunityView.Community.Id, Is.EqualTo(_communityId));
        Assert.That((await admin.ListCommunities(new ListCommunities { Type = ListingType.Local }))!.Communities, Is.Not.Empty);
        Assert.That(await CountAsync(admin.ListAllCommunities(new ListCommunities { Type = ListingType.Local })), Is.GreaterThan(0));
        Assert.That(await admin.FindCommunityId("integration"), Is.EqualTo(_communityId));
        Assert.That((await admin.EditCommunity(new EditCommunity { CommunityId = _communityId, Description = "Updated" }))!.CommunityView.Community.Description, Is.EqualTo("Updated"));
        Assert.That(await User.FollowCommunity(new FollowCommunity { CommunityId = _communityId, Follow = true }), Is.Not.Null);
        Assert.That(await User.BlockCommunity(new BlockCommunity { CommunityId = _communityId, Block = true }), Is.Not.Null);
        Assert.That(await User.BlockCommunity(new BlockCommunity { CommunityId = _communityId, Block = false }), Is.Not.Null);
        Assert.That(await User.BlockPerson(new BlockPerson { PersonId = _otherUserId, Block = true }), Is.Not.Null);
        Assert.That(await User.BlockPerson(new BlockPerson { PersonId = _otherUserId, Block = false }), Is.Not.Null);

        var post = await admin.CreatePost(new CreatePost
        {
            CommunityId = _communityId,
            Name = "Integration post",
            Body = "Initial body"
        });
        _postId = post!.PostView.Post.Id;
        Assert.That((await admin.GetPost(new GetPost { Id = _postId }))!.PostView.Post.Id, Is.EqualTo(_postId));
        Assert.That((await admin.EditPost(new EditPost { PostId = _postId, Body = "Updated body" }))!.PostView.Post.Body, Is.EqualTo("Updated body"));
        Assert.That(await User.LikePost(new CreatePostLike { PostId = _postId, Score = 1 }), Is.Not.Null);
        Assert.That(await User.SavePost(new SavePost { PostId = _postId, Save = true }), Is.Not.Null);
        Assert.That(await User.MarkPostAsRead(new MarkPostAsRead { PostIds = [_postId], Read = true }), Is.Not.Null);
        Assert.That(await User.HidePost(new HidePost { PostIds = [_postId], Hide = true }), Is.Not.Null);
        Assert.That((await admin.GetPosts(new GetPosts { CommunityId = _communityId }))!.Posts, Is.Not.Empty);
        Assert.That(await CountAsync(admin.GetAllPosts(new GetPosts { CommunityId = _communityId })), Is.GreaterThan(0));

        var comment = await admin.CreateComment(new CreateComment { PostId = _postId, Content = "Initial comment" });
        _commentId = comment!.CommentView.Comment.Id;
        Assert.That((await admin.GetComment(new GetComment { Id = _commentId }))!.CommentView.Comment.Id, Is.EqualTo(_commentId));
        Assert.That((await admin.EditComment(new EditComment { CommentId = _commentId, Content = "Updated comment" }))!.CommentView.Comment.Content, Is.EqualTo("Updated comment"));
        Assert.That(await User.LikeComment(new CreateCommentLike { CommentId = _commentId, Score = 1 }), Is.Not.Null);
        Assert.That(await User.SaveComment(new SaveComment { CommentId = _commentId, Save = true }), Is.Not.Null);
        Assert.That(await admin.DistinguishComment(new DistinguishComment { CommentId = _commentId, Distinguished = true }), Is.Not.Null);
        Assert.That((await admin.GetComments(new GetComments { PostId = _postId }))!.Comments, Is.Not.Empty);
        Assert.That(await CountAsync(admin.GetAllComments(new GetComments { PostId = _postId })), Is.GreaterThan(0));
        Assert.That(await CountAsync(admin.GetAllPersonDetails(
            new GetPersonDetails { Username = "lemmy_admin" },
            x => x.Posts
        )), Is.GreaterThan(0));
    }

    [Test]
    [Order(4)]
    public async Task ExerciseMessagingReportsAndModeration()
    {
        var admin = _stack.AdminClient;
        var message = await admin.CreatePrivateMessage(new CreatePrivateMessage
        {
            RecipientId = _userId,
            Content = "Integration message"
        });
        var messageId = message!.PrivateMessageView.PrivateMessage.Id;
        Assert.That((await User.GetPrivateMessages(new GetPrivateMessages()))!.PrivateMessages, Is.Not.Empty);
        Assert.That(await admin.EditPrivateMessage(new EditPrivateMessage { PrivateMessageId = messageId, Content = "Updated message" }), Is.Not.Null);
        Assert.That(await User.MarkPrivateMessageAsRead(new MarkPrivateMessageAsRead { PrivateMessageId = messageId, Read = true }), Is.Not.Null);
        Assert.That(await CountAsync(User.GetAllPrivateMessages()), Is.GreaterThan(0));

        var postReport = await User.CreatePostReport(new CreatePostReport { PostId = _postId, Reason = "Integration report" });
        var commentReport = await User.CreateCommentReport(new CreateCommentReport { CommentId = _commentId, Reason = "Integration report" });
        var messageReport = await User.CreatePrivateMessageReport(new CreatePrivateMessageReport
        {
            PrivateMessageId = messageId,
            Reason = "Integration report"
        });
        Assert.That((await admin.ListPostReports(new ListPostReports()))!.PostReports, Is.Not.Empty);
        Assert.That((await admin.ListCommentReports(new ListCommentReports()))!.CommentReports, Is.Not.Empty);
        Assert.That((await admin.ListPrivateMessageReports(new ListPrivateMessageReports()))!.PrivateMessageReports, Is.Not.Empty);
        Assert.That(await CountAsync(admin.ListAllPostReports()), Is.GreaterThan(0));
        Assert.That(await CountAsync(admin.ListAllCommentReports()), Is.GreaterThan(0));
        Assert.That(await CountAsync(admin.ListAllPrivateMessageReports()), Is.GreaterThan(0));
        Assert.That(await admin.ResolvePostReport(new ResolvePostReport { ReportId = postReport!.PostReportView.PostReport.Id, Resolved = true }), Is.Not.Null);
        Assert.That(await admin.ResolveCommentReport(new ResolveCommentReport { ReportId = commentReport!.CommentReportView.CommentReport.Id, Resolved = true }), Is.Not.Null);
        Assert.That(await admin.ResolvePrivateMessageReport(new ResolvePrivateMessageReport
        {
            ReportId = messageReport!.PrivateMessageReportView.PrivateMessageReport.Id,
            Resolved = true
        }), Is.Not.Null);

        Assert.That(await admin.AddModToCommunity(new AddModToCommunity { CommunityId = _communityId, PersonId = _userId, Added = true }), Is.Not.Null);
        Assert.That((await admin.ListPostLikes(new ListPostLikes { PostId = _postId }))!.PostLikes, Is.Not.Empty);
        Assert.That((await admin.ListCommentLikes(new ListCommentLikes { CommentId = _commentId }))!.CommentLikes, Is.Not.Empty);
        Assert.That(await admin.LockPost(new LockPost { PostId = _postId, Locked = true }), Is.Not.Null);
        Assert.That(await admin.FeaturePost(new FeaturePost { PostId = _postId, Featured = true, FeatureType = PostFeatureType.Community }), Is.Not.Null);
        Assert.That(await admin.RemoveComment(new RemoveComment { CommentId = _commentId, Removed = true, Reason = "Integration moderation" }), Is.Not.Null);
        Assert.That(await admin.RemoveComment(new RemoveComment { CommentId = _commentId, Removed = false }), Is.Not.Null);
        Assert.That(await admin.RemovePost(new RemovePost { PostId = _postId, Removed = true, Reason = "Integration moderation" }), Is.Not.Null);
        Assert.That(await admin.RemovePost(new RemovePost { PostId = _postId, Removed = false }), Is.Not.Null);
        Assert.That(await admin.BanFromCommunity(new BanFromCommunity { CommunityId = _communityId, PersonId = _userId, Ban = true }), Is.Not.Null);
        Assert.That(await admin.BanFromCommunity(new BanFromCommunity { CommunityId = _communityId, PersonId = _userId, Ban = false }), Is.Not.Null);
        Assert.That(await admin.BanPerson(new BanPerson { PersonId = _userId, Ban = true }), Is.Not.Null);
        Assert.That((await admin.GetBannedPersons())!.Banned, Is.Not.Empty);
        Assert.That(await admin.BanPerson(new BanPerson { PersonId = _userId, Ban = false }), Is.Not.Null);
        Assert.That(await admin.GetModlog(new GetModlog()), Is.Not.Null);
        Assert.That(await CountAsync(admin.GetAllModlog(x => x.RemovedPosts)), Is.GreaterThan(0));
        Assert.That(await admin.GetFederatedInstances(), Is.Not.Null);
        Assert.That(await admin.HideCommunity(new HideCommunity { CommunityId = _communityId, Hidden = true, Reason = "Integration moderation" }), Is.Not.Null);
        Assert.That(await admin.HideCommunity(new HideCommunity { CommunityId = _communityId, Hidden = false }), Is.Not.Null);
        Assert.That(await admin.DeletePrivateMessage(new DeletePrivateMessage { PrivateMessageId = messageId, Deleted = true }), Is.Not.Null);
    }

    [Test]
    [Order(5)]
    public async Task UploadListDownloadAndDeleteImage()
    {
        var admin = _stack.AdminClient;
        await using var image = new MemoryStream(Convert.FromBase64String(
            "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNk+A8AAQUBAScY42YAAAAASUVORK5CYII="
        ));
        var uploaded = await admin.UploadImage(new UploadImage
        {
            Image = image,
            FileName = "integration.png",
            ContentType = "image/png"
        });
        var file = uploaded!.Files!.Single();

        using var http = new HttpClient();
        Assert.That((await http.GetAsync(uploaded.Url)).IsSuccessStatusCode, Is.True);
        Assert.That((await admin.ListMedia())!.Images.Select(x => x.LocalImage.PictrsAlias), Does.Contain(file.File));
        Assert.That((await admin.ListAllMedia())!.Images.Select(x => x.LocalImage.PictrsAlias), Does.Contain(file.File));
        var emoji = await admin.CreateCustomEmoji(new CreateCustomEmoji
        {
            Category = "integration",
            Shortcode = "integration",
            ImageUrl = uploaded.Url!,
            AltText = "Integration emoji",
            Keywords = ["integration"]
        });
        var emojiId = emoji!.CustomEmoji.CustomEmoji.Id;
        Assert.That(await admin.EditCustomEmoji(new EditCustomEmoji
        {
            Id = emojiId,
            Category = "integration",
            ImageUrl = uploaded.Url!,
            AltText = "Updated integration emoji",
            Keywords = ["integration", "updated"]
        }), Is.Not.Null);
        Assert.That(await admin.DeleteCustomEmoji(new DeleteCustomEmoji { Id = emojiId }), Is.Not.Null);

        Assert.That(await admin.DeleteImage(new DeleteImage
        {
            Token = file.DeleteToken,
            FileName = file.File
        }), Is.True);
        Assert.That((await admin.ListMedia())!.Images.Select(x => x.LocalImage.PictrsAlias), Does.Not.Contain(file.File));
    }

    [Test]
    [Order(6)]
    public async Task SoftDeleteCreatedContent()
    {
        var admin = _stack.AdminClient;
        Assert.That(await admin.DeleteComment(new DeleteComment { CommentId = _commentId, Deleted = true }), Is.Not.Null);
        Assert.That(await admin.DeletePost(new DeletePost { PostId = _postId, Deleted = true }), Is.Not.Null);
        Assert.That(await admin.DeleteCommunity(new DeleteCommunity { CommunityId = _communityId, Deleted = true }), Is.Not.Null);
    }

    private static async Task<int> CountAsync<T>(IAsyncEnumerable<T> source)
    {
        var count = 0;
        await foreach (var _ in source)
            count++;
        return count;
    }
}
