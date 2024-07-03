using Coastr.Model;
using Coastr.Persistence;
using CoastR.Model;

namespace Coastr.Services.Impl
{
    public class BillingService(IBillRepository repo) : AbstractPersistenceAwareService<IBillRepository, Bill>(repo), IBillingService
    {
        public Bill CreateBill(Coaster source)
        {
            var ret = new Bill()
            {
                VenueLocation = source.Venue?.Location,
                VenueName = source.Venue?.Name
            };
            foreach (var item in source.Items)
            {
                var newItem = CreateItem(item);
                if (newItem != null)
                {
                    ret.Items.Add(newItem);
                }
            }

            ret.Sum = ret.Items.Sum(it => it.Sum);

            return ret;
        }

        private static BillItem CreateItem(CoasterItem source)
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
