using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;

namespace TimeManagementAppGui.ViewModel
{
    public partial class SchedulerViewModel : ViewModelBase 
    {
        private DateTime _month;
        public DateTime Month 
        { 
            get => _month;
            set => SetProperty(ref _month, value);
        }
        public ICommand DisplayEntryAdditionPage { get; private set; }

        public SchedulerViewModel(IDialogService dialogService, INavigationService navigationService) 
            : base(dialogService, navigationService)
        {
            DisplayEntryAdditionPage = new AsyncRelayCommand(DisplayAddItemPage);
        }

        private async Task DisplayAddItemPage()
        {
            await NavigationService.NavigateToAsync("AddEntry");
        }
    }
}
