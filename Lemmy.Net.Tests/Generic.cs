namespace Lemmy.Net.Tests;

public static class Generic
{
    public static async Task<LemmyHttp> CreateClient()
    {
        var url = Environment.GetEnvironmentVariable(
            "LEMMY_API_URL"
        ) ?? throw new Exception(
            "LEMMY_API_URL environment variable not set."
        );

        var pictrsUrl = Environment.GetEnvironmentVariable(
            "LEMMY_PICTRS_URL"
        );

        var instance = new LemmyHttp(
            apiUrl: url,
            pictrsUrl: pictrsUrl
        );

        var username = Environment.GetEnvironmentVariable(
            "LEMMY_USERNAME"
        );

        var password = Environment.GetEnvironmentVariable(
            "LEMMY_PASSWORD"
        );

        if (username != null || password != null)
        {
            if (username == null || password == null)
                throw new Exception("Cannot log in with null username or password.");

            await instance.Login(
                usernameOrEmail: username,
                password: password
            );
        }
        
        return instance;
    }
}