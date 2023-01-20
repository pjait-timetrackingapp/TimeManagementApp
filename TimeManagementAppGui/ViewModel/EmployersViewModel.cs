using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private IProjectRepository _projectRepository;
        [ObservableProperty]
        private Employer _selectedEmployer;

        public bool IsFabVisible { get => _selectedEmployer != null; }

        public ICommand RemoveSelectedItemCommand { get; set; }

        public event EventHandler ViewChanged;

        public EmployersViewModel(
            IDialogService dialogService,
            INavigationService navigationService,
            IEmployerRepository employerRepository, IProjectRepository projectRepository) : base(dialogService, navigationService)
        {
            _employerRepository = employerRepository;
            _projectRepository = projectRepository;

            RemoveSelectedItemCommand = new AsyncRelayCommand(RemoveSelectedItem);
        }

        public List<Employer> GetEmployers()
        {
            return _employerRepository.GetAll();
        }

        [RelayCommand]
        private void SelectionChanged()
        {
            OnPropertyChanged(nameof(IsFabVisible));
        }

        [RelayCommand]
        private void Details()
        {
            // Ustawiac SelectedEmployer
            NavigationService.NavigateToAsync("//Main/Employers/Projects");
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
    }
}
