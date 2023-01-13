using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Services;

namespace TimeManagementAppGui.ViewModel
{
    public partial class AddTimeEntryViewModel : ViewModelBase
    {
        private string _time;
        private string _description;
        private DateTime _date = DateTime.Now;
        private long _projectId;
        private long _employerId;

        public string Time { get => _time; set => SetProperty(ref _time, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
        public DateTime Date { get => _date; set => SetProperty(ref _date, value); }
        public long ProjectId { get => _projectId; set => SetProperty(ref _projectId, value); }
        public long EmployerId { get => _employerId; set => SetProperty(ref _employerId, value); }

        public ICommand AddItem { get; }
        private readonly IAddEmployerService _employerService;

        public AddTimeEntryViewModel(IDialogService dialogService, INavigationService navigationService, IAddEmployerService employerService) : base(dialogService, navigationService)
        {
            AddItem = new AsyncRelayCommand(Add);
            _employerService = employerService;
        }

        private async Task Add()
        {
            try
            {
                var entry = new TmaLib.Model.TimeEntry(DateTime.Now, Description, Time);

                await _employerService.Add(entry, EmployerId, ProjectId);
                await NavigationService.PopAsync();
            }
            catch (KeyNotFoundException)
            {
                await DialogService.ShowAlertAsync("Sprawdź poprawność wszystkich pól", "Coś poszło nie tak", "Ok");
            }
            catch (ArgumentException)
            {
                await DialogService.ShowAlertAsync("Nieprawidłowy format czasu pracy", "Coś poszło nie tak", "Ok");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
