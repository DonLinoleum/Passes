using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.PassDetail
{
    public class ApproveProgressMarksModel
    {
        private ApproveProgressNegotiator? _mol;

        [JsonPropertyName("mol")]
        public object? MolRaw
        {
            get => _mol;
            set
            {
                if (value is JsonElement element)
                {
                    _mol = element.ValueKind == JsonValueKind.Array
                        ? null : element.Deserialize<ApproveProgressNegotiator>();
                }
            }
        }

        [JsonIgnore]
        public ApproveProgressNegotiator? Mol => _mol;

        [JsonPropertyName("negotiators")]
        public List<ApproveProgressNegotiator>? Negotiators { get; set; }
    }

   public class ApproveProgressNegotiator
    {
        [JsonPropertyName("COMMENT")]
        public string? Comment { get; set; }

        [JsonPropertyName("DATE")]
        public string? Date { get; set; }

        [JsonPropertyName("GROUP")]
        public string? Group { get; set; }

        [JsonPropertyName("IS_GROUP")]
        public bool? IsGroup { get; set; }

        [JsonPropertyName("ID")]
        public string? Id { get; set; }

        [JsonPropertyName("LAST_NAME")]
        public string? LastName { get; set; }

        [JsonPropertyName("NAME")]
        public string? Name { get; set; }

        [JsonPropertyName("ROLE")]
        public string? Role { get; set; }

        [JsonPropertyName("SECOND_NAME")]
        public string? SecondName { get; set; }

        [JsonPropertyName("STATUS")]
        public string? Status { get; set; }
    }

    
}
