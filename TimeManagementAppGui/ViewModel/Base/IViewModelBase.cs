using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;

namespace TimeManagementAppGui.ViewModel.Base
{
    internal interface IViewModelBase
    {
        public IDialogService DialogService { get; }
        public INavigationService NavigationService { get; }

        public bool IsBusy { get; }

        public bool IsInitialized { get; set; }

        Task InitializeAsync();
    }
}
