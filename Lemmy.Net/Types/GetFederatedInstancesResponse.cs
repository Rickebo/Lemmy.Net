namespace Lemmy.Net.Types
{

    public class GetFederatedInstancesResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("federated_instances")]
        public FederatedInstances FederatedInstances { get; set; }

    }
}

