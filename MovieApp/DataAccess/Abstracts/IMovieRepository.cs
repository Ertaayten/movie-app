using MovieApp.Core.DataAccess;
using MovieApp.Models;
using System.Linq.Expressions;

namespace MovieApp.DataAccess.Abstracts
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<List<Movie>> GetAllWithNavigationAsync(Expression<Func<Movie, bool>> filter = null);
        Task<Movie> GetWithNavigationAsync(Expression<Func<Movie, bool>> filter = null);
    }
}
