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

    private void Vm_ViewChanged(object sender, EventArgs e)
    {
        employersView.ItemsSource = _vm.GetEmployers();
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        employersView.ItemsSource = _vm.GetEmployers();
    }
}