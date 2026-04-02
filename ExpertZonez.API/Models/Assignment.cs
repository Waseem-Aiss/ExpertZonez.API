using ExpertZonez.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class Assignment
{
    [Key]
    public int assignmentId { get; set; }

    [Required]
    public int requestId { get; set; }
    public virtual ServiceRequest serviceRequest { get; set; } = null!;

    [Required]
    public int workerId { get; set; }
    public virtual Worker worker { get; set; } = null!;
    public AssignmentStatus status { get; set; } = AssignmentStatus.Pending;
    [Required]
    public int assignedByAdminId { get; set; } 

    public DateTime assignedAt { get; set; } = DateTime.Now;

    public string? adminNotes { get; set; }
}