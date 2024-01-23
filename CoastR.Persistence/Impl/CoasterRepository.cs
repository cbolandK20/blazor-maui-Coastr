using Coastr.Model;
using Microsoft.EntityFrameworkCore;


namespace Coastr.Persistence.Impl
{
    public class CoasterRepository : Repository<Coaster>, ICoasterRepository
    {
        public CoasterRepository(CoasterDBContext context) : base(context)
        {            
        }

        public Task<Coaster?> GetLatest()
        {
            return _dbSet
                .Where(it => it.State == ObjectState.MOVING)
                .OrderByDescending(p => p.Updated)
                .FirstOrDefaultAsync();
        }
    }
}
