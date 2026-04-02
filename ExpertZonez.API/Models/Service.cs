
using System.ComponentModel.DataAnnotations;

public class Service
{
    [Key]
    public int serviceId { get; set; }

    [Required, StringLength(50)]
    public string serviceName { get; set; } = null!; // Plumber, Electrician etc.

    [StringLength(500)]
    public string? serviceDescription { get; set; }

    public string? serviceIcon { get; set; } // URL or CSS class name

    // Navigation property for Many-to-Many
    public virtual ICollection<WorkerService> workerServices { get; set; } = new List<WorkerService>();
}