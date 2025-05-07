

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.Models;
using Passes.Services;
using System.Collections.ObjectModel;


namespace Passes.ViewModels
{
   public partial class PassesViewModel : ObservableObject
    {
        private readonly PassesListService _passesListService;

        [ObservableProperty]
        private ObservableCollection<PassModel> passes;
        public PassesViewModel()
        {
            _passesListService = new PassesListService();
            LoadPasses();
        }

        [RelayCommand]
        public async void LoadPasses()
        {
            var passesList = await _passesListService.GetPasses();
            foreach (var item in passesList)
            {
                Console.WriteLine(item);
            }
            Passes = new ObservableCollection<PassModel>(passesList);
        }
    }
}
