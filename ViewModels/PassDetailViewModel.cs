
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.Models.PassList;
using Passes.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Web;

namespace Passes.ViewModels
{
    [QueryProperty(nameof(QueryData), "QueryData")]
    public partial class PassDetailViewModel : ObservableObject
    {
        private string _queryData;

        [ObservableProperty]
        private string? passIdInputProp;

        [ObservableProperty]
        private string? passNumInputProp;

        [ObservableProperty]
        private string? passDateInputProp;

        public string QueryData
        {
            get => _queryData;
            set {_queryData = value;DecodeQueryData(value);}
        }

        private void DecodeQueryData(string inputEncodedJson)
        {
            string decodedString = HttpUtility.UrlDecode(inputEncodedJson);
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(decodedString);
            PassIdInputProp = data?["passId"];
            PassNumInputProp = data?["passNum"];
            PassDateInputProp = data?["passDate"];
        }

      


        [RelayCommand]
        public async void GoBack()
        {
            await Shell.Current.GoToAsync("//PassesList?need_update=true");
        }

        [RelayCommand]
        public async Task Exit()
        {
            SecureStorage.Remove("PHPSESSID");
            await Shell.Current.GoToAsync("//AuthPage");
        }
    }
}
