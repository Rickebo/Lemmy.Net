using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class AddAdmin : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("added")]
        public bool Added { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("person_id")]
        public long PersonId { get; set; }

    }
}

