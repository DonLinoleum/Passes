using Passes.Services.Cookies;
using Passes.Services.HttpRequests;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Web;

namespace Passes.Services.HttpRequestsGet
{
    internal abstract class AbstractHttpGetRequest<T> : IHttpGetRequest<T>
    {
        protected readonly HttpClient _httpClient;
        protected readonly HttpClientHandler _handler;
        protected readonly CookieContainer _cookieContainer;
        protected readonly string _actionName;
        protected readonly string _baseUrl;
        protected string _passId;

        public string PassId { get => _passId; set { _passId = value; } }

        public AbstractHttpGetRequest(string actionName, string baseUrl, string passId = "")
        {
            _cookieContainer = new CookieContainer();
            _handler = new HttpClientHandler()
            {
                UseCookies = true,
                CookieContainer = _cookieContainer
            };
            _httpClient = new HttpClient(_handler);
            _actionName = actionName;
            _baseUrl = baseUrl;
            _passId = passId;
        }

        public async Task<T?> GetData()
        {
            try
            {
                UriBuilder uriBuilder = PrepareRequestUri();
                await AddAuthCookieService.AddAuthCookieFromStorage(_cookieContainer, _baseUrl);

                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = uriBuilder.Uri,
                };
                var response = await _httpClient.SendAsync(request); 
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

        public virtual UriBuilder PrepareRequestUri()
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
