using Coastr.Model;
using Coastr.Persistence;

namespace Coastr.Services.Impl
{
    public class CoasterItemService(ICoasterItemRepository repo) : AbstractPersistenceAwareService<ICoasterItemRepository, CoasterItem>(repo), ICoasterItemService
    {
        public CoasterItem AddToCoaster(CoasterItem source, Coaster parent)
        {
            source.Coaster = parent;
            parent.Items.Add(source);

            var ret = _repo.Add(source);
            _repo.SaveAll();

            return ret;
        }

        public CoasterItem AddToCoaster(Model.MenuItem source, int index, Coaster parent)
        {
            var newItem = new CoasterItem()
            {
                MenuItem = source,
                Count = 1,
                Index = index,
            };

            return AddToCoaster(newItem, parent);
        }

        public void DeleteItem(CoasterItem source)
        {
            source.Coaster.Items.Remove(source);
            _repo.Delete(source);
            _repo.SaveAll();
        }

        public void DeleteFromCoaster(Model.MenuItem source)
        {
            _repo.Delete(it => it.MenuItem.Id == source.Id);
            _repo.SaveAll();
        }
    }
}
