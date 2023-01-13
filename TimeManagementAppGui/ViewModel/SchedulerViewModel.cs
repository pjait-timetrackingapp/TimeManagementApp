using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Services;

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
        public ICommand DisplayCalendar { get; private set; }
        public ICommand DisplayEntryAdditionPage { get; private set; }

        private IAddEmployerService _addEmployerService { get; }

        public SchedulerViewModel(IDialogService dialogService, INavigationService navigationService, IAddEmployerService addEmployerService) 
            : base(dialogService, navigationService)
        {
            _addEmployerService = addEmployerService;

            DisplayEntryAdditionPage = new AsyncRelayCommand(DisplayAddItemPage);
        }

        private async Task DisplayAddItemPage()
        {
            await NavigationService.NavigateToAsync("AddEntry");
        }
    }
}
