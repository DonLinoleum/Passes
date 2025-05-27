using Passes.Services.Cookies;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Services
{
    internal class HandleDocumentFileService
    {
        private readonly HttpClient _httpClient;
        private readonly CookieContainer _cookieContainer;
        private readonly HttpClientHandler _httpClientHandler;
        private readonly string _baseUrl;

        public HandleDocumentFileService(string baseUrl)
        {
            _cookieContainer = new CookieContainer();
            _httpClientHandler = new HttpClientHandler()
            {
                CookieContainer = _cookieContainer,
                UseCookies = true
            };
            _httpClient = new HttpClient(_httpClientHandler);
            _baseUrl = baseUrl;
        }

        public async Task SendRequest(string fileUrl, string fileName)
        {
            try
            {
                await AddAuthCookieService.AddAuthCookieFromStorage(_cookieContainer, _baseUrl);
                string finalUrl = $"{_baseUrl}{fileUrl}";

                var fileStream = await _httpClient.GetStreamAsync(finalUrl);
                var filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
                using var file = new FileStream(filePath, FileMode.Create);

                await fileStream.CopyToAsync(file);
                 
                if (File.Exists(filePath))
                {
                    await Launcher.Default.OpenAsync(new OpenFileRequest(fileName, new ReadOnlyFile(filePath)));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Ошибка при открытии файла.", "OK");
                }
            }
            catch (Exception ex) {
               await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
            }

        }
    }
}
