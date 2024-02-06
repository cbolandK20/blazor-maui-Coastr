

using CoastR.Model;

namespace Coastr.Persistence.Impl
{
    public class BillItemRepository : Repository<BillItem>, IBillItemRepository
    {
        public BillItemRepository(CoasterDBContext context) : base(context)
        {
        }
    }
}
