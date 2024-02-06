namespace Coastr.Services
{
    public interface IMenuItemService : IPersistenceAwareService<Coastr.Model.MenuItem>
    {
        public Task<List<Coastr.Model.MenuItem>> SearchItemsByName(string query);

        public Task<Coastr.Model.MenuItem> SearchItemByNameAndVenueAsync(string name, int venueId);

        public Task<int> Delete(Model.MenuItem item);
    }
}
