using Coastr.Model;
using Coastr.Persistence;
using System.Linq.Expressions;

namespace Coastr.Services.Impl
{
    public abstract class AbstractPersistenceAwareService<TRepository, TModel> : IPersistenceAwareService<TModel> where TRepository : IRepository<TModel>
        where TModel : AbstractPersistenceBase
    {

        protected TRepository _repo;

        public AbstractPersistenceAwareService(TRepository repo)
        {
            _repo = repo;
        }

        public Task<TModel> GetAsync(int Id)
        {
            return _repo.GetAsync(Id);
        }

        public IList<TModel> GetAll()
        {
            return _repo.GetAllAsync().GetAwaiter().GetResult();
        }

        public Task<List<TModel>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<List<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate)
        {
            return _repo.GetListAsync(predicate);
        }

        public IList<TModel> GetList(Expression<Func<TModel, bool>> predicate)
        {
            return _repo.GetList(predicate);
        }


        public TModel Save(TModel source)
        {
            var ret = _repo.Update(source);
            _repo.SaveAll();

            return ret;
        }
        public async Task SaveAllAsync()
        {
            await _repo.SaveAllAsync();
        }
    }
}
