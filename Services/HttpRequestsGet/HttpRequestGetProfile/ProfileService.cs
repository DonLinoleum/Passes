using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Services.HttpRequestsGet.HttpRequestGetProfile
{
    class ProfileService<T> : AbstractHttpGetRequest<T>
    {
        public ProfileService(string actionName, string baseUrl)
            : base(actionName, baseUrl)
        { }
    }
}
