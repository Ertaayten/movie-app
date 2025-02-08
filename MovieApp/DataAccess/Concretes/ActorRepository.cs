using MovieApp.Core.DataAccess;
using MovieApp.DataAccess.Abstracts;
using MovieApp.Models;

namespace MovieApp.DataAccess.Concretes
{
    public class ActorRepository : BaseRepository<Actor, MainDbContext>, IActorRepository
    {
        public ActorRepository(MainDbContext context) : base(context)
        {
        }
    }
}

