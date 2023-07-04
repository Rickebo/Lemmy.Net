using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class DeleteAccount : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("password")]
        public string Password { get; set; }

    }
}

