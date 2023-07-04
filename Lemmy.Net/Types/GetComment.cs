using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class GetComment : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

    }
}

