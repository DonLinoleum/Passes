using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.PassDetail
{
    public class ChildrenModel
    {
        [JsonPropertyName("vehicles")]
        public List<VehiclesChildren>? VehiclesChildren { get; set; }
        [JsonPropertyName("visitors")]
        public List<VisitorsChildren>? VisitorsChildren { get; set; }
    }

    public class VehiclesChildren
    {
        [JsonPropertyName("pass_id")]
        public string? PassId { get; set; }
        [JsonPropertyName("pass_num")]
        public string? PassNum { get; set; }
        [JsonPropertyName("pass_state_id")]
        public string? PassStateId { get; set; }
        [JsonPropertyName("decisions")]
        public List<DecisionsChildren>? DecisionsChildren { get; set; }
        [JsonPropertyName("negotiators")]
        public List<NegotiatorsChildren>? NegotiatorsChildren { get; set; }

    }

    public class VisitorsChildren
    {
        [JsonPropertyName("pass_id")]
        public string? PassId { get; set; }
        [JsonPropertyName("pass_num")]
        public string? PassNum { get; set; }
        [JsonPropertyName("pass_state_id")]
        public string? PassStateId { get; set; }
        [JsonPropertyName("decisions")]
        public List<DecisionsChildren>? DecisionsChildren { get; set; }
        [JsonPropertyName("negotiators")]
        public List<NegotiatorsChildren>? NegotiatorsChildren { get; set; }
    }

    public class DecisionsChildren
    {
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }
        [JsonPropertyName("is_current_step")]
        public bool? IsCurrentStamp { get; set; }
    }

    public class NegotiatorsChildren
    {
        [JsonPropertyName("ID")]
        public string? ID { get; set; }

        [JsonPropertyName("NAME")]
        public string? NAME { get; set; }

        [JsonPropertyName("SECOND_NAME")]
        public string? SECOND_NAME { get; set; }

        [JsonPropertyName("LAST_NAME")]
        public string? LAST_NAME { get; set; }

        [JsonPropertyName("WORK_POSITION")]
        public string? WORK_POSITION { get; set; }

        [JsonPropertyName("WORK_PROFILE")]
        public string? WORK_PROFILE { get; set; }

        [JsonPropertyName("WORK_COMPANY")]
        public string? WORK_COMPANY { get; set; }
    }


}
