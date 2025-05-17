using Passes.Models.PassDetail;
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
    class PassDetailService<T> : AbstractHttpGetRequest<T>
    {
        public PassDetailService(string actionName, string baseUrl, string passId)
            : base (actionName, baseUrl,  passId)
        { 
        }
    }
}
