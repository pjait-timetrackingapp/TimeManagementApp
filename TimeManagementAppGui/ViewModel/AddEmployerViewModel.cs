﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TimeManagementAppGui.ViewModel.Base;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;
using TmaLib.Services;

namespace TimeManagementAppGui.ViewModel
{
    public partial class AddEmployerViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string name;
        
        private readonly IAddEmployerService _addEmployerService;

        public AddEmployerViewModel(IDialogService dialogService, INavigationService navigationService, IAddEmployerService addEmployerService) : base(dialogService, navigationService)
        {
            _addEmployerService = addEmployerService;
        }

        [RelayCommand]
        private void AddEmployer(string name)
        {
            _addEmployerService.AddEmployer(new TmaLib.UserInputAddEmployer(name));
            NavigationService.NavigateToAsync("//Main/Calendar");
        }
    }
}
