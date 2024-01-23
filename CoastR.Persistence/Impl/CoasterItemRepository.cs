using Coastr.Model;


namespace Coastr.Persistence.Impl
{
    public class CoasterItemRepository : Repository<CoasterItem>, ICoasterItemRepository
    {
        public CoasterItemRepository(CoasterDBContext context) : base(context)
        {
        }
    }
}
