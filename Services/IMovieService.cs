using System.Collections.Generic;
using System.Threading.Tasks;
using MovieGram.Dtos;
using MovieGram.Models;

namespace MovieGram.Services
{
    public interface IMovieService
    {
        Task<ServiceResponse<IEnumerable<MovieDto>>> GetMovies();
        Task<ServiceResponse<MovieDetailsDto>> GetMovie(int id);
        Task<ServiceResponse<ICollection<MovieDetailsDto>>> GetMovies(string searchString);
    }
}