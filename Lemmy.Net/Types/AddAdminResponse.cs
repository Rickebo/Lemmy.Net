namespace Lemmy.Net.Types
{
    public class AddAdminResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("admins")]
        public List<PersonView> Admins { get; set; }
    }
}