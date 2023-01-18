using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class Employers : ContentPage
{
	public Employers(AddEmployerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}