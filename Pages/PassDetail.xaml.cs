using Passes.ViewModels;

namespace Passes.Pages;

public partial class PassDetail : ContentPage
{
	public PassDetail()
	{
		InitializeComponent();
		BindingContext = new PassDetailViewModel();
	}
}