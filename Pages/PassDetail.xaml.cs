using Passes.ViewModels;

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
}