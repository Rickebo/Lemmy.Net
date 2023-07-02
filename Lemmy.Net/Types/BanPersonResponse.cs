namespace Lemmy.Net.Types
{

    public class BanPersonResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("banned")]
        public bool Banned { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_view")]
        public PersonView PersonView { get; set; }
    }
}

