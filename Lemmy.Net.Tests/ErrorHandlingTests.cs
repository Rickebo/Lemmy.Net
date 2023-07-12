using System.Net;
using Lemmy.Net.Types;

namespace Lemmy.Net.Tests;

public class ErrorHandlingTests
{
    private LemmyHttp _lemmyHttp;

    [SetUp]
    public async Task Setup()
    {
        _lemmyHttp = await Generic.CreateClient();
    }

    [Test]
    public async Task TestInvalidTitle()
    {
        try
        {
            var _ = await _lemmyHttp.CreatePost(
                new CreatePost()
                {
                    Name = "Invali\nd character",
                    Body = "Text post",
                }
            );
            
            Assert.Fail("Post with invalid title should throw an exception.");
        }
        catch (ApiException ex)
        {
            Assert.That(ex.Error, Is.EqualTo("invalid_post_title"));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}