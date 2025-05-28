using Passes.ViewModels;

namespace Passes.Components;

public partial class MenuView : ContentView
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}
}