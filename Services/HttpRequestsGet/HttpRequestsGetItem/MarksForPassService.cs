using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Passes.Services.HttpRequestsGet.HttpRequestsGetItem
{
    class MarksForPassService<T> : AbstractHttpGetRequest<T>
    {
        public MarksForPassService(string actionName, string baseUrl, string passId)
            : base(actionName, baseUrl, passId)
        { }

        public override UriBuilder PrepareRequestUri()
        {
            UriBuilder uriBuilder = new UriBuilder($"{_baseUrl}/api");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["action"] = _actionName;
            query["pass_id"] = _passId;
            uriBuilder.Query = query.ToString();
            return uriBuilder;
        }
    }
}
