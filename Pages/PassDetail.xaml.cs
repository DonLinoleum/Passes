using Passes.ViewModels;
using System.Diagnostics;

namespace Passes.Pages;

public partial class PassDetail : ContentPage
{
	public PassDetail()
	{
		InitializeComponent();
		BindingContext = new PassDetailViewModel();    
    }
    protected override async void OnAppearing()
    {
        this.Opacity = 0;
        this.TranslationX = this.Width;

        await Task.WhenAll(
             this.FadeTo(1, 1000),
             this.TranslateTo(0, 0, 1000, Easing.CubicOut)
            );
        base.OnAppearing();
    }

    protected override bool OnBackButtonPressed()
    {
        if (BindingContext is not PassDetailViewModel viewModel)
            return false;

        if (viewModel.DrawerTranslateYTo == 0)
        {
            viewModel.ToogleDrawer().Wait();
            return true;
        }
        if (MenuComponent.BindingContext is MenuViewModel viewMenuModel && viewMenuModel.IsMenuOpen)
        {
            viewMenuModel.CloseMenu().Wait();
            return true;
        }
        else
        {
            Shell.Current.GoToAsync("//PassesList").Wait();
            return true;
        }      
    }
}