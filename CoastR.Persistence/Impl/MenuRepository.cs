

namespace Coastr.Persistence.Impl
{
    public class MenuRepository : Repository<Coastr.Model.Menu>, IMenuRepository
    {
        public MenuRepository(CoasterDBContext context) : base(context)
        {
        }
    }
}
