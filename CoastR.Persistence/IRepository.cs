using System.Linq.Expressions;

namespace Coastr.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<int> SaveAllAsync();
        
        public int SaveAll();

        public TEntity Add(TEntity source);

        public TEntity Update(TEntity source);

        public void Update(IEnumerable<TEntity> source);

        public void Delete(TEntity source);
        public Task<TEntity?> GetAsync(int id);

        public IList<TEntity> GetAll();

        public Task<List<TEntity>> GetAllAsync();

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        
    }
}