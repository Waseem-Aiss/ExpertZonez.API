using System.ComponentModel.DataAnnotations;

namespace ExpertZonez.API.Models
{
    public class ServiceGenre
    {
        [Key]
        public int genreId { get; set; }
        public string genreName { get; set; }


    }
}
