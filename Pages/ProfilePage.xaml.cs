using Passes.ViewModels;

namespace Passes.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
		BindingContext = new ProfileViewModel();
	}

    protected override bool OnBackButtonPressed()
    {
        if (BindingContext is not ProfileViewModel viewModel)
            return false;
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