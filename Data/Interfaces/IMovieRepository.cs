using System.Collections.Generic;
using System.Threading.Tasks;
using MovieGram.Dtos;

namespace MovieGram.Data.Interfaces
{
    public interface IMovieRepository 
    {
        Task<IEnumerable<MovieDto>> GetMovies();
        Task<MovieDetailsDto> GetMovieById(int id);
        Task<ICollection<MovieDetailsDto>> SearchMovies(string searchText);
    }
}