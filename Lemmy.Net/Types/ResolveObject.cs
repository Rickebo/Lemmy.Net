using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class ResolveObject
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("q")]
        public string Q { get; set; }

    }
}

