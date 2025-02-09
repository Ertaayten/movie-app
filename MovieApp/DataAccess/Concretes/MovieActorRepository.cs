using MovieApp.Core.DataAccess;
using MovieApp.DataAccess.Abstracts;
using MovieApp.Models;

namespace MovieApp.DataAccess.Concretes
{
    public class MovieActorRepository : BaseRepository<MovieActor, MainDbContext>, IMovieActorRepository
    {
        public MovieActorRepository(MainDbContext context) : base(context)
        {
        }
    }
}
