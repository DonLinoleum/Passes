using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Passes.ViewModels.Helpers
{
    internal class ToTheDetailPass
    {
        public static void GoToTheDetailPass(string? id, string? passNum, string? created)
        {
            var queryParams = new Dictionary<string, string?>() { { "passId", id }, { "passNum",passNum}, { "passCreated", created } };
            Preferences.Set("actualPassNum", passNum);
            Preferences.Set("actualCreatedOfPass", created);
            Shell.Current.GoToAsync($"//PassDetail?QueryData={HttpUtility.UrlEncode(JsonSerializer.Serialize(queryParams))}", true).Wait();
        }
    }
}
