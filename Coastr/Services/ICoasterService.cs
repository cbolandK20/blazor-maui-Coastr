using Coastr.Model;
using CoastR.Model;

namespace Coastr.Services
{
    public interface ICoasterService : IPersistenceAwareService<Coaster>
    {
        public Coaster CreateCoaster(Venue venue);

        public Task<Coaster> GetCurrentCoasterByPositionAsync(GeoPosition position, int locationThreshold);

        public Task<Coaster> GetCurrentCoasterByVenueAsync(Venue source);
        public Task<List<Coaster>> GetOpenCoastersAsync();
        public Task<Coaster> GetLatest(int timeThreshold);

        public bool PayCoaster(Coaster source);

    }
}