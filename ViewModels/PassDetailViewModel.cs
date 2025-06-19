
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.Models.PassDetail;
using Passes.Services;
using Passes.Services.HttpRequests;
using Passes.Services.HttpRequestsGet.HttpRequestsGetItem;
using Passes.ViewModels.Helpers;
using Passes.ViewModels.States;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Passes.ViewModels
{
    [QueryProperty(nameof(QueryData), "QueryData")]
    public partial class PassDetailViewModel : ObservableObject
    {
        private IHttpGetRequest<CheckCanApproveModel> _checkCanApprove;
        private IHttpGetRequest<RootPassDetailModel> _passDetailService;
        private IHttpGetRequest<ApproveProgressMarksModel> _passListApproveProgressMarksService;
        private IHttpGetRequest<MarksForPassModel> _marksForPass;

        private ActionOnDetailState _detailState;
        private readonly ApproveDeclinePassService _approveDeclinePassService;
        private readonly GetDocumentFromServerHelper _getDocumentFromServerHelper;

        private string? _queryData;
        private string _baseUrl;
        private string _passNum;
        private double _maxHeightDrawer;
        private string? _parentPassId;

        [ObservableProperty]
        private string? passIdInputProp;

        [ObservableProperty]
        private string? passNumInputProp;

        [ObservableProperty]
        private string? passDateInputProp;

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
        private List<string>? idsOfServicePassesCanApprove;

        //drawers
        [ObservableProperty]
        private bool? approveDeclineDrawerVisible = false;

        [ObservableProperty]
        private bool? approveProgressDrawerVisible = false;

        [ObservableProperty]
        private bool? marksDrawerVisible = false;

        [ObservableProperty]
        private bool? isDrawerLoading = false;

        [ObservableProperty]
        private double drawerTranslateYTo = 750;

        [ObservableProperty]
        private double drawerMarksHeight = 150;

        [ObservableProperty]
        private double drawerProgressHeight = 150;

        //
        [ObservableProperty]
        private bool? isNegotiatorIsUser = false;

        [ObservableProperty]
        private ApproveProgressMarksModel? passProgress;

        [ObservableProperty]
        private MarksForPassModel? passMarks;

        [ObservableProperty]
        private ObservableCollection<PassDetailModel> passData;

        [ObservableProperty]
        private HashSet<string> childrenPassesToApprove = new HashSet<string>();

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
            _marksForPass = new MarksForPassService<MarksForPassModel>("GetTimelineItems", _baseUrl!, PassIdInputProp ?? "");
            _detailState = new ActionOnDetailState();
            _approveDeclinePassService = new ApproveDeclinePassService();
            _maxHeightDrawer = ElementHeightHelper.GetHeight();
            _getDocumentFromServerHelper = new GetDocumentFromServerHelper(_baseUrl);
        }
        private async Task Init(string queryDataToParse)
        {
            var decodedInputQuery = DecodeInputQueryForPassHelper.DecodeQueryData(queryDataToParse);
            PassIdInputProp = decodedInputQuery?["passId"];
            PassNumInputProp = decodedInputQuery?["passNum"];
            PassDateInputProp = decodedInputQuery?["passCreated"];
            _parentPassId = decodedInputQuery?.TryGetValue("parentPassId", out string? value) == true ? value : null;
           
            _passDetailService.PassId = PassIdInputProp;
            _checkCanApprove.PassId = PassIdInputProp;
            _passListApproveProgressMarksService.PassId = PassIdInputProp;
            _marksForPass.PassId = PassIdInputProp;
            await LoadPassData();
            await GetApproveProgressForPass();
            await GetMarksForPass();
        }
        [RelayCommand]
        public async Task LoadPassData()
        {
            await Task.Run(async () =>
            {
                IsLoading = true;
                await GetPassDataById();
                var canApproveData = await _checkCanApprove.GetData();
                CanApprove = canApproveData?.Data?.ShowApproveButton;
                IdsOfServicePassesCanApprove = canApproveData?.Data?.IdsOfChildrenPassesCanApprove ?? new List<string>();
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
        public void GoBackByBottomMenu(string url) => ToTheParentPass.GoToTheParentPassOrPassList(_parentPassId, url); 
 
        [RelayCommand]
        public void Exit() => ExitHandlerHelper.GoToAuthPage();

        [RelayCommand]
        public void GoToChildPass(object childModelPass) => ToTheChildPass.GoToTheChildPass(childModelPass, PassData[0].id);

        [RelayCommand]
        public void AddChildPassToApproveList(string passId)
        {
            if (!ChildrenPassesToApprove.Contains(passId))
                ChildrenPassesToApprove?.Add(passId);
            else
                ChildrenPassesToApprove.Remove(passId);
        }

        [RelayCommand]
        public async Task ToogleDrawer(string? Params = "")
        {
            MainContentOpacity = !MainContentOpacity;
            var targetHeight = PassDetailDrawerHeights.HeightOfDrawerEnabledOrDisabled(DrawerTranslateYTo);
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                var animation = new Animation(callback: v => DrawerTranslateYTo = v, start: DrawerTranslateYTo, end: targetHeight, easing: Easing.CubicInOut);
                Application.Current?.Windows[0].Page.Animate(
                name: "DrawerAnimation",
                animation: animation,
                rate: 16,
                length: 400,
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
                await Shell.Current.DisplayAlert("Ошибка", "При отказе необходимо указать причину отказа.", "OK");
            else
            {
                IsSending = true;
                HandleApproveModel body = new HandleApproveModel()
                {
                    id = PassIdInputProp,
                    action = _detailState?.ActionName,
                    comment = CommentFromEditor,
                    child_ids = ChildrenPassesToApprove.ToList(),
                };
                ApproveDeclinePassService approveDeclinePassService = new ApproveDeclinePassService();
                bool isResponseSuccess = await approveDeclinePassService.MakeRequest(body);
                IsSending = false;
                await ToogleDrawer();
                CommentFromEditor = "";
                if (isResponseSuccess) await Shell.Current.DisplayAlert("Статус изменен", $"Статус заявки {_passNum} изменен", "OK");
                ChildrenPassesToApprove?.Clear();
                GoBackByBottomMenu("//PassesList?need_update=true");
            }
        }

        [RelayCommand]
        public async Task ShowDocument (string? parameters) => await _getDocumentFromServerHelper.GetDocumentFromServer(parameters);
 
        private async Task HandleDrawersBySelection(string? selectedDrawer)
        {
            ApproveDeclineDrawerVisible = false;
            ApproveProgressDrawerVisible = false;
            MarksDrawerVisible = false;
            switch (selectedDrawer)
            {
                case SelectedDrawerState.ApproveDeclineDrawer:
                    ApproveDeclineDrawerVisible = true;
                    break;
                case SelectedDrawerState.ApproveProgressDrawer:
                        ApproveProgressDrawerVisible = true;
                        IsDrawerLoading = true;
                        PassProgress = await GetApproveProgressForPass() ?? new ApproveProgressMarksModel();
                        IsDrawerLoading = false;
                    break;
                case SelectedDrawerState.MarksDrawer:
                        MarksDrawerVisible = true;
                        IsDrawerLoading = true;
                        PassMarks = await GetMarksForPass() ?? new MarksForPassModel();
                        IsDrawerLoading = false;
                    break;
            }
        }

        [RelayCommand]
        public async Task ShowApproveProgressComment(string? comment)
        {
            if (!String.IsNullOrEmpty(comment))
                await Shell.Current.DisplayAlert("Комментарий", comment, "Отмена");
        }
        private async Task<MarksForPassModel> GetMarksForPass()
        {
            var passMarksData = await _marksForPass.GetData();
            passMarksData?.Movement?.Reverse();
            DrawerMarksHeight = PassDetialService.CalculateMarksDrawerHeight(passMarksData!.PrintMark!.Count, passMarksData!.Movement!.Count, PassDetailDrawerHeights.PassMarksElementHeight, PassData[0].pass_type_id, _maxHeightDrawer);
            return passMarksData;
        }
        private async Task<ApproveProgressMarksModel?> GetApproveProgressForPass()
        {
            var passProgressData = await _passListApproveProgressMarksService.GetData();
            if (passProgressData?.Negotiators is not null)
                DrawerProgressHeight = PassDetialService.CalculateApproveProgressDrawerHeight(passProgressData.Negotiators.Count, passProgressData.Mol is not null, PassDetailDrawerHeights.PassApproveProgressElementHeight,_maxHeightDrawer);
            return passProgressData;
        }
    }
}
