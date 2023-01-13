using CommunityToolkit.Mvvm.ComponentModel;
using TimeManagementAppGui.ViewModel.Base.Dialog;
using TimeManagementAppGui.ViewModel.Base.Navigation;

namespace TimeManagementAppGui.ViewModel.Base
{
    public abstract class ViewModelBase : ObservableObject, IViewModelBase, IDisposable
    {
        private readonly SemaphoreSlim _isBusyLock = new(1, 1);

        private bool _isInitialized;
        private bool _isBusy;
        private bool _disposedValue;

        public IDialogService DialogService { get; private set; }

        public INavigationService NavigationService { get; private set; }

        public bool IsInitialized
        {
            get => _isInitialized;
            set => SetProperty(ref _isInitialized, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            private set => SetProperty(ref _isBusy, value);
        }

        public ViewModelBase(IDialogService dialogService, INavigationService navigationService)
        {
            DialogService = dialogService;
            NavigationService = navigationService;
        }

        public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
        {
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task IsBusyFor(Func<Task> unitOfWork)
        {
            await _isBusyLock.WaitAsync();

            try
            {
                IsBusy = true;

                await unitOfWork();
            }
            finally
            {
                IsBusy = false;
                _isBusyLock.Release();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _isBusyLock?.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
