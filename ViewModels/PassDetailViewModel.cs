
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.Models.PassDetail;
using Passes.Services;
using Passes.Services.HttpRequests;
using Passes.ViewModels.States;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Web;


namespace Passes.ViewModels
{
    [QueryProperty(nameof(QueryData), "QueryData")]
    public partial class PassDetailViewModel : ObservableObject
    {
        private string? _queryData;
        private ActionOnDetailState _detailState;
        private readonly ApproveDeclinePassService _approveDeclinePassService;
        private IHttpGetRequest<RootPassDetailModel> _passDetailService;

        [ObservableProperty]
        private string? passIdInputProp;

        [ObservableProperty]
        private string? passNumInputProp;

        [ObservableProperty]
        private string? passDateInputProp;

        [ObservableProperty]
        private double drawerHeight = 380;

        [ObservableProperty]
        private bool mainContentOpacity = false;

        [ObservableProperty]
        private bool isSending = false;

        [ObservableProperty]
        private string? commentFromEditor;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private ObservableCollection<PassDetailModel> passData;

        public string QueryData
        {
            get => _queryData ?? "";
            set 
            {
                _queryData = value;
                DecodeQueryData(value);
            }
        }

        [RelayCommand]
        public async Task GetPassDataById()
        {
            var passData = await _passDetailService.GetData();
            if (passData is not null && passData.Pass is not null)
                PassData = new ObservableCollection<PassDetailModel> { passData.Pass };
        }

        public PassDetailViewModel() 
        { 
            _detailState = new ActionOnDetailState();
            _approveDeclinePassService = new ApproveDeclinePassService();          
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

        [RelayCommand]
        public async Task ToogleDrawer(string? ActionName = "")
        {
            _detailState.ActionName = ActionName;
            MainContentOpacity = !MainContentOpacity;
            var targetHeight = DrawerHeight == 0 ? 380 : 0;
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                var animation = new Animation
                (
                    callback: v => DrawerHeight = v,
                    start: DrawerHeight,
                    end: targetHeight,
                    easing: Easing.CubicInOut
                );
                Application.Current.MainPage.Animate(
                name: "DrawerAnimation",
                animation: animation,
                rate: 16,
                length: 300,
                finished: (v, c) => { }
                );
            });
        }

        [RelayCommand]
        public async Task HandleApprovementPass()
        {
            IsSending = true;
            HandleApproveModel body = new HandleApproveModel() 
            {
                id = PassIdInputProp, 
                action = _detailState.ActionName,
                comment = CommentFromEditor
            };
                ApproveDeclinePassService approveDeclinePassService = new ApproveDeclinePassService();
                bool isResponseSuccess = await approveDeclinePassService.MakeRequest(body);
                IsSending = false;
                await ToogleDrawer();
                CommentFromEditor = "";
                if (isResponseSuccess) await Shell.Current.DisplayAlert("Статус изменен", $"Статус заявки {PassIdInputProp} изменен", "OK");
        }

        private async Task DecodeQueryData(string inputEncodedJson)
        {
            string decodedString = HttpUtility.UrlDecode(inputEncodedJson);
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(decodedString);
            PassIdInputProp = data?["passId"];
            PassNumInputProp = data?["passNum"];
            PassDateInputProp = data?["passCreated"];
            await LoadPassData();
        }

        private async Task LoadPassData()
        {
            IsLoading = true;
            var baseUrl = await ConfigService.GetBaseURL();
            _passDetailService = new PassDetailService<RootPassDetailModel>("GetPassById", baseUrl, PassIdInputProp ?? "");
            await GetPassDataById();
            IsLoading = false;
        }


    }
}
