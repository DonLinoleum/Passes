using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.User
{
    class UserModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("second_name")]
        public string SecondName { get; set; }

        [JsonPropertyName("work_position")]
        public string WorkPosition { get; set; }

    }
}
