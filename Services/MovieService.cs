using System.Collections.Generic;
using MovieGram.Data.Interfaces;
using MovieGram.Models;
using System.Threading.Tasks;
using MovieGram.Dtos;

namespace MovieGram.Services
{
    public class MovieService : IMovieService
    {
        private IUnitOfWork _unitOfWork { get; }

        public MovieService(IUnitOfWork unit) => _unitOfWork = unit;

        public async Task<ServiceResponse<IEnumerable<MovieDto>>> GetMovies()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<MovieDto>>
            {
                Data = await _unitOfWork.Movies.GetMovies()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<MovieDetailsDto>> GetMovie(int id)
        {
            var serviceResponse = new ServiceResponse<MovieDetailsDto>
            {
                Data = await _unitOfWork.Movies.GetMovieById(id)
            };
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No movie found related to Movie Id: " + id;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ICollection<MovieDetailsDto>>> GetMovies(string searchText)
        {
            var serviceResponse = new ServiceResponse<ICollection<MovieDetailsDto>>
            {
                Data = await _unitOfWork.Movies.SearchMovies(searchText)
            };
            if (serviceResponse.Data.Count == 0)
            {
                serviceResponse.Message = "No movie found related to search text: " + searchText;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}