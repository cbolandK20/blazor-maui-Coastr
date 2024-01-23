using Coastr.Persistence;

namespace Coastr.Services.Impl
{
    public class MenuItemService : AbstractPersistenceAwareService<IMenuItemRepository, Coastr.Model.MenuItem>, IMenuItemService
    {
        public MenuItemService(IMenuItemRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Coastr.Model.MenuItem>> SearchItemsByName(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _repo.GetAllAsync();
            }
            return _repo.GetListAsync(item => item.Name.Contains(query));
        }

        public async Task<Coastr.Model.MenuItem> SearchItemByNameAndVenueAsync(string name, int venueId)
        {
            var ret = await _repo.GetListAsync(item => item.Name.Equals(name) && item.Menu.Venue.Id == venueId);
            return ret.FirstOrDefault();
        }

    }
}
