

using CoastR.Model;

namespace Coastr.Persistence.Impl
{
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        public BillRepository(CoasterDBContext context) : base(context)
        {
        }
    }
}
