using Passes.Models.PassList;
using Passes.Services;
using Passes.Services.HttpRequests;
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

        public AllPassesListHelper()
        { }

        public async Task<List<PassListModel>>? GetAllPasses()
        {
            var baseUrl = await ConfigService.GetBaseURL();
            _passesListService = new PassesListService<RootPassesModel>("PassesListApprover", baseUrl);
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
