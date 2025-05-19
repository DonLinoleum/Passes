
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.Models.PassDetail;
using Passes.Services;
using Passes.Services.HttpRequests;
using Passes.Services.HttpRequestsGet.HttpRequestsGetItem;
using Passes.ViewModels.States;
using System.Buffers.Text;
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
        private IHttpGetRequest<CheckCanApproveModel> _checkCanApprove;
        private IHttpGetRequest<RootPassDetailModel> _passDetailService;
        private IHttpGetRequest<ApproveProgressMarksModel> _passListApproveProgressMarksService;
        private string _baseUrl;
        private string _passNum;

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
        private bool? canApprove;

        [ObservableProperty]
        private bool? approveDeclineDrawerVisible = false;

        [ObservableProperty]
        private bool? approveProgressDrawerVisible = false;

        [ObservableProperty]
        private bool? isDrawerLoading = false;

        [ObservableProperty]
        private bool? isNegotiatorIsUser = false;

        [ObservableProperty]
        private ApproveProgressMarksModel? passProgress;

        [ObservableProperty]
        private Color? statusMarkColor;

        [ObservableProperty]
        private ObservableCollection<PassDetailModel> passData;

        public string QueryData
        {
            get => _queryData ?? "";
            set 
            {
                _queryData = value;
                Init(value);
            }
        }

        public PassDetailViewModel() 
        {
            _baseUrl = (new BaseUrlService()).GetBaseUrl();
            _passDetailService = new PassDetailService<RootPassDetailModel>("GetPassById", _baseUrl!, PassIdInputProp ?? "");
            _checkCanApprove = new CheckCanApproveService<CheckCanApproveModel>("CheckCanApprovePass", _baseUrl!, PassIdInputProp ?? "");
            _passListApproveProgressMarksService = new PassListApproveProgressMarksService<ApproveProgressMarksModel>("ApproversForPassById", _baseUrl!, PassIdInputProp ?? "");
            _detailState = new ActionOnDetailState();
            _approveDeclinePassService = new ApproveDeclinePassService();
        }

        private async Task Init(string queryDataToParse)
        {
            await DecodeQueryData(queryDataToParse);
            _passDetailService.PassId = PassIdInputProp;
            _checkCanApprove.PassId = PassIdInputProp;
            _passListApproveProgressMarksService.PassId = PassIdInputProp;
            await LoadPassData();
        }

        [RelayCommand]
        public async Task LoadPassData()
        {
            await Task.Run(async () => {
                IsLoading = true;
                await GetPassDataById();
                CanApprove = (await _checkCanApprove.GetData())?.Result;
                IsLoading = false;
            });
        }

        [RelayCommand]
        public async Task GetPassDataById()
        {
            var passData = await _passDetailService.GetData();
            _passNum = passData?.Pass?.pass_num ?? "";
            if (passData is not null && passData.Pass is not null)
                PassData = new ObservableCollection<PassDetailModel> { passData.Pass }; 
        }

        [RelayCommand]
        public async void GoBack(string url)
        {
            await Shell.Current.GoToAsync(url);
        }

        [RelayCommand]
        public async Task Exit()
        {
            SecureStorage.Remove("PHPSESSID");
            await Shell.Current.GoToAsync("//AuthPage");
        }

        [RelayCommand]
        public async Task ToogleDrawer(string? Params = "")
        {
            MainContentOpacity = !MainContentOpacity;
            var targetHeight = DrawerHeight == 0 ? 380 : 0;
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                var animation = new Animation(callback: v => DrawerHeight = v,start: DrawerHeight,end: targetHeight,easing: Easing.CubicInOut);
                Application.Current.MainPage.Animate(
                name: "DrawerAnimation",
                animation: animation,
                rate: 16,
                length: 300,
                finished: (v, c) => { }
                );
            });
            if (!string.IsNullOrEmpty(Params))
            {
                var paramsParts = Params?.Split(',');
                if (paramsParts?[0] is not null) _detailState.ActionName = paramsParts[0];
                if (paramsParts?[1] is not null) await HandleDrawersBySelection(paramsParts[1]);
            }
        }

        [RelayCommand]
        public async Task HandleApprovementPass()
        {
            if (_detailState?.ActionName == ActionOnDetailState.DeclinePass && string.IsNullOrEmpty(CommentFromEditor))
               await Shell.Current.DisplayAlert("Ошибка","При отказе необходимо указать причину отказа.","OK");
            else
            {
                IsSending = true;
                HandleApproveModel body = new HandleApproveModel()
                {
                    id = PassIdInputProp,
                    action = _detailState?.ActionName,
                    comment = CommentFromEditor
                };
                ApproveDeclinePassService approveDeclinePassService = new ApproveDeclinePassService();
                bool isResponseSuccess = await approveDeclinePassService.MakeRequest(body);
                IsSending = false;
                await ToogleDrawer();
                CommentFromEditor = "";
                if (isResponseSuccess) await Shell.Current.DisplayAlert("Статус изменен", $"Статус заявки {_passNum} изменен", "OK");
                GoBack("//PassesList?need_update=true");
            }
        }

        private async Task DecodeQueryData(string inputEncodedJson)
        {
            string decodedString = HttpUtility.UrlDecode(inputEncodedJson);
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(decodedString);
            PassIdInputProp = data?["passId"];
            PassNumInputProp = data?["passNum"];
            PassDateInputProp = data?["passCreated"];
        }

        private async Task HandleDrawersBySelection(string? selectedDrawer)
        {
            ApproveDeclineDrawerVisible = false;
            ApproveProgressDrawerVisible = false;
            switch (selectedDrawer)
            {
                case SelectedDrawerState.ApproveDeclineDrawer:
                    ApproveDeclineDrawerVisible = true;
                    break;
                case SelectedDrawerState.ApproveProgressDrawer:
                    await Task.Run(async () => {
                        ApproveProgressDrawerVisible = true;
                        IsDrawerLoading = true;
                        var passProgressData = await _passListApproveProgressMarksService.GetData();
                        PassProgress = passProgressData ?? new ApproveProgressMarksModel();
                        IsDrawerLoading = false;
                    });
                    break;
            }
        }
    }
}
