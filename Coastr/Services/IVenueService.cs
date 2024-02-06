using Coastr.Model;
using CoastR.Model;

namespace Coastr.Services
{
    public interface IVenueService : IPersistenceAwareService<Venue>
    {
        public Venue CreateVenue(GeoPosition location);

        public void DeleteVenue(Venue venue);

        public Task<List<Venue>> GetVenuesByPositionAsync(GeoPosition position);

        public Task<Venue> GetCurrentVenueAsync(GeoPosition position, int locationThreshold);

        public Task ShowOnMap(Venue source);

        public Task ShowOnMap(int sourceId);

        public Task<List<Venue>> SearchVenueByNameAsync(string query);
    }
}