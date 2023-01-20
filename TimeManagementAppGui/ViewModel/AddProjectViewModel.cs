using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Repository;

namespace TimeManagementAppGui.ViewModel
{
    public partial class AddProjectViewModel : ViewModelBase
    {
        private readonly IProjectRepository _projectRepository;

        public AddProjectViewModel(IDialogService dialogService, INavigationService navigationService, IProjectRepository projectRepository) : base(dialogService, navigationService)
        {
            _projectRepository = projectRepository;
        }
    }
}
