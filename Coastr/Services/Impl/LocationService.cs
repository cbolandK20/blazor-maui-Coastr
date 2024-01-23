using CoastR.Model;

namespace Coastr.Services
{
    public class LocationService : ILocationService
    {
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        protected async Task<GeoPosition> GetCachedLocationAsync()
        {
            try
            {
                var result = await Geolocation.Default.GetLastKnownLocationAsync();
                return LocationUtils.ToPosition(result);

            }            
            catch (Exception) 
            {
                // FeatureNotSupportedException, FeatureNotEnabledException, PermissionException
                // Unable to get location
            }

            return null;
        }

        public async Task<GeoPosition> GetCurrentLocationAsync()
        {
            try
            {
                _isCheckingLocation = true;
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(5));
                _cancelTokenSource = new CancellationTokenSource();

                var result = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
                return LocationUtils.ToPosition(result);
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception )
            {
                // Unable to get location
                // do nothing here
            }
            finally
            {
                _isCheckingLocation = false;
            }
            return null;
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            {
                _cancelTokenSource.Cancel();
            }
        }
    }
}
