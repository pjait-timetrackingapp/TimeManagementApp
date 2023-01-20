using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class AddEmployerView : ContentPage
{
	public AddEmployerView(AddEmployerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}