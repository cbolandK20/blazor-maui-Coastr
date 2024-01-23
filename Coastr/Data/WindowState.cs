using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Coastr.Data
{
    public class WindowState : INotifyPropertyChanged
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public int ContentSizeX { get; set; }
        public int ContentSizeY { get; set; }

        private DisplayOrientation _orientation = DeviceDisplay.Current.MainDisplayInfo.Orientation;
        public DisplayOrientation Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation == value)
                {
                    return;
                }
                _orientation = value;
                NotifyPropertyChanged();
            }
        }

        // change Management        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void NotifySizeChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("size"));
        }
    }
}
