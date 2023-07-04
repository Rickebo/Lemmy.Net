using Lemmy.Net;
using Lemmy.Net.Types;

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

var communityId = await api.FindCommunityId(communityName);

if (communityId == null)
    throw new Exception("Could not find community with given name.");

Console.WriteLine($"Found matching community with id {communityId}");

// Create a post in the community with the id found above.
var post = await api.CreatePost(
    new CreatePost()
    {
        CommunityId = communityId.Value,
        Body = "This is a test post from Lemmy.Net",
        Name = "Lemmy.Net Test Post"
    }
);

if (post?.PostView == null)
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

if (reply?.CommentView == null)
    throw new Exception("Failed to create reply.");

Console.WriteLine($"Created reply with id {reply.CommentView.Comment.Id}");
Console.WriteLine("Done!");