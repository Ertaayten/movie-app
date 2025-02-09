using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.DataAccess
{
    public class MainDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);

            builder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            builder.Entity<MovieActor>()
               .HasOne(ma => ma.Actor)
               .WithMany(a => a.MovieActors)
               .HasForeignKey(ma => ma.ActorId);

            builder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(mc => mc.MovieId);

            builder.Entity<MovieCategory>()
               .HasOne(mc => mc.Category)
               .WithMany(c => c.MovieCategories)
               .HasForeignKey(mc => mc.CategoryId);

            builder.Entity<MovieCategory>()
                .Navigation(x => x.Category)
                .AutoInclude();

            builder.Entity<MovieCategory>()
             .Navigation(x => x.Movie)
             .AutoInclude();

            builder.Entity<MovieActor>()
             .Navigation(x => x.Movie)
             .AutoInclude();

            builder.Entity<MovieActor>()
             .Navigation(x => x.Actor)
             .AutoInclude();
        }
    }
}
