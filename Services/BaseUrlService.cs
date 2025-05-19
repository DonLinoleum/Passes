using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Services
{
    internal class BaseUrlService
    {
        private string _baseUrl;

        public BaseUrlService()
        {
            HandleBaseUrl();
        }
        public async Task HandleBaseUrl()
        {
            _baseUrl =  await ConfigService.GetBaseURL();
        }

        public string GetBaseUrl()
        {
            return _baseUrl;
        }
    }
}
