using Passes.Models.PassList;
using Passes.Services;
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
        private readonly PassesListService _passesListService;

        public AllPassesListHelper()
        {
            _passesListService = new PassesListService();
        }

        public async Task<List<PassListModel>> GetAllPasses()
        {
            try
            {
                return await _passesListService.GetPasses();
            }
            catch (Exception ex) {
                await Shell.Current.DisplayAlert("Ошибка", "Ошибка загрузки данных", "OK");
                return new List<PassListModel>();
            }
        }
    }
}
