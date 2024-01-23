using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Coastr.Model
{
    public class AppSettings : INotifyPropertyChanged
    {
        // todo: umsetzen
        public bool LocationReCheck { get; set; } = true;
        public string BillingCurrency { get; set; } = "EUR";
        public int LocationThreshold { get; set; } = 200;
        public int TimeThreshold { get; set; } = 2;

        private string _uiTheme = "";
        public string UiTheme
        {
            get => _uiTheme;
            set
            {
                if (_uiTheme == value)
                {
                    return;
                }
                _uiTheme = value;
                NotifyPropertyChanged();
            }
        }

        private bool _uiDarkMode = true;
        public bool UiDarkMode
        {
            get => _uiDarkMode;
            set
            {
                if (_uiDarkMode == value)
                {
                    return;
                }
                _uiDarkMode = value;
                NotifyPropertyChanged();
            }
        }

        // change Management        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
