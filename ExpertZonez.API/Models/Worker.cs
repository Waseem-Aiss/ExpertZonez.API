
using System.ComponentModel.DataAnnotations;

public class Worker
{
    [Key]
    public int workerId { get; set; }

    [Required, StringLength(100)]
    public string workerName { get; set; } = null!;

    [Required, StringLength(15)]
    public string workerPhoneNumber { get; set; } = null!;

    [Required, StringLength(15)]
    public string workerCNIC { get; set; } = null!;

    public int workerExperienceYears { get; set; }

    [Required, StringLength(250)]
    public string workerAddress { get; set; } = null!;

    public bool didWorkerIsApproved { get; set; } = false; 

    public bool didWorkerIsActive { get; set; } = false;

    public bool didWorkerIsDeleted { get; set; } = false;

    public DateTime workerCreatedAt { get; set; } = DateTime.Now;

    
    public virtual ICollection<WorkerService> WorkerServices { get; set; } = new List<WorkerService>();
}