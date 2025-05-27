using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Services.HttpRequests
{
    interface IHttpGetRequest<T>
    {
        Task<T?> GetData();
        UriBuilder PrepareRequestUri();

        string PassId { get; set; }
    }
}
