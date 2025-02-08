using MovieApp.Models;
using System.Linq.Expressions;
using System.Security.Principal;

namespace MovieApp.Core.DataAccess
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task Add(T entity);
        Task Update(T entity, Guid id);
        Task<T> Delete(Guid id);
    }
}
