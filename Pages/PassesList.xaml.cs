using Passes.ViewModels;
using System.Threading.Tasks;

namespace Passes.Pages;

public partial class PassesList : ContentPage
{
	public PassesList()
	{
		InitializeComponent();
		BindingContext = new PassesViewModel();     
    }

    protected override async void OnAppearing()
    {
        this.Opacity = 0;
        this.TranslationX = this.Width;

        await Task.WhenAll(
             this.FadeTo(1,1000),
             this.TranslateTo(0,0,1000,Easing.CubicOut)
            );
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        this.AbortAnimation("DrawerAnimation");
        this.AbortAnimation("LoadingProgressBar");
    }
}