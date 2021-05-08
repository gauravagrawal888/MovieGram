using System;
using System.Collections.Generic;

namespace MovieGram.Dtos
{
    public class MovieDetailsDto
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<string> Showtimes { get; set; }
    }
}