using Coastr.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coastr
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            private set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshAppAsync());
        protected async Task RefreshAppAsync()
        {
            try
            {
                IsRefreshing = true;
                var handler = Application.Current.Handler.MauiContext.Services.GetService<WindowStateHandler>();
                await handler.InitState();
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
