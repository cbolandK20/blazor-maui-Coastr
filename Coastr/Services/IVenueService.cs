using Coastr.Model;
using CoastR.Model;

namespace Coastr.Services
{
    public interface IVenueService : IPersistenceAwareService<Venue>
    {
        public Venue CreateVenue(GeoPosition location);

        public void DeleteVenue(Venue venue);

        public Task<List<Venue>> GetVenuesByPositionAsync(GeoPosition position, int threshold = 0);

        public Task<Venue> GetCurrentVenueAsync(GeoPosition position, int locationThreshold);

        public Task<bool> ShowOnMap(Venue source);

        public Task<bool> ShowOnMap(int sourceId);

        public Task<List<Venue>> SearchVenueByNameAsync(string query);
        public Task<List<Venue>> SearchVenueByNameExactAsync(string query);
    }
}