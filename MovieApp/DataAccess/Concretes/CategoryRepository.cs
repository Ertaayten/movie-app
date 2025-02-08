using MovieApp.Core.DataAccess;
using MovieApp.DataAccess.Abstracts;
using MovieApp.Models;

namespace MovieApp.DataAccess.Concretes
{
    public class CategoryRepository : BaseRepository<Category, MainDbContext>, ICategoryRepository
    {
        public CategoryRepository(MainDbContext context) : base(context)
        {
        }
    }
}
