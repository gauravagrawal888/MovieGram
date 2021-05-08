using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieGram.Data.Interfaces;
using MovieGram.Dtos;

namespace MovieGram.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;
        public MovieRepository(MovieContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            return await _context.Movies.Include(m => m.MovieShowtimes).
                            Select(m => new MovieDto()
                            {
                                MovieId = m.MovieId,
                                Title = m.Title,
                                Showtimes = m.MovieShowtimes.Select(c => c.Time).ToList()
                            }).ToListAsync();
        }
        public async Task<MovieDetailsDto> GetMovieById(int id)
        {
            return await _context.Movies.Include(m => m.MovieShowtimes).Select(m =>
                               new MovieDetailsDto()
                               {
                                   MovieId = m.MovieId,
                                   MovieTitle = m.Title,
                                   Description = m.Description,
                                   Genre = m.Genre,
                                   Language = m.Language,
                                   Director = m.Director,
                                   ReleaseDate = m.ReleaseDate,
                                   Showtimes = m.MovieShowtimes.Select(c => c.Time).ToList()
                               })
                .FirstOrDefaultAsync(m => m.MovieId == id);
        }
        public async Task<ICollection<MovieDetailsDto>> SearchMovies(string searchString)
        {
            return await _context.Movies.Include(m => m.MovieShowtimes)
                             .Where(a => a.Title.Contains(searchString)
                                    || a.Description.Contains(searchString)
                                    || a.Director.Contains(searchString)
                                    || a.Language.Contains(searchString)
                                    || a.Genre.Contains(searchString)
                                    || a.MovieShowtimes.Any(f => f.Time.Contains(searchString))
                                    )
                                 .Select(m =>new MovieDetailsDto()
                                 {
                                     MovieId = m.MovieId,
                                     MovieTitle = m.Title,
                                     Description = m.Description,
                                     Genre = m.Genre,
                                     Language = m.Language,
                                     Director = m.Director,
                                     ReleaseDate = m.ReleaseDate,
                                     Showtimes = m.MovieShowtimes.Select(c => c.Time).ToList()
                                 }).ToListAsync();
        }
    }
}