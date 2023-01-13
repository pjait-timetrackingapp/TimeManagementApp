using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class AddTimeEntry : ContentPage
{
	public AddTimeEntry(AddTimeEntryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}