using System.ComponentModel.DataAnnotations;

namespace MovieGram.Models
{
    public class MovieShowtimes
    {
        [Key]
        public int MovieShowtimeId { get; set; }
        [Required]
        public int MovieId { get; set; }
        public string Time { get; set; }
    }
}