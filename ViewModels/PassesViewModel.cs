using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using Passes.Models.PassList;
using Passes.Services;
using Passes.Services.Auth;
using Passes.ViewModels.Helpers;
using Passes.ViewModels.States;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Text.Json;
using System.Web;

namespace Passes.ViewModels
{
    [QueryProperty(nameof(IsNeedUpdate), "need_update")]
   public partial class PassesViewModel : ObservableObject
    {
        private bool _isNeedUpdate = false;

        [ObservableProperty]
        private ObservableCollection<PassListModel> passes;

        [ObservableProperty]
        private ObservableCollection<PassListModel> filteredPasses;

        [ObservableProperty]
        private ObservableCollection<string> passStateFilterItems;

        [ObservableProperty]
        private ObservableCollection<string> passTypeFilterItems;

        [ObservableProperty]
        private bool hasNoPasses = false;

        [ObservableProperty]
        private bool isLoading = false;

        [ObservableProperty]
        private bool isRefreshing = false;

        [ObservableProperty]
        private double filterLoadingProgress = 0.0;

        //filters
        [ObservableProperty]
        private string? findInput;

        [ObservableProperty]
        private double filterHeight = 380;

        [ObservableProperty]
        private bool filterOpacity = false;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(OpacityHasFilters))]
        private int filterCount;

        [ObservableProperty]
        private string? passTypeFilterInput;

        [ObservableProperty]
        private string? passStateFilterInput;

        [ObservableProperty]
        private int filterApplyingProgresBarScale = 0;

        [ObservableProperty]
        private Color findBgColor = Color.FromArgb("#2056ae");

        private AllPassesListHelper _allPassesListHelper;
        private bool _hasSearched = false;
        private bool _hasFilteredByType = false;
        private bool _hasFilteredByState = false;
        private string _baseUrl;

        public bool IsNeedUpdate { get => _isNeedUpdate; 
            set 
            { 
                _isNeedUpdate = value;
                Init(_isNeedUpdate);  
            } 
        }

        private async Task Init(bool isNeedUpdate)
        {
            if (_isNeedUpdate) await LoadPassesRefreshList();
        }

        public PassesViewModel()
        {
            _baseUrl = (new BaseUrlService()).GetBaseUrl();
            _allPassesListHelper = new AllPassesListHelper(_baseUrl);
        }

        public int OpacityHasFilters => FilterCount > 0 ? 1 : 0;

        [RelayCommand]
        public async Task LoadPassesRefreshList()
        {
            IsLoading = true;
            IsRefreshing = false;
            await Task.Run(async () => {
                await LoadPasses();
                RestoreFilterSettingsToDefault();
            });
            IsLoading = false;
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task LoadPasses()
        {
                var passesList = await _allPassesListHelper.GetAllPasses();
                HasNoPasses = passesList?.Count < 1;
                Passes = new ObservableCollection<PassListModel>(passesList);
                FilteredPasses = new ObservableCollection<PassListModel>(passesList);
                GetItemsForFilterPickers();
        }
        [RelayCommand]
        public async Task PassElementTapped(PassListModel model)
        {
            var queryParams = new Dictionary<string, string?>() { { "passId",model?.Id },{"passNum",model?.PassNum },{ "passCreated",model?.Created} };
            await Shell.Current.GoToAsync($"//PassDetail?QueryData={HttpUtility.UrlEncode(JsonSerializer.Serialize(queryParams))}",true);
        }

        [RelayCommand]
        public async void Find()
        {
            var startColor = FindBgColor;
            var endColor = Colors.DeepSkyBlue;
            for (int i = 0; i < 10; i++)
            {
                var progress = i / 10.0;
                FindBgColor = new Color(
                    (float)(startColor.Red + (endColor.Red - startColor.Red) * progress),
                    (float)(startColor.Green + (endColor.Green - startColor.Green) * progress),
                    (float)(startColor.Blue + (endColor.Blue - startColor.Blue) * progress)
                );
                await Task.Delay(10);
            }
            FindBgColor = startColor;
            if (FindInput is not null)
            {
                FilteredPasses = new ObservableCollection<PassListModel>(
                FilteredPasses.Where(p => p.PassNum.Contains(FindInput)));
                if (!_hasSearched)
                {
                    FilterCount++;
                    _hasSearched = true;
                }
            }
        }
        [RelayCommand]
        public async Task ToogleDrawerFilter()
        {
            FilterOpacity = !FilterOpacity;
            var targetHeight = PassesListDrawerHeight.HeightOfDrawerEnabledOrDisabled(FilterHeight);
            await MainThread.InvokeOnMainThreadAsync(async () => 
            {
                var animation = new Animation
                (
                    callback: v => FilterHeight = v,
                    start: FilterHeight,
                    end: targetHeight,
                    easing: Easing.CubicInOut
                );
                    Application.Current?.Windows[0].Page.Animate(
                    name: "DrawerAnimation",
                    animation: animation,
                    rate: 16,
                    length: 300,
                    finished: (v, c) => { }
                    );
            }); 
        }
        [RelayCommand]
        public async Task FilterPasses()
        {
            FilterApplyingProgresBarScale = 1;
            var loadingProgressBar = LoadingProgressBar();
            await Task.Run(async () => 
            {
                var filtered = FilteredPasses.ToList();
                if (PassTypeFilterInput is not null)
                    filtered = filtered.Where(p => p.PassTypeName.Equals(PassTypeFilterInput)).ToList();
                if (PassStateFilterInput is not null)
                    filtered = filtered.Where(p => p.PassStateName.Equals(PassStateFilterInput)).ToList();     
            
                await MainThread.InvokeOnMainThreadAsync(() => {
                FilteredPasses = new ObservableCollection<PassListModel>(filtered);              
                    if (!_hasFilteredByType && PassTypeFilterInput is not null)
                    {
                        FilterCount++;
                        _hasFilteredByType = true;
                    }               
                    if (!_hasFilteredByState && PassStateFilterInput is not null)
                    {
                        FilterCount++;
                        _hasFilteredByState = true;
                    }
                });
            });
            await loadingProgressBar;
        }
        [RelayCommand]
        public async void CancelFilterOfPasses()
        {
            FilterApplyingProgresBarScale = 1;
            await Task.WhenAll(
                LoadingProgressBar(),
                Task.Run(() =>
                {
                    FilteredPasses = new ObservableCollection<PassListModel>(Passes);
                    RestoreFilterSettingsToDefault();
                })
            );
        }
        private void GetItemsForFilterPickers()
        {
            var passStateItems = FilteredPasses.Select(p => p.PassStateName).Distinct().ToList();
            PassStateFilterItems = new ObservableCollection<string>(passStateItems);

            var passTypeItems = FilteredPasses.Select(p => p.PassTypeName).Distinct().ToList();
            PassTypeFilterItems = new ObservableCollection<string>(passTypeItems);
        }
        private async Task LoadingProgressBar()
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                var animation = new Animation(callback: v => FilterLoadingProgress = v,start: 0.0,end: 1.0,easing: Easing.CubicInOut);  
                Application.Current?.Windows[0].Page.Animate(name: "LoadingProgressBar",animation: animation,rate: 16,length: 500,finished: async (v, c) => { FilterApplyingProgresBarScale = 0; await ToogleDrawerFilter(); });
            });
        }
        private void RestoreFilterSettingsToDefault()
        {
            FilterCount = 0;
            FindInput = null;
            PassTypeFilterInput = null;
            PassStateFilterInput = null;
            _hasSearched = false;
            _hasFilteredByType = false;
            _hasFilteredByState = false;
        }
    }
}