using Coastr.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Coastr.Persistence.Impl
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : AbstractPersistenceBase
    {
        protected DbSet<TEntity> _dbSet { get; private set; }
        private CoasterDBContext _context;

        public Task<int> SaveAllAsync()
        {
            return _context.SaveChangesAsync(); 
        }

        public TEntity Add(TEntity source)
        {
           return _dbSet.Add(source).Entity;        
        }

        public TEntity Update(TEntity source)
        {
            source.Updated = DateTime.Now;
            return _dbSet.Update(source).Entity;
        }

        public void Update(IEnumerable<TEntity> source)
        {
            foreach (var item in source)
            {
                item.Updated = DateTime.Now;
            }
            _dbSet.UpdateRange(source);
        }

        public int SaveAll()
        {            
            return _context.SaveChanges();
        }

        public Repository(CoasterDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }


        public Task<TEntity?> GetAsync(int id)
        {
            return _dbSet.FirstOrDefaultAsync(item => item.Id == id);
        }


        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();

        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.AsQueryable().ToListAsync();

        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate).ToListAsync();            

        }
        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetListAsync(predicate).GetAwaiter().GetResult();

        }

        public void Delete(TEntity source)
        {
            _dbSet.Remove(source);
        }
    }
}
