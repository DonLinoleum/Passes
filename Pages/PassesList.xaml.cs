using Passes.ViewModels;

namespace Passes.Pages;

public partial class PassesList : ContentPage
{
	public PassesList()
	{
		InitializeComponent();
		BindingContext = new PassesViewModel();
        
    }  
}