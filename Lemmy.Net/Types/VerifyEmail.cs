using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class VerifyEmail
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("token")]
        public string Token { get; set; }

    }
}

