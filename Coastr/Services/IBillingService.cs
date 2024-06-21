using Coastr.Model;
using CoastR.Model;

namespace Coastr.Services
{
    public interface IBillingService : IPersistenceAwareService<Bill>
    {
        Bill CreateBill(Coaster source);
    }
}