using Microsoft.Extensions.Configuration;


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
                var userId = UserIdService.GetUserIdByJson(mmkUserInfo);
                if (!string.IsNullOrEmpty(phpSessId) && !string.IsNullOrEmpty(mmkUserInfo) && !string.IsNullOrEmpty(userId))
                {
                    await SecureStorage.SetAsync("PHPSESSID", phpSessId);
                    await SecureStorage.SetAsync("mmk_user_info", mmkUserInfo);
                    Preferences.Set("mmk_user_info__user_id", userId);
                    handler.CookieContainer = new System.Net.CookieContainer();
                    return true;
                }
                else
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
