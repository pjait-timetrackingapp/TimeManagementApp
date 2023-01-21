using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Model;
using TmaLib.Repository;

namespace TimeManagementAppGui.ViewModel
{
    public partial class EmployersViewModel : ViewModelBase
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITimeEntryRepository _timeEntryRepository;
        [ObservableProperty]
        private Employer _selectedEmployer;
        [ObservableProperty]
        private Project _selectedProject;
        public ObservableCollection<Project> Projects { get; set; } = new();
        public ObservableCollection<TimeEntry> TimeEntries { get; set; } = new();

        public bool IsFabVisible { get => _selectedEmployer != null; }
        public bool IsProjectFabVisible { get => _selectedProject != null; }

        public ICommand RemoveSelectedItemCommand { get; set; }

        public event EventHandler ViewChanged;

        public EmployersViewModel(
            IDialogService dialogService,
            INavigationService navigationService,
            IEmployerRepository employerRepository, IProjectRepository projectRepository, ITimeEntryRepository timeEntryRepository) : base(dialogService, navigationService)
        {
            _employerRepository = employerRepository;
            _projectRepository = projectRepository;
            _timeEntryRepository = timeEntryRepository;

            RemoveSelectedItemCommand = new AsyncRelayCommand(RemoveSelectedItem);
        }

        public List<Employer> GetEmployers()
        {
            return _employerRepository.GetAll();
        }

        [RelayCommand]
        private void SelectionChanged()
        {
            if (SelectedEmployer != null)
            {
                Projects = new ObservableCollection<Project>(GetProjectsForEmployer());
            }
            OnPropertyChanged(nameof(IsFabVisible));
        }

        [RelayCommand]
        private void ProjectSelectionChanged()
        {
            if (SelectedProject != null)
            {
                TimeEntries = new ObservableCollection<TimeEntry>(GetTimeEntriesForProject());
            }
            OnPropertyChanged(nameof(IsProjectFabVisible));
        }

        [RelayCommand]
        private async Task Details()
        {
            await NavigationService.NavigateToAsync("Projects");
        }

        [RelayCommand]
        private async Task ProjectDetails()
        {
            await NavigationService.NavigateToAsync("ProjectTimeEntries");
        }

        [RelayCommand]
        private void AddEmployer()
        {
            NavigationService.NavigateToAsync("AddEmployer");
        }

        private async Task RemoveSelectedItem()
        {
            try
            {
                _employerRepository.Remove(SelectedEmployer);
                await _employerRepository.SaveChanges();
                ViewChanged?.Invoke(this, EventArgs.Empty);

                SelectedEmployer = null;
                OnPropertyChanged(nameof(IsFabVisible));
            }
            catch (ArgumentException)
            {
            }
        }

        [RelayCommand]
        private void RemoveSelectedProject()
        {
            var projectRemoved = _projectRepository.Remove(SelectedProject);
            _projectRepository.SaveChanges();

            var item = Projects.FirstOrDefault(x => x.Id == projectRemoved.Id);
            Projects.Remove(item);
            ViewChanged?.Invoke(this, EventArgs.Empty);

            SelectedProject = null;
            OnPropertyChanged(nameof(IsProjectFabVisible));
        }

        private List<Project> GetProjectsForEmployer()
        {
            return _projectRepository.GetAllByEmployerId(SelectedEmployer.Id);
        }

        private IEnumerable<TimeEntry> GetTimeEntriesForProject()
        {
            return _timeEntryRepository.GetTimeEntriesForProject(SelectedProject.Id);
        }

        public void NavigateBack()
        {
            NavigationService.PopAsync();
        }
    }
}
