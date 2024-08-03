using Coastr.Data.Common.Impl;
using Coastr.Model;
using Coastr.Services.Common;

namespace Coastr.Services
{
    public class WindowStateHandler
        : IDisposable
    {

        private ISettingsService _settingsService;
        private ILocationService _locationService;
        private ICoasterService _coasterService;
        private IVenueService _venueService;
        private IApplicationMessageService _messageService;
        private StateContainer _state;


        // Change Event Handler
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();


        public WindowStateHandler(ISettingsService settingsService, ILocationService locationService, ICoasterService coasterService, IVenueService venueService, IApplicationMessageService messageService, StateContainer state)
        {
            _state = state;
            _settingsService = settingsService;
            _locationService = locationService;
            _coasterService = coasterService;
            _messageService = messageService;
            _venueService = venueService;
        }

        public void Dispose()
        {
            var _window = Application.Current.Windows.FirstOrDefault();
            _window.SizeChanged -= OnWindowSizeChanged;
            _window.Created -= OnWindowActivated;
            _window.Destroying -= OnWindowDeactivated;
        }

        public void OnWindowSizeChanged(object sender, EventArgs e)
        {
            var _window = Application.Current.Windows.FirstOrDefault();
            _state.WindowState.SizeX = (int)_window.Width;
            _state.WindowState.SizeY = (int)_window.Height;
            _state.WindowState.NotifySizeChanged();

            NotifyStateChanged();
        }

        public async void OnWindowDeactivated(object sender, EventArgs e)
        {
            await _settingsService.SaveSettingsAsync(_state.Settings);
            await _coasterService.FlushAsync();
        }

        public async void OnWindowCreated(object sender, EventArgs e)
        {
            var settings = _settingsService.LoadSettings();
            _state.Settings = settings;
            await InitState();
        }

        public async void OnWindowActivated(object sender, EventArgs e)
        {
            await InitState();
        }

        public async Task InitState()
        {
            _state.Messages.Add(_messageService.CreateMessage(ApplicationMessageCode.MSG_REFRESHING, ApplicationMessageType.INFO));

            var position = await _locationService.GetCurrentLocationAsync();
            _state.Capabilities.UseLocation = position != null;
            if (position == null)
            {
                _state.Messages.Add(_messageService.CreateMessage(ApplicationMessageCode.MSG_POSITION_DISABLED, ApplicationMessageType.WARNING));
            }

        }

        public void OnDeviceDisplayChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            _state.WindowState.Orientation = e.DisplayInfo.Orientation;
        }
    }
}
