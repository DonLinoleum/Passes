using Passes.Models.PassDetail;
using Passes.ViewModels;
using System.Diagnostics;

namespace Passes.Components;

public partial class ApproverForServicesPasses : ContentView
{
	public ApproverForServicesPasses()
	{
		InitializeComponent();
	}

    private void toggleSwitchVehicle_Toggled(object sender, ToggledEventArgs e)
    {
		var switchElement = (Microsoft.Maui.Controls.Switch)sender;
		var model = switchElement.BindingContext as VehiclesChildren;
		string? passId = model?.PassId;
		AddChildPassIdToChildPassesList(switchElement, passId ?? "");
    }

    private void toggleSwitchVisitor_Toggled(object sender, ToggledEventArgs e)
    {
        var switchElement = (Microsoft.Maui.Controls.Switch)sender;
        var model = switchElement.BindingContext as VisitorsChildren;
        string? passId = model?.PassId;
        AddChildPassIdToChildPassesList(switchElement, passId ?? "");
    }

	private void AddChildPassIdToChildPassesList(Microsoft.Maui.Controls.Switch switchElement, string passId)
	{
        if (switchElement.Parent is Layout parentLayout)
        {
            var element = parentLayout.Parent;
            while (element != null && !(element is ContentPage))
                element = element.Parent;
            if (element is ContentPage contentPage)
            {
                PassDetailViewModel? viewModel = contentPage.BindingContext as PassDetailViewModel;
                viewModel?.AddChildPassToApproveList(passId);
            }
        }
    }
}