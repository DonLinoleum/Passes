using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Services.Auth
{
    public class UserIdService
    {
        public static string? GetUserIdByJson(string data)
        {
            var unescapedData = Uri.UnescapeDataString(data);
            UserAuthModel? user = JsonSerializer.Deserialize<UserAuthModel>(unescapedData);
            return user?.id ?? null;
        }
    }

    public class UserAuthModel
    {
        [JsonPropertyName("id")]
        public string? id {  get; set; }
    }

}
