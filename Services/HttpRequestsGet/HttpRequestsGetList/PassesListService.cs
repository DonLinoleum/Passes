using Passes.Models.PassList;
using Passes.Services.HttpRequests;
using Passes.ViewModels;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Web;

namespace Passes.Services.HttpRequestsGet.HttpRequestsGetList
{
    class PassesListService<T> : AbstractHttpGetRequest<T>
    {

        public PassesListService(string actionName, string baseUrl, string? passId = null)
            : base(actionName, baseUrl, passId)
        {     }
    }
}
