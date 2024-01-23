using Coastr.Model;

namespace Coastr.Persistence.Impl
{
    public class VenueRepository : Repository<Venue>, IVenueRepository
    {
        public VenueRepository(CoasterDBContext context) : base(context)
        {
        }
    }
}
