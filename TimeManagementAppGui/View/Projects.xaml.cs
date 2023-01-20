using TimeManagementAppGui.ViewModel;

namespace TimeManagementAppGui.View;

public partial class Projects : ContentPage
{
    private readonly EmployersViewModel _vm;

    public Projects(EmployersViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }
}