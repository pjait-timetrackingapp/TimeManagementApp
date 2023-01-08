using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TimeManagementAppGui.ViewModel
{
    internal class SchedulerViewModel : INotifyPropertyChanged
    {
        private DateTime _month;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Month 
        { 
            get => _month; 
            set 
            { 
                _month = value;
                TrySetProperty(ref _month, value);
            }
        }

        public SchedulerViewModel() 
        {
            DisplayCalendar = new Microsoft.Maui.Controls.Command(
                execute: () =>
                {
                    Month = Month.AddMonths(3);
                    OnPropertyChanged(nameof(Month));
                });
        }

        public ICommand DisplayCalendar { get; private set; }
        public ICommand AddTimeEntryCommand { get; private set; }

        private bool TrySetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
