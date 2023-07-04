using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class PasswordReset
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public string Email { get; set; }

    }
}

