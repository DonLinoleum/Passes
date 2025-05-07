

using Passes.Models;
using System.Text.Json;

namespace Passes.Services
{
    class PassesListService
    {
        static readonly HttpClient client = new HttpClient();
        public PassesListService()
        {}

        public async Task<List<PassModel>> GetPasses()
        {
            string baseURL = await ConfigService.GetBaseURL();
            string passesURL = $"{baseURL}api/?action=PassesListApprover";
            try
            {
                var request = new HttpRequestMessage() 
                { 
                    RequestUri = new Uri(passesURL),
                    Method = HttpMethod.Get
                };
                string sessid = await SecureStorage.GetAsync("PHPSESSID") ?? "";
                request.Headers.Add("Cookie", $"PHPSESSID={sessid}");
                var response = await client.SendAsync(request);
                var data = await response.Content.ReadAsStringAsync();
                RootModel root = JsonSerializer.Deserialize<RootModel>(data) ?? new RootModel();
                return root.Passes;
            }
            catch (Exception ex)
            {
                return new List<PassModel>(); 
            }
        }
    }
}
