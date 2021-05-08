using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieGram.Models
{
    public class Movie
    {
        public Movie() => this.MovieShowtimes = new HashSet<MovieShowtimes>();
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Director { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public ICollection<MovieShowtimes> MovieShowtimes { get; set; }
    }
}