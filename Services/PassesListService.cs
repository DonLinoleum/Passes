using Passes.Models.PassList;
using Passes.ViewModels;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Passes.Services
{
    class PassesListService
    {
        private readonly HttpClient _client;
        private readonly CookieContainer _cookieContainer;
        private readonly HttpClientHandler _handler;

        public PassesListService()
        {
            _cookieContainer = new CookieContainer();
            _handler = new HttpClientHandler()
            {
                CookieContainer = _cookieContainer,
                UseCookies = true
            };
            _client = new HttpClient(_handler);
        }

        public async Task<List<PassListModel>> GetPasses()
        {
            string baseURL = await ConfigService.GetBaseURL();
            string passesURL = $"{baseURL}api/?action=PassesListApprover";
            try
            {       
                string sessid = await SecureStorage.GetAsync("PHPSESSID") ?? "";
                _cookieContainer.GetCookies(new Uri(baseURL)).Clear();
                _cookieContainer.Add(new Uri(baseURL),new Cookie("PHPSESSID", sessid));

                HttpRequestMessage request = new HttpRequestMessage() 
                { 
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(passesURL), 
                };
  
                var response = await _client.SendAsync(request);

                var data = await response.Content.ReadAsStringAsync();
                RootModel root = JsonSerializer.Deserialize<RootModel>(data) ?? new RootModel();
 
                return root.Passes ?? new List<PassListModel>();
            }
            catch (Exception ex)
            {
                return new List<PassListModel>(); 
            }
        }
    }
}
