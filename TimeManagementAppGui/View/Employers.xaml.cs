using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class Employers : ContentPage
{
    private readonly EmployersViewModel _vm;

    public Employers(EmployersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        _vm = vm;
        _vm.ViewChanged += Vm_ViewChanged;
    }

    private async void Vm_ViewChanged(object sender, EventArgs e)
    {
        employersView.ItemsSource = await _vm.GetEmployers();
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        employersView.ItemsSource = await _vm.GetEmployers();
    }
}