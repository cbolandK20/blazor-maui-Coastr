using Coastr.Persistence;

namespace Coastr.Services.Impl
{
    public class MenuService : AbstractPersistenceAwareService<IMenuRepository, Coastr.Model.Menu>, IMenuService
    {
        public MenuService(IMenuRepository repo) : base(repo) { }
    }
}
