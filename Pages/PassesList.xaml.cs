using Passes.ViewModels;

namespace Passes.Pages;

public partial class PassesList : ContentPage
{
	public PassesList()
	{
		InitializeComponent();
		BindingContext = new PassesViewModel();     
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        this.AbortAnimation("DrawerAnimation");
        this.AbortAnimation("LoadingProgressBar");
    }
}