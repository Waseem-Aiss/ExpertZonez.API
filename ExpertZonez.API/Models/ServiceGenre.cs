using System.ComponentModel.DataAnnotations;

namespace ExpertZonez.API.Models
{
    public class ServiceGenre
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string genreName { get; set; }
        public List<Service> services { get; set; }


    }
}
