using System;
using System.Collections.Generic;

namespace MovieGram.Dtos
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Showtimes { get; set; }
    }
}