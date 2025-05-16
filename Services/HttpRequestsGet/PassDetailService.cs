using Passes.Models.PassDetail;
using Passes.Services.HttpRequests;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Passes.Services
{
    class PassDetailService<T> : IHttpGetRequest<T>
    {
        private readonly HttpClient _client;
        private readonly CookieContainer _cookieContainer;
        private readonly HttpClientHandler _handler;
        private readonly string _actionName;
        private readonly string _baseUrl;
        private readonly string _passId;

        public PassDetailService(string actionName, string baseUrl, string passId)
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
            _passId = passId;
        }

        public async Task<T?> GetData()
        {
            try
            {
                UriBuilder uriBuilder = PrepareRequestUri();
                string sessid = await SecureStorage.GetAsync("PHPSESSID") ?? "";
                _cookieContainer.GetCookies(new Uri(_baseUrl)).Clear();
                _cookieContainer.Add(new Uri(_baseUrl), new Cookie("PHPSESSID", sessid));

                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = uriBuilder.Uri,
                };
                var response = await _client.SendAsync(request);
                var data = await response.Content.ReadAsStringAsync();        
                T? result = JsonSerializer.Deserialize<T?>(data);
                return result; 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return default;
            }
        }

        public UriBuilder PrepareRequestUri()
        {
            UriBuilder uriBuilder = new UriBuilder($"{_baseUrl}/api");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["action"] = _actionName;
            query["passId"] = _passId;
            uriBuilder.Query = query.ToString();
            return uriBuilder;
        }
    }
}
