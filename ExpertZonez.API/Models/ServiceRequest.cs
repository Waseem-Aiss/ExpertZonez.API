using ExpertZonez.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class ServiceRequest
{
    [Key]
    public int serviceRequestId { get; set; }  // Id of Service generated

    [Required]
    public int serviceId { get; set; }
    public virtual Service service { get; set; } = null!;

    public int? userId { get; set; }
    public virtual Customer? user { get; set; }

    [Required, StringLength(100)]            // Usr data name s aye ga lakin jb user register nh to us k liye detail
    public string  custName { get; set; } = null!;



    [Required, Phone]
    public string custPhoneNumber { get; set; } = null!;

    [Required]
    public string custLocation { get; set; } = null!;


    [Required]
    public DateTime serviceDateAndTIme{ get; set; }

    [Required]
    public AssignmentStatus requestStatus { get; set; } = AssignmentStatus.Pending; // Pending, Assigned, Completed, Cancelled
    
    [Required]
    public DateTime createdAt { get; set; } = DateTime.Now;
}