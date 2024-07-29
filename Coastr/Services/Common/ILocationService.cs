using CoastR.Model;

namespace Coastr.Services
{
    public interface ILocationService
    {
        public Task<GeoPosition> GetCurrentLocationAsync();
        public void CancelRequest();

        public Task<bool> ShowOnMap(GeoPosition source, string name);
    }
}