
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.Models.PassList;
using Passes.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Passes.ViewModels
{
    [QueryProperty(nameof(PassId),"passId")]
    public partial class PassDetailViewModel : ObservableObject
    {
        private string? _passId;

        [ObservableProperty]
        private string? passIdObservable;

        public string PassId 
        {
            get => _passId ?? "";
            set
            {
                _passId = value;
                PassIdObservable = value;
            }
        }


        [RelayCommand]
        public async void GoBack()
        {
            await Shell.Current.GoToAsync("//PassesList");
        }

        [RelayCommand]
        public async Task Exit()
        {
            SecureStorage.Remove("PHPSESSID");
            await Shell.Current.GoToAsync("//AuthPage");
        }
    }
}
