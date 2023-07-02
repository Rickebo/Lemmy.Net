namespace Lemmy.Net.Types
{

    public class BannedPersonsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("banned")]
        public List<PersonView> Banned { get; set; }

    }
}

