using TimeManagementAppGui.ViewModel;
using TimeManagementAppGui.ViewModel.Base.Navigation;

namespace TimeManagementAppGui.View;

public partial class ProjectTimeEntries : ContentPage
{
    private readonly EmployersViewModel _vm;
    private readonly INavigationService _navigationService;

    public ProjectTimeEntries(EmployersViewModel vm, INavigationService navigationService)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = vm;
        _navigationService = navigationService;

    }

    protected override bool OnBackButtonPressed()
    {
        /// HACK: WA to unresponsive backbutton bug
        /// I have no idea why the app can't perform this action in a civilized manner.
        _navigationService.NavigateToAsync("//Main/Employers/Projects");
        return true;
    }
}