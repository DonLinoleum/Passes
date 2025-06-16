using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Passes.ViewModels.Helpers
{
    public class DecodeInputQueryForPassHelper
    {
        public static Dictionary<string,string>? DecodeQueryData(string inputEncodedJson)
        {
            string decodedString = HttpUtility.UrlDecode(inputEncodedJson);
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(decodedString);
            return data;
        }
    }
}
