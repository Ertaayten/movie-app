using MovieApp.Core.DataAccess;
using MovieApp.DataAccess.Abstracts;
using MovieApp.Models;

namespace MovieApp.DataAccess.Concretes
{
    public class DirectorRepository : BaseRepository<Director, MainDbContext>, IDirectorRepository
    {
        public DirectorRepository(MainDbContext context) : base(context)
        {
        }
    }
}
