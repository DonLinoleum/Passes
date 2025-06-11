using Passes.Models.PassDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Passes.ViewModels.Helpers
{
    internal class ToTheChildPass
    {
        public static void GoToTheChildPass(object childModelPass,string? parentPassId)
        {
            var (passId, passNum) = childModelPass switch
            {
                VehiclesChildren vehiclePass => (vehiclePass.PassId,vehiclePass.PassNum),
                VisitorsChildren visitorPass => (visitorPass.PassId,visitorPass.PassNum),
                _ => ("","")
            };
 
             string created = Preferences.Get("actualCreatedOfPass", "");
             var queryParams = new Dictionary<string, string?>() { { "passId", passId }, { "passNum", passNum }, { "passCreated", created }, { "parentPassId", parentPassId } };
             Shell.Current.GoToAsync("//PassesList").Wait();
             Shell.Current.GoToAsync($"//PassDetail?QueryData={HttpUtility.UrlEncode(JsonSerializer.Serialize(queryParams))}", true).Wait();
        }
    }
}
