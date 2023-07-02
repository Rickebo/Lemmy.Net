using Lemmy.Net.Types;
using LemmyApi;

var api = new LemmyHttp(
    Environment.GetEnvironmentVariable("LEMMY_API_URL") ?? "https://lemmy.ml"
);

// Log in with username and password provided from environment variables.
if (!await api.Login(
        usernameOrEmail: Environment.GetEnvironmentVariable("LEMMY_USERNAME"),
        password: Environment.GetEnvironmentVariable("LEMMY_PASSWORD")
    ))
    throw new Exception(
        "Failed to log in to Lemmy instance with api url, username and password provided from" +
        " environment variables."
    );

Console.WriteLine("Successfully logged in.");

// Search for a community with the name provided from environment variable to find its community id.
var communityName = Environment.GetEnvironmentVariable("LEMMY_COMMUNITY_NAME");

if (string.IsNullOrEmpty(communityName))
    throw new Exception("Invalid community name provided from environment variable.");

var community = await api.Search(new Search()
{
    Type = SearchType.Communities,
    Q = communityName,
    Limit = 1,
    ListingType = ListingType.Local
});

if (community == null || community.Communities.Count == 0)
    throw new Exception("Could not find community with given name.");

Console.WriteLine(
    $"Found matching community {community.Communities.First().Community.Name} " +
    $"with id {community.Communities.First().Community.Id}"
);

var communityId = community.Communities.First().Community.Id;

// Create a post in the community with the id found above.
var post = await api.CreatePost(
    new CreatePost()
    {
        CommunityId = communityId,
        Body = "This is a test post from Lemmy.Net",
        Name = "Lemmy.Net Test Post"
    }
);

if (post == null || post.PostView == null)
    throw new Exception("Failed to create post.");

Console.WriteLine($"Created post with post id {post.PostView.Post.Id}");

// Create a reply to the post created above.
var reply = await api.CreateComment(
    new CreateComment()
    {
        PostId = post.PostView.Post.Id,
        Content = "This is a test reply from Lemmy.Net"
    }
);

if (reply == null || reply.CommentView == null)
    throw new Exception("Failed to create reply.");

Console.WriteLine($"Created reply with id {reply.CommentView.Comment.Id}");
Console.WriteLine("Done!");