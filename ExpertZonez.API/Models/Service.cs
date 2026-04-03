
using ExpertZonez.API.Models;
using System.ComponentModel.DataAnnotations;

public class Service
{
    [Key]
    public int serviceId { get; set; }

    [Required, StringLength(50)]
    public string serviceName { get; set; } = null!; // Plumber, Electrician etc.

    [StringLength(500)]
    public string? serviceDescription { get; set; }

    public string serviceImage { get; set; } // URL or CSS class name


    //foreign key of ServiceGenre Table
    public int genreId { get; set; }
    public ServiceGenre Genre { get; set; }

    // Navigation property for Many-to-Many
    public virtual ICollection<WorkerService> workerServices { get; set; } = new List<WorkerService>();
}