using Coastr.Model;
using Coastr.Persistence;

namespace Coastr.Services.Impl
{
    public class MenuItemService : AbstractPersistenceAwareService<IMenuItemRepository, Coastr.Model.MenuItem>, IMenuItemService
    {
        public MenuItemService(IMenuItemRepository repo) : base(repo) { }

        public Task<List<Coastr.Model.MenuItem>> SearchItemsByName(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _repo.GetAllAsync();
            }
            return _repo.GetListAsync(item => item.Name.StartsWith(query));
        }

        public async Task<Coastr.Model.MenuItem> SearchItemByNameAndVenueAsync(string name, int venueId)
        {
            var ret = await _repo.GetListAsync(item => item.Name.Equals(name) && item.Menu.Venue.Id == venueId);
            return ret.FirstOrDefault();
        }

        public async Task<int> Delete(Model.MenuItem item)
        {
            _repo.Delete(item);
            return await _repo.SaveAllAsync();
        }


        public async Task<List<Coastr.Model.MenuItem>> GetAllDistinctAsync()
        {
            var ret = await GetAllAsync();
            return ret.DistinctBy(item => item.Name).ToList();
        }
    }
}
