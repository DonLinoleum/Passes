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
        protected readonly string _passId;

        public AbstractHttpGetRequest(string actionName, string baseUrl, string passId)
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
                await AddCookies();

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

        public UriBuilder PrepareRequestUri()
        {
            UriBuilder uriBuilder = new UriBuilder($"{_baseUrl}/api");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["action"] = _actionName;
            query["passId"] = _passId;
            uriBuilder.Query = query.ToString();
            return uriBuilder;
        }

        public virtual async Task AddCookies()
        {
            string sessid = await SecureStorage.GetAsync("PHPSESSID") ?? "";
            _cookieContainer.GetCookies(new Uri(_baseUrl)).Clear();
            _cookieContainer.Add(new Uri(_baseUrl), new Cookie("PHPSESSID", sessid));
        }
    }
}
