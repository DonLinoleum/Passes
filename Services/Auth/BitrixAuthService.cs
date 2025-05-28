using Microsoft.Extensions.Configuration;
using Passes.Models.User;
using System.Diagnostics;
using System.Text.Json;
using System.Web;


namespace Passes.Services.Auth
{
    class BitrixAuthService : IAuthService
    {
        static readonly HttpClientHandler handler = new HttpClientHandler 
        {
            CookieContainer = new System.Net.CookieContainer(),
            UseCookies = true,
            AllowAutoRedirect = true
        };
        static readonly HttpClient client = new HttpClient(handler);
        private string? _login;
        private string? _password;

        public BitrixAuthService(string? login, string? password)
        {
            _login = login;
            _password = password;
        }

        public async Task<bool> Auth()
        {
            try
            {
                string baseURL = await ConfigService.GetBaseURL();
                string loginURL = $"{baseURL}bitrix/admin/?login=yes";

                var formData = new MultipartFormDataContent()
             {
                { new StringContent(_login),"USER_LOGIN"},
                { new StringContent(_password),"USER_PASSWORD"},
                { new StringContent("AUTH"),"TYPE"},
                { new StringContent("Y"),"AUTH_FORM"}
             };

                var authResponse = await client.PostAsync(loginURL, formData);
                var cookies = handler.CookieContainer.GetCookies(new Uri(loginURL));
                var phpSessId = cookies["PHPSESSID"]?.Value;
                var mmkUserInfo = cookies["mmk_user_info"]?.Value;
                var mmkUserInfoDecoded = HttpUtility.UrlDecode(mmkUserInfo);
                var userInfo = mmkUserInfoDecoded is not null ? JsonSerializer.Deserialize<UserModel>(mmkUserInfoDecoded) : null;   
                if (!string.IsNullOrEmpty(phpSessId) && !string.IsNullOrEmpty(mmkUserInfo) && userInfo is not null && !string.IsNullOrEmpty(userInfo?.Id))
                    {
                        await SecureStorage.SetAsync("PHPSESSID", phpSessId);
                        await SecureStorage.SetAsync("mmk_user_info", mmkUserInfo);
                        Preferences.Set("mmk_user_info__user_id", userInfo.Id);
                        Preferences.Set("mmk_user_name", userInfo.Name); 
                        Preferences.Set("mmk_user_last_name", userInfo.LastName);
                        Preferences.Set("mmk_user_second_name", userInfo.SecondName);
                        Preferences.Set("mmk_user_work_position", userInfo.WorkPosition);
                        handler.CookieContainer = new System.Net.CookieContainer();
                        return true;
                    }
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return false;
            }
        }
    }
}
