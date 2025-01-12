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

        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);

            builder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "Movie_Actors",
                    j => j.HasOne<Actor>().WithMany()
                        .HasForeignKey("ActorId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId").OnDelete(DeleteBehavior.Cascade)
                );

            builder.Entity<Movie>()
                 .HasMany(m => m.Categories)
                 .WithMany()
                 .UsingEntity<Dictionary<string, object>>(
                     "Movie_Categories",
                     j => j.HasOne<Category>().WithMany()
                         .HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Cascade),
                     j => j.HasOne<Movie>().WithMany()
                         .HasForeignKey("MovieId").OnDelete(DeleteBehavior.Cascade)
                 );
        }
    }
}
