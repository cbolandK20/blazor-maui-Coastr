using Coastr.Data;
using Coastr.Data.Common.Impl;
using CoastR.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Coastr.Model
{
    /// <summary>
    /// in Memeory State Container
    /// </summary>
    public class StateContainer : INotifyPropertyChanged
    {
        public ApplicationMessageList Messages { get; set; } = new ApplicationMessageList();

        private Coaster _currentCoaster = null;
        public Coaster CurrentCoaster
        {
            get => _currentCoaster;
            set
            {
                _currentCoaster = value;
                NotifyPropertyChanged();
            }
        }
        public bool HasCoaster { get { return CurrentCoaster != null; } }
        public GeoPosition CurrentPosition { get; set; } = null;
        public bool HasPosition { get { return CurrentPosition != null; } }

        public Venue CurrentVenue { get; set; } = null;
        public bool HasVenue { get { return CurrentVenue != null; } }
        public AppSettings Settings { get; set; }

        public WindowState WindowState { get; set; } = new WindowState();

        public ApplicationCapabilities Capabilities { get; set; } = new ApplicationCapabilities();

        private string _headerText = "";
        public string HeaderText
        {
            get => _headerText;
            set
            {
                _headerText = value;
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
