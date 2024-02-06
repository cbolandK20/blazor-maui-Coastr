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
                .OrderByDescending(p => p.Updated)
                .FirstOrDefaultAsync();
        }
    }
}
