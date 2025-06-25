using Passes.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Services.HttpRequestsPost
{
    class SendProfileService
    {
        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;
        private CookieContainer _cookieContainer;

        public SendProfileService()
        {
            _cookieContainer = new CookieContainer();
            _httpClientHandler = new HttpClientHandler() { CookieContainer = _cookieContainer, UseCookies = true };
            _httpClient = new HttpClient(_httpClientHandler);
        }

        public async Task<bool> MakeRequest(ProfileModel model)
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
                    { new StringContent(Preferences.Get("mmk_user_info__user_id","")),"USER_ID"},
                    { new StringContent("Mobile\\UpdateProfile"),"action"},
                    { new StringContent(model?.LastName ?? ""),"LAST_NAME" },
                    { new StringContent(model?.Name ?? ""),"NAME" },
                    { new StringContent(model?.SecondName ?? ""),"SECOND_NAME" },
                    { new StringContent(model?.WorkRoom ?? ""),"WORK_ROOM" },
                    { new StringContent(model?.PersonalPhone ?? ""),"PERSONAL_PHONE" },
                    { new StringContent(model?.WorkPosition ?? ""),"WORK_POSITION" },
                    { new StringContent(model?.WorkDepartment ?? ""),"WORK_DEPARTMENT" },
                    { new StringContent(model?.WorkProfile ?? ""),"WORK_PROFILE" },
                    { new StringContent(model?.EmployeeId ?? ""),"EMPLOYEE_ID" },
                };
                using var response = await _httpClient.PostAsync(targetUrl, content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());
                return true;
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Ошибка при обработке данных", "OK");
                return false;
            }
        }
    }
}
