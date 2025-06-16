using Passes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels.Helpers
{
    public class GetDocumentFromServerHelper
    {
        private readonly HandleDocumentFileService _handleDocumentFileService;
        public GetDocumentFromServerHelper(string baseUrl)
        {
            this._handleDocumentFileService = new HandleDocumentFileService(baseUrl);
        }
        public async Task GetDocumentFromServer(string? parameters) 
        {
            string[]? splitParams = parameters?.Split(',');
            string? path = splitParams?[0];
            string? fileName = splitParams?[1];
            if (path is not null && fileName is not null)
               await _handleDocumentFileService.SendRequest(path, fileName);
        }
    }
}
