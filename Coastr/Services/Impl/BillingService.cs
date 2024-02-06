using Coastr.Model;
using Coastr.Persistence;
using CoastR.Model;

namespace Coastr.Services.Impl
{
    public class BillingService : AbstractPersistenceAwareService<IBillRepository, Bill>, IBillingService
    {

        public BillingService(IBillRepository repo) : base(repo)
        {
        }
        public Bill CreateBill(Coaster source)
        {
            var ret = new Bill();

            ret.VenueLocation = source.Venue?.Location;
            ret.VenueName = source.Venue?.Name;

            foreach (var item in source.Items)
            {
                var newItem = createItem(item);
                if (newItem != null)
                {
                    ret.Items.Add(newItem);
                }
            }

            ret.Sum = ret.Items.Sum(it => it.Sum);

            return ret;
        }

        private BillItem createItem(CoasterItem source)
        {
            if (source == null)
            {
                return null;
            }

            var ret = new BillItem()
            {
                Name = source.MenuItem.Name,
                Price = source.MenuItem.Price,
                Count = source.Count,
                Sum = source.Count * source.MenuItem.Price
            };

            return ret;
        }
    }
}
