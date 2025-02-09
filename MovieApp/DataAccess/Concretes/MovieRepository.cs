using Microsoft.EntityFrameworkCore;
using MovieApp.Core.DataAccess;
using MovieApp.DataAccess.Abstracts;
using MovieApp.Models;
using System.Linq.Expressions;

namespace MovieApp.DataAccess.Concretes
{
    public class MovieRepository : BaseRepository<Movie, MainDbContext>, IMovieRepository
    {
        private readonly MainDbContext _context;
        public MovieRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllWithNavigationAsync(Expression<Func<Movie, bool>> filter = null)
        {
            return filter == null
                ? await _context.Set<Movie>().Include(x => x.Director)
                    .Include(x => x.MovieActors).Include(x => x.MovieCategories).ToListAsync()
                : await _context.Set<Movie>().Include(x => x.Director)
                    .Include(x => x.MovieActors).Include(x => x.MovieCategories).Where(filter).ToListAsync();
        }

        public async Task<Movie> GetWithNavigationAsync(Expression<Func<Movie, bool>> filter = null)
        {
            return await _context.Set<Movie>().Include(x=> x.Director).FirstOrDefaultAsync(filter);

        }
    }
}
