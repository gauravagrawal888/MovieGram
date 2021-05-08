using Microsoft.EntityFrameworkCore;
using MovieGram.Models;

namespace MovieGram.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieShowtimes> MovieShowTimes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
             .HasData(
              new Movie
              {
                  MovieId = 1,
                  Director = "D.W.Young",
                  Description = "Events escalate from weird to terrifying as they contend with the house's batty owner, her imposing son, a moody Swedish lepidopterist, a pedantic English professor, an extraordinarily rare butterfly, the world's best blueberry muffins, a .44 Magnum, a demented serial killer, and one very strict rulebook.",
                  Genre = "Suspense",
                  Title = "The Happy House",
                  Language = "English",
                  ReleaseDate = System.DateTime.Now
              },
              new Movie
              {
                  MovieId = 2,
                  Director = "Frank R. Strayer",
                  Description = "When corpses drained of blood begin to show up in a European village, vampirism is suspected to be responsible.",
                  Genre = "Horror",
                  Title = "The Vampire Bat",
                  Language = "German",
                  ReleaseDate = System.DateTime.Now.AddDays(3)
              },
              new Movie
              {
                  MovieId = 3,
                  Director = "Matthew A. Cherry",
                  Description = "After several years playing NFL professional football, 25 year-old Kyle Bishop (Lance Gross) is released from his fourth team in three years. Kyle returns to his hometown, broke and at a complete loss about what he will do for a living. After an initially cold reception.",
                  Genre = "Romance",
                  Title = "The Last Fall",
                  Language = "English",
                  ReleaseDate = System.DateTime.Now.AddDays(6)
              },
              new Movie
              {
                  MovieId = 4,
                  Director = "George A. Romero",
                  Description = "A travelling troupe of jousters and performers are slowly cracking under the pressure of hick cops, financial troubles and their failure to live up to their own ideals. The group's leader, King Billy, is increasingly unable to maintain his warrior's rule while the Black Knight is being tempted away to LA and stardom.",
                  Genre = "Drama",
                  Title = "Knightriders",
                  Language = "Swedish",
                  ReleaseDate = System.DateTime.Now.AddDays(9)
              }
             );

            modelBuilder.Entity<MovieShowtimes>()
           .HasData(
            new MovieShowtimes { MovieShowtimeId = 1, MovieId = 1, Time = "10:00" },
            new MovieShowtimes { MovieShowtimeId = 2, MovieId = 1, Time = "12:00" },
            new MovieShowtimes { MovieShowtimeId = 3, MovieId = 1, Time = "14:00" },
            new MovieShowtimes { MovieShowtimeId = 4, MovieId = 1, Time = "16:00" },
            new MovieShowtimes { MovieShowtimeId = 5, MovieId = 2, Time = "11:00" },
            new MovieShowtimes { MovieShowtimeId = 6, MovieId = 2, Time = "12:00" },
            new MovieShowtimes { MovieShowtimeId = 7, MovieId = 2, Time = "14:00" },
            new MovieShowtimes { MovieShowtimeId = 8, MovieId = 2, Time = "17:00" },
            new MovieShowtimes { MovieShowtimeId = 9, MovieId = 3, Time = "16:00" },
            new MovieShowtimes { MovieShowtimeId = 10, MovieId = 3, Time = "17:00" },
            new MovieShowtimes { MovieShowtimeId = 11, MovieId = 3, Time = "18:00" },
            new MovieShowtimes { MovieShowtimeId = 12, MovieId = 3, Time = "19:00" },
            new MovieShowtimes { MovieShowtimeId = 13, MovieId = 4, Time = "10:00" },
            new MovieShowtimes { MovieShowtimeId = 14, MovieId = 4, Time = "13:00" },
            new MovieShowtimes { MovieShowtimeId = 15, MovieId = 4, Time = "15:00" },
            new MovieShowtimes { MovieShowtimeId = 16, MovieId = 4, Time = "18:00" }
           );
        }
    }
}