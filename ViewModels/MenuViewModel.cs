using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Passes.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isMenuOpen = false;

        [ObservableProperty]
        private double menuWidth; 

        [ObservableProperty]
        private double translationMenuX;

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string workPosition;

        public MenuViewModel()
        {
            GetWidthOfMenu();
            GetUserFullName();
            GetUserWorkPosition();
        }

        [RelayCommand]
        public async Task GoToWorkPlace()
        {
            await CloseMenu();
            await Shell.Current.GoToAsync("//PassesList");
        }

        [RelayCommand]
        public async Task CloseMenu()
        {
            IsMenuOpen = false;
            await MainThread.InvokeOnMainThreadAsync(() => {
                new Animation(v => TranslationMenuX = v, TranslationMenuX, MenuWidth, Easing.CubicInOut)
                .Commit(Application.Current?.Windows[0].Page, "MenuCloseAnimation", 16, 300);
            });
        }

        [RelayCommand]
        public async Task OpenMenu()
        {
            GetUserFullName();
            GetUserWorkPosition();
            IsMenuOpen = true;
            await MainThread.InvokeOnMainThreadAsync(() => {
                new Animation(v => TranslationMenuX = v, MenuWidth, 0, Easing.CubicInOut)
                .Commit(Application.Current?.Windows[0].Page, "MenuCloseAnimation", 16, 300);
            });
        }

        [RelayCommand]
        public async Task Exit()
        {
            bool exitConfirmation = await Shell.Current.DisplayAlert("Выход", "Выйти из профиля?", "Да", "Нет");
            if (exitConfirmation)
            {
                await CloseMenu();
                ExitHandlerHelper.GoToAuthPage();
            }
        }

        private void GetWidthOfMenu()
        {
            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
            double screenWidth = displayInfo.Width / displayInfo.Density;
            double width = (int)(screenWidth * 0.85);
            MenuWidth = width;
            TranslationMenuX = width;
        }

        private void GetUserFullName()
        {
           string? lastName = Preferences.Get("mmk_user_last_name","");
           string? name = Preferences.Get("mmk_user_name","");
           string? secondName = Preferences.Get("mmk_user_second_name","");
           UserName = $"{lastName} {name} {secondName}";
        }

        private void GetUserWorkPosition()
        {
            string? workPosition = Preferences.Get("mmk_user_work_position", "");
            WorkPosition = workPosition;
        }
    }
}
