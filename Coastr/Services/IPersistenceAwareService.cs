using Coastr.Model;
using System.Linq.Expressions;

namespace Coastr.Services
{
    public interface IPersistenceAwareService<TModel> where TModel : AbstractPersistenceBase
    {
        Task<TModel> GetAsync(int Id);

        IList<TModel> GetAll();

        Task<List<TModel>> GetAllAsync();
                
        IList<TModel> GetList(Expression<Func<TModel, bool>> predicate);

        Task<List<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate);
        TModel Save(TModel source);

        public Task SaveAllAsync();
    }
}