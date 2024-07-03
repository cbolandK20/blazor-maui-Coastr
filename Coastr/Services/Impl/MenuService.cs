using Coastr.Persistence;

namespace Coastr.Services.Impl
{
    public class MenuService(IMenuRepository repo) : AbstractPersistenceAwareService<IMenuRepository, Coastr.Model.Menu>(repo), IMenuService
    {
        
    }
}
