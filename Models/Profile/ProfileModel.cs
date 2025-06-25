using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.Profile
{
    public class ProfileResponseModel
    {
        [JsonPropertyName("data")]
        public ProfileModel? Profile { get; set; }
    }
    
   public class ProfileModel
    {
        [JsonPropertyName("LAST_NAME")]
        public string? LastName { get; set; }

        [JsonPropertyName("NAME")]
        public string? Name { get; set; }

        [JsonPropertyName("SECOND_NAME")]
        public string? SecondName { get; set; }

        [JsonPropertyName("EMAIL")]
        public string? Email { get; set; }

        [JsonPropertyName("PERSONAL_PHONE")]
        public string? PersonalPhone { get; set; }

        [JsonPropertyName("WORK_POSITION")]
        public string? WorkPosition { get; set; }

        [JsonPropertyName("WORK_DEPARTMENT")]
        public string? WorkDepartment { get; set; }

        [JsonPropertyName("WORK_ROOM")]
        public string? WorkRoom { get; set; }

        [JsonPropertyName("WORK_PROFILE")]
        public string? WorkProfile { get; set; }

        [JsonPropertyName("EMPLOYEE_ID")]
        public string? EmployeeId { get; set; }

        [JsonPropertyName("REPLACING_USERS")]
        public List<string>? ReplacingUsers { get; set; }
    }
}
