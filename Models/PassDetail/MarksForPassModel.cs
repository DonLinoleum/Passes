using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.PassDetail
{
   public class MarksForPassModel
    {
        [JsonPropertyName("Marks")]
        public List<Mark>? Marks { get; set; }

        [JsonPropertyName("Movement")]
        public List<Mark>? Movement { get; set; }

        [JsonPropertyName("Print")]
        public List<PrintMark>? PrintMark { get; set; }
    }

   public class PrintMark
    {
        [JsonPropertyName("user")]
        public string? User { get; set; }

        [JsonPropertyName("event_ts")]
        public string? EventTs { get; set; }
    }

   public class Mark
    {
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("header")]
        public string? Header { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("name_short")]
        public string? NameShort { get; set; }

        [JsonPropertyName("position")]
        public string?Position { get; set; }

        [JsonPropertyName("time")]
        public string? Time { get; set; }

        [JsonPropertyName("time_only")]
        public string? TimeOnly { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("workplace")]
        public string? Workplace { get; set; }

    }
}
