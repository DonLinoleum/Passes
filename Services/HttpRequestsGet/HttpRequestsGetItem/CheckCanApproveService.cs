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


namespace Passes.Services.HttpRequestsGet.HttpRequestsGetItem
{
    class CheckCanApproveService<T> : AbstractHttpGetRequest<T>
    {
        public CheckCanApproveService(string actionName, string baseUrl, string passId):
            base(actionName, baseUrl, passId)
        { }

        public override async Task AddCookies()
        {
            string sessid = await SecureStorage.GetAsync("PHPSESSID") ?? "";
            string mmk_user_info = await SecureStorage.GetAsync("mmk_user_info") ?? "";
            _cookieContainer.GetCookies(new Uri(_baseUrl)).Clear();
            _cookieContainer.Add(new Uri(_baseUrl), new Cookie("PHPSESSID", sessid));
            _cookieContainer.Add(new Uri(_baseUrl), new Cookie("mmk_user_info", mmk_user_info));
        }
    }
}
