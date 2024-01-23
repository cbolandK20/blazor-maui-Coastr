

namespace Coastr.Persistence.Impl
{
    public class MenuItemRepository : Repository<Coastr.Model.MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(CoasterDBContext context) : base(context)
        {
        }
    }
}
