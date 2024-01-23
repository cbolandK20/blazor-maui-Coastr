using Coastr.Services;

namespace Coastr
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            var windowStateHandler = Application.Current.Handler.MauiContext.Services.GetService<WindowStateHandler>();

            window.SizeChanged += windowStateHandler.OnWindowSizeChanged;
            window.Created += windowStateHandler.OnWindowCreated;
            window.Activated += windowStateHandler.OnWindowActivated;
            window.Deactivated += windowStateHandler.OnWindowDeactivated;
            window.Stopped += windowStateHandler.OnWindowDeactivated;
            

            var device = DeviceDisplay.Current;
            device.MainDisplayInfoChanged += windowStateHandler.OnDeviceDisplayChanged;

            return window;
        }
    }
}