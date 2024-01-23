using Coastr.Data.Common.Impl;
using Coastr.Model;
using Coastr.Persistence;
using Coastr.Services.Common;
using CoastR.Model;

namespace Coastr.Services.Impl
{
    public class VenueService : AbstractPersistenceAwareService<IVenueRepository, Venue>, IVenueService
    {
        private StateContainer _state;
        private IApplicationMessageService _messageService;

        public VenueService(StateContainer state, IVenueRepository repo, IApplicationMessageService messageService)
        {
            _state = state;
            _repo = repo;
            _messageService = messageService;   
        }
        public Venue CreateVenue(GeoPosition location)
        {
            var ret = new Venue();
            ret.Location = location;

            return ret;
        }

        public Task<List<Venue>> GetVenuesByPositionAsync(GeoPosition position)
        {
            return _repo.GetListAsync(item => LocationUtils.IsNear(item.Location, position, _state.Settings.LocationThreshold));
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

        public async Task ShowOnMap(Venue source)
        {
            var location = new Location(source.Location.Latitude, source.Location.Longitude);
            var options = new MapLaunchOptions { Name = source.Name };

            try
            {
                await Map.Default.OpenAsync(location, options);
            }
            catch (Exception )
            {
                _state.Messages.Add(_messageService.CreateMessage(ApplicationMessageCode.MSG_NO_MAPS_APP_FOUND, ApplicationMessageType.WARNING));
            }
        }

        public  Task<List<Venue>> SearchVenueByNameAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _repo.GetAllAsync();
            }
            return _repo.GetListAsync(item => item.Name.Contains(query));
        }
    }
}
