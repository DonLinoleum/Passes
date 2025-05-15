using System.Text.Json.Serialization;

namespace Passes.Models.PassList
{
   public class PassListModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("pass_num")]
        public string? PassNum { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_type_name")]
        public string? PassTypeName { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_state_name")]
        public string? PassStateName { get; set; }

        [JsonPropertyName("visitors")]
        public List<VisitorPassListModel>? Visitors { get;set; }

        [JsonPropertyName("visit_goal")]
        public List<VisitGoalPassListModel>? VisitGoal { get; set; }

        [JsonPropertyName("date_from")]
        public string? DateFrom { get; set; }

        [JsonPropertyName("created")]
        public string? Created { get; set; }
    }

    public class VisitorPassListModel
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("second_name")]
        public string? SecondName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
    }

    public class VisitGoalPassListModel
    {
        [JsonPropertyName("name")]
        public string? name { get; set; }
    }

    public class NegotiatorsPassListModel
    {
        [JsonPropertyName("LAST_NAME")]
        public string? LastName { get; set; }

        [JsonPropertyName("SECOND_NAME")]
        public string? SecondName { get; set; }

        [JsonPropertyName("Name")]
        public string? FirstName { get; set; }
    }

    public class RootModel
    {
        [JsonPropertyName("Passes")]
        public List<PassListModel>? Passes { get; set; }
    }
}
