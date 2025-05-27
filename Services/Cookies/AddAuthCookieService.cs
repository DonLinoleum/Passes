using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Services.Cookies
{
    internal class AddAuthCookieService
    {
        public static async Task AddAuthCookieFromStorage(CookieContainer cookieContainer, string baseUrl)
        {
            string sessid = await SecureStorage.GetAsync("PHPSESSID") ?? "";
            cookieContainer.GetCookies(new Uri(baseUrl)).Clear();
            cookieContainer.Add(new Uri(baseUrl), new Cookie("PHPSESSID", sessid));
        }
    }
}
