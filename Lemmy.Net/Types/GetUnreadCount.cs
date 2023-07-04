using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class GetUnreadCount : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

