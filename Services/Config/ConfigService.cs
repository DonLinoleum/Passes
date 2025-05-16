using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Passes.Services
{
    class ConfigService
    {
        public static async Task<string> GetBaseURL()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("config.json");
            using var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();

            var config = JsonSerializer.Deserialize<BaseUrl>(contents);
            return config.baseURL;
        }  
    }

    public class BaseUrl
    {
        public string? baseURL { get; set; }
    }
}
