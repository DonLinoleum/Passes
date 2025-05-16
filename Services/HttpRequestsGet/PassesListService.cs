using Passes.Models.PassList;
using Passes.Services.HttpRequests;
using Passes.ViewModels;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Web;

namespace Passes.Services
{
    class PassesListService<T> : IHttpGetRequest<T>
    {
        private readonly HttpClient _client;
        private readonly CookieContainer _cookieContainer;
        private readonly HttpClientHandler _handler;
        private readonly string _actionName;
        private readonly string _baseUrl;
  
        public PassesListService(string actionName, string baseUrl)
        {
            _cookieContainer = new CookieContainer();
            _handler = new HttpClientHandler()
            {
                CookieContainer = _cookieContainer,
                UseCookies = true
            };
            _client = new HttpClient(_handler);
            _actionName = actionName;
            _baseUrl = baseUrl;
        }

        public async Task<T?> GetData()
        {
            try
            {
                UriBuilder uriBuilder = PrepareRequestUri();
                string sessid = await SecureStorage.GetAsync("PHPSESSID") ?? "";
                _cookieContainer.GetCookies(new Uri(_baseUrl)).Clear();
                _cookieContainer.Add(new Uri(_baseUrl),new Cookie("PHPSESSID", sessid));
 
                HttpRequestMessage request = new HttpRequestMessage() 
                { 
                    Method = HttpMethod.Get,
                    RequestUri = uriBuilder.Uri,  
                };
  
                var response = await _client.SendAsync(request);
                var data = await response.Content.ReadAsStringAsync();
                T? result = JsonSerializer.Deserialize<T>(data);
                return result;
            }
            catch (Exception ex)
            {
                return default; 
            }
        }

        public UriBuilder PrepareRequestUri()
        {
            UriBuilder uriBuilder = new UriBuilder($"{_baseUrl}/api");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["action"] = _actionName;
            uriBuilder.Query = query.ToString();
            return uriBuilder;
        } 
    }
}
