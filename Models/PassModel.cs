

using System.Text.Json.Serialization;

namespace Passes.Models
{
   public class PassModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("pass_num")]
        public string? Pass_num { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_state_name")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_state_name { get; set; }

        [JsonPropertyName("date_from")]
        public string? Date_from { get; set; }
    }

    public class RootModel
    {
        [JsonPropertyName("Passes")]
        public List<PassModel> Passes { get; set; }
    }
}
