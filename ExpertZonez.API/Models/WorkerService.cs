using System.ComponentModel.DataAnnotations;

public class WorkerService
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int workerId { get; set; }
    public int serviceId { get; set; }
   
    public  Worker worker { get; set; } = null!;

    [Required]
    public  Service service { get; set; } = null!;
}