using Coastr.Model;
using Coastr.Persistence;
using CoastR.Model;

namespace Coastr.Services.Impl
{
    public class VenueService : AbstractPersistenceAwareService<IVenueRepository, Venue>, IVenueService
    {                
        private readonly ILocationService _locationService;

        public VenueService(IVenueRepository repo, ILocationService locationService) : base (repo)
        {                 
            _locationService = locationService;
        }
        public Venue CreateVenue(GeoPosition location)
        {
            var ret = new Venue();
            ret.Location = location;

            return ret;
        }

        public Task<List<Venue>> GetVenuesByPositionAsync(GeoPosition position, int threshold)
        {
            return _repo.GetListAsync(item => LocationUtils.IsNear(item.Location, position, threshold));
        }

        public async Task<Venue> GetCurrentVenueAsync(GeoPosition position, int locationThreshold)
        {
            Venue ret = null;
            var current = await _repo.GetAllAsync();
            if (!current.Any())
            {
                return ret;
            }
            current = current.Where(item => LocationUtils.IsNear(item.Location, position, locationThreshold)).ToList();
            if (current.Count != 1)
            {
                return ret;
            }
            return current.FirstOrDefault();
        }

        public async Task<bool> ShowOnMap(Venue source)
        {
            return await _locationService.ShowOnMap(source.Location, source.Name);
        }

        public async Task<bool> ShowOnMap(int sourceId)
        {
            var item = await _repo.GetAsync(sourceId);
            return await ShowOnMap(item);
        }

        public  Task<List<Venue>> SearchVenueByNameAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _repo.GetAllAsync();
            }
            return _repo.GetListAsync(item => item.Name.Contains(query));
        }

        public void DeleteVenue(Venue venue)
        {
            if (venue == null)
            {
                return;
            }

            _repo.Delete(venue);
            _repo.SaveAll();            
        }
    }
}
