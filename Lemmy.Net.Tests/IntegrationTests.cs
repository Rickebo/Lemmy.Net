namespace Lemmy.Net.Tests;

public sealed class IntegrationTests
{
    [Test]
    [Explicit("Calls the instance configured by LEMMY_API_URL.")]
    [Category("Integration")]
    public async Task GetSiteFromLiveInstance()
    {
        var url = Environment.GetEnvironmentVariable("LEMMY_API_URL")
            ?? throw new InvalidOperationException("LEMMY_API_URL is required.");
        using var client = new LemmyHttp(url);

        var site = await client.GetSite();

        Assert.Multiple(() =>
        {
            Assert.That(site, Is.Not.Null);
            Assert.That(site!.Version, Is.Not.Empty);
            Assert.That(site.SiteView.Site.Name, Is.Not.Empty);
        });
    }
}
