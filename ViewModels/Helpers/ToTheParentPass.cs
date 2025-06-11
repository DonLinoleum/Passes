using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Passes.ViewModels.Helpers
{
    internal class ToTheParentPass
    {
        public static void GoToTheParentPassOrPassList(string? parentId,string url)
        {
            if (!String.IsNullOrEmpty(parentId))
            {
                string passNum = Preferences.Get("actualPassNum", "");
                string created = Preferences.Get("actualCreatedOfPass", "");
                var queryParams = new Dictionary<string, string?>() { { "passId", parentId }, { "passNum", passNum }, { "passCreated", created } };
                Shell.Current.GoToAsync("//PassesList").Wait();
                Shell.Current.GoToAsync($"//PassDetail?QueryData={HttpUtility.UrlEncode(JsonSerializer.Serialize(queryParams))}", true).Wait();
            }
            else
                Shell.Current.GoToAsync(url).Wait();
        }
    }
}
