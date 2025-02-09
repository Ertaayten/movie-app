using MovieApp.Core.DataAccess;
using MovieApp.DataAccess.Abstracts;
using MovieApp.Models;

namespace MovieApp.DataAccess.Concretes
{
    public class MovieCategoryRepository : BaseRepository<MovieCategory, MainDbContext>, IMovieCategoryRepository
    {
        public MovieCategoryRepository(MainDbContext context) : base(context)
        {
        }
    }
}
