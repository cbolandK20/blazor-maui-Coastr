using Coastr.Model;
using Coastr.Persistence;
using CoastR.Model;

namespace Coastr.Services.Impl
{
    public class CoasterService : AbstractPersistenceAwareService<ICoasterRepository, Coaster>, ICoasterService
    {

        public CoasterService(ICoasterRepository repo)
        {
            _repo = repo;
        }
        public Coaster CreateCoaster(Venue venue)
        {
            var ret = new Coaster() { Venue = venue, State = ObjectState.MOVING };
            //ret = _repo.Add(ret);

            return ret;
        }

        public async Task<Coaster> GetCurrentCoasterAsync(GeoPosition position, int locationThreshold)
        {
            Coaster ret = null;
            if (position == null)
            {
                return ret;
            }

            var current = await _repo.GetListAsync(item => item.State == ObjectState.MOVING);
            if (!current.Any())
            {
                return ret;
            }
            // this is not possible in a DB query
            current = current.Where(item => LocationUtils.IsNear(item.Venue?.Location, position, locationThreshold)).ToList();
            if (current.Count != 1)
            {
                return ret;
            }
            return current.FirstOrDefault();
        }

        public async Task<Coaster> GetCurrentCoasterByVenueAsync(Venue source)
        {
            Coaster ret = null;
            if (source == null)
            {
                return ret;
            }

            var current = await _repo.GetListAsync(item => item.State == ObjectState.MOVING && item.Venue.Id == source.Id);
            if (!current.Any())
            {
                return ret;
            }
            return current.FirstOrDefault();
        }

        public Task<List<Coaster>> GetOpenCoastersAsync()
        {
            return _repo.GetListAsync(item => item.State == ObjectState.MOVING);
        }

        public Task<List<Coaster>> GetBilledCoastersAsync()
        {
            return _repo.GetListAsync(item => item.State != ObjectState.MOVING);
        }

        public bool PayCoaster(Coaster source)
        {
            if (source == null)
            {
                return false;
            }

            source.State = ObjectState.ARCHIVED;
            return _repo.SaveAll() > 0;
        }

        public new void Save(Coaster source)
        {
            if (source.Venue == null)
            {
                return;
            }
            base.Save(source);
        }

        public async Task<Coaster> GetLatest(int timeThreshold)
        {
            var latest = await _repo.GetLatest();
            if (latest == null) {
                return latest;
            }

            if (DateTime.Now - latest.Updated > new TimeSpan(timeThreshold,0,0))
            {
                latest = null;
            }
            return latest;
        }
    }
}
