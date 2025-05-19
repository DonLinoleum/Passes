using Passes.Models.PassList;
using Passes.Services;
using Passes.Services.HttpRequests;
using Passes.Services.HttpRequestsGet.HttpRequestsGetList;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels.Helpers
{
   public class AllPassesListHelper
    {
        private IHttpGetRequest<RootPassesModel>? _passesListService;
        private string _baseUrl;

        public AllPassesListHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
            _passesListService = new PassesListService<RootPassesModel>("PassesListApprover", baseUrl);
        }

        public async Task<List<PassListModel>>? GetAllPasses()
        {
            try
            {
                RootPassesModel? passes =  await _passesListService.GetData();
                return passes?.Passes ?? new List<PassListModel>();
            }
            catch (Exception ex) {
                await Shell.Current.DisplayAlert("Ошибка", "Ошибка загрузки данных", "OK");
                return new List<PassListModel>();
            }
        }
    }
}
