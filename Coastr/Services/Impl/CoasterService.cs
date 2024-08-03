using Coastr.Model;
using Coastr.Persistence;
using CoastR.Model;

namespace Coastr.Services.Impl
{
    public class CoasterService(ICoasterRepository repo, IBillingService billingService) : AbstractPersistenceAwareService<ICoasterRepository, Coaster>(repo), ICoasterService
    {
        private readonly IBillingService _billingService = billingService;

        public Coaster CreateCoaster(Venue venue)
        {
            var ret = new Coaster() { Venue = venue };
            Update(ret);

            return ret;
        }

        public async Task<Coaster> GetCurrentCoasterByPositionAsync(GeoPosition position, int locationThreshold)
        {
            Coaster ret = null;
            if (position == null)
            {
                return ret;
            }

            var current = await _repo.GetAllAsync();
            if (current.Count == 0)
            {
                return ret;
            }
            // this is not possible in a DB query
            current = current.Where(item => LocationUtils.IsNear(item.Venue?.Location, position, locationThreshold)).OrderBy(it => it.Updated).ToList();
            if (current.Count > 1)
            {
                return current.Last();
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

            var current = await _repo.GetListAsync(item => item.Venue.Id == source.Id);
            if (current.Count == 0)
            {
                return ret;
            }
            return current.FirstOrDefault();
        }

        public Task<List<Coaster>> GetOpenCoastersAsync()
        {
            return _repo.GetAllAsync();
        }

        public bool PayCoaster(Coaster source)
        {
            if (source == null)
            {
                return false;
            }

            var bill = _billingService.CreateBill(source);
            _billingService.Update(bill);

            _repo.Delete(source);
            return _repo.Flush() > 0;
        }

        public new void Update(Coaster source)
        {
            if (source.Venue == null)
            {
                return;
            }
            base.Update(source);
        }

        public async Task<Coaster> GetLatest(int timeThreshold)
        {
            var latest = await _repo.GetLatest();
            if (latest == null)
            {
                return latest;
            }

            if (DateTime.Now - latest.Updated > new TimeSpan(timeThreshold, 0, 0))
            {
                latest = null;
            }
            return latest;
        }
    }
}
