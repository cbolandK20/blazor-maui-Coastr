using Coastr.Model;
using Coastr.Persistence;
using CoastR.Model;
using System.Diagnostics;

namespace Coastr.Services.Impl
{
    public class VenueService(IVenueRepository repo, ILocationService locationService) : AbstractPersistenceAwareService<IVenueRepository, Venue>(repo), IVenueService
    {
        private readonly ILocationService _locationService = locationService;

        public Venue CreateVenue(GeoPosition location)
        {
            var ret = new Venue()
            {
                Location = location
            };

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
            if (current.Count == 0)
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

        public Task<List<Venue>> SearchVenueByNameAsync(string query)
        {
            Debug.WriteLine($"SearchVenueByNameAsync: {query}");
            if (string.IsNullOrEmpty(query))
            {
                return _repo.GetAllAsync();
            }
            return _repo.GetListAsync(item => item.Name.Contains(query));
        }

        public Task<List<Venue>> SearchVenueByNameExactAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _repo.GetAllAsync();
            }
            return _repo.GetListAsync(item => item.Name.Equals(query));
        }

        public void DeleteVenue(Venue venue)
        {
            if (venue == null)
            {
                return;
            }

            _repo.Delete(venue);
            _repo.Flush();
        }
    }
}
