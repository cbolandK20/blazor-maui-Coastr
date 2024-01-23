using Coastr.Model;

namespace Coastr.Services
{
    public interface ICoasterItemService : IPersistenceAwareService<CoasterItem>
    {
        public CoasterItem AddToCoaster(CoasterItem source, Coaster CoasterId);
        public void DeleteItem(CoasterItem source);
    }
}