using Passes.Models.PassDetail;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Passes.Services
{
    class ApproveDeclinePassService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClientHandler _handler;
        private readonly CookieContainer _cookieContainer;
        public ApproveDeclinePassService()
        {
            _cookieContainer = new CookieContainer();
            _handler = new HttpClientHandler() {CookieContainer = _cookieContainer, UseCookies = true };
            _httpClient = new HttpClient(_handler);
        }

        public async Task<bool> MakeRequest(HandleApproveModel requestModel)
        {
            string baseUrl = await ConfigService.GetBaseURL();
            string targetUrl = $"{baseUrl}api/";
            string sessId = await SecureStorage.GetAsync("PHPSESSID") ?? "";
            _cookieContainer.GetCookies(new Uri(baseUrl)).Clear();
            _cookieContainer.Add(new Uri(baseUrl), new Cookie("PHPSESSID", sessId));

            try
            {
                var content = new MultipartFormDataContent() 
                {
                    { new StringContent(requestModel.id ?? ""),"id"},
                    { new StringContent(requestModel.action ?? ""),"action"},
                    { new StringContent(requestModel.comment ?? ""),"comment"},
                };
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    Content = content,
                };
                using var response = await _httpClient.PostAsync(targetUrl, content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return true;
            }
            catch (Exception ex) {
                await Shell.Current.DisplayAlert("Ошибка", "Ошибка при обработке данных", "OK");
                return false;
            }
            
        }
    }
}
