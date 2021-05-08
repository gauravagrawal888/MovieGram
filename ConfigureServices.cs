using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieGram.Services;
using MovieGram.Data;
using MovieGram.Data.Interfaces;
using MovieGram.Models;

namespace MovieGram
{
     public static class ConfigureServices
     {
         public static void ConfigureService(this IServiceCollection services, IConfiguration Configuration)
         {
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<MovieContext>();
        }
     }
}