using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieGram.Services;
using System;
using MovieGram.Dtos;

namespace MovieGram.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService MovieService;
        public MoviesController(IMovieService movieService) => MovieService = movieService;

        /// <summary>
        /// Get all movie titles, their show times
        /// </summary>
        /// <returns></returns>
        //api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            try
            {
                var movies = await MovieService.GetMovies();
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get movie details by movie id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //api/movies/1
        [HttpGet("{id:int}")]
        public  async Task<ActionResult<IEnumerable<MovieDetailsDto>>> GetMovieById(int id)
        {
            try
            {
                var movie = await MovieService.GetMovie(id);
                
                if (movie.Data == null)
                {
                    return NotFound(movie);
                }
                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Search movie on the basis of title, description text,director, genre, language, show time
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ICollection<MovieDetailsDto>>> Get(string searchText)
        {
            try
            {
                var movies = await MovieService.GetMovies(searchText);
                if (movies.Data.Count == 0)
                {
                    return NotFound(movies);
                }
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}