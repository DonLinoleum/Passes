
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.Models.PassList;
using Passes.Services;
using Passes.ViewModels.Helpers;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.AccessControl;


namespace Passes.ViewModels
{
   public partial class PassesViewModel : ObservableObject
    {
        private readonly PassesListService _passesListService;

        [ObservableProperty]
        private ObservableCollection<PassListModel> passes;

        [ObservableProperty]
        private ObservableCollection<PassListModel> filteredPasses;

        [ObservableProperty]
        private ObservableCollection<string> passStateFilterItems;

        [ObservableProperty]
        private ObservableCollection<string> passTypeFilterItems;

        [ObservableProperty]
        private bool isLoading = true;

        [ObservableProperty]
        private double filterLoadingProgress = 0.0;

        //filters
        [ObservableProperty]
        private string? findInput;

        [ObservableProperty]
        private double filterHeight = 0;

        [ObservableProperty]
        private bool filterOpacity = false;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(OpacityHasFilters))]
        private int filterCount;

        [ObservableProperty]
        private string? passTypeFilter;

        [ObservableProperty]
        private string? passStateFilter;

        [ObservableProperty]
        private Color findBgColor = Color.FromArgb("#2056ae");

        private bool hasSearched = false;
        private bool hasFilteredByType = false;
        private bool hasFilteredByState = false;

        public PassesViewModel()
        {
            _passesListService = new PassesListService();
            LoadPasses();
        }

        public int OpacityHasFilters => FilterCount > 0 ? 1 : 0;

        [RelayCommand]
        public async void LoadPasses()
        {
            var passesList = await _passesListService.GetPasses();
            Passes = new ObservableCollection<PassListModel>(passesList);
            FilteredPasses = new ObservableCollection<PassListModel>(passesList);
            GetItemsForFilterPickers();
            IsLoading = false;
        }


        [RelayCommand]
        public async Task PassElementTapped(string Id)
        {
            await Shell.Current.GoToAsync($"//PassDetail?passId={Id}");
        }

        [RelayCommand]
        public async Task Exit()
        {
            ExitHandlerHelper.GoToAuthPage();
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
            /* var filtered =   from p in Passes
                              where p.Pass_num.Contains(FindInput)
                              select p;*/
            if (FindInput is not null)
            {
                FilteredPasses = new ObservableCollection<PassListModel>(
                FilteredPasses.Where(p => p.Pass_num.Contains(FindInput)));
                if (!hasSearched)
                {
                    FilterCount++;
                    hasSearched = true;
                }
            }
        }

        [RelayCommand]
        public async void ToogleDrawerFilter()
        {
            FilterOpacity = !FilterOpacity;
            var targetHeight = FilterHeight == 0 ? 380 : 0;

            var animation = new Animation(
                callback: v => FilterHeight = v,
                start: FilterHeight,
                end: targetHeight,
                easing: Easing.Default
                );

            animation.Commit( owner: Application.Current.MainPage,name: "DrawerAnimation",length: 400);
        }

        [RelayCommand]
        public async void FilterPasses()
        {
            FilterLoadingProgress = 0.0;
            LoadingProgressBar();
            if (PassTypeFilter is not null)
            {
                FilteredPasses = new ObservableCollection<PassListModel>(
                    FilteredPasses.Where(p => p.PassTypeName.Equals(PassTypeFilter)));
                if (!hasFilteredByType)
                {
                    FilterCount++;
                    hasFilteredByType = true;
                }
            }
            if (PassStateFilter is not null)
            {
                FilteredPasses = new ObservableCollection<PassListModel>(
                    FilteredPasses.Where(p => p.PassStateName.Equals(PassStateFilter)));
                if (!hasFilteredByState)
                {
                    FilterCount++;
                    hasFilteredByState = true;
                }
            }
        }

        [RelayCommand]
        public async void CancelFilterOfPasses()
        {
            FilterLoadingProgress = 0.0;
            LoadingProgressBar();
            FilteredPasses = new ObservableCollection<PassListModel>(Passes);
            FilterCount = 0;
            FindInput = null;
            PassTypeFilter = null;
            PassStateFilter = null;
            hasSearched = false;
            hasFilteredByType = false;
            hasFilteredByState = false;
        }

        private void GetItemsForFilterPickers()
        {
            var passStateItems = FilteredPasses.Select(p => p.PassStateName).Distinct().ToList();
            PassStateFilterItems = new ObservableCollection<string>(passStateItems);

            var passTypeItems = FilteredPasses.Select(p => p.PassTypeName).Distinct().ToList();
            PassTypeFilterItems = new ObservableCollection<string>(passTypeItems);
        }

        private async void LoadingProgressBar()
        {
            var animation = new Animation(
                callback: v => FilterLoadingProgress = v,
                start: 0.0,
                end: 1.0,
                easing: Easing.Default
                );
            animation.Commit(
                owner: Application.Current.MainPage,
                name: "LoadingProgressBarAnimation",
                length: 1000
                );
        }
    }
}