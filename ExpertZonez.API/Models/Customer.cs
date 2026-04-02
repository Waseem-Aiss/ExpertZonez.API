using ExpertZonez.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int custId { get; set; }

    [Required, StringLength(100)]
    public string custName { get; set; } = null!;

    [Required, Phone, StringLength(15)]
    public string custPhoneNumber { get; set; } = null!;

    [EmailAddress, StringLength(150)]
    public string? custEmail { get; set; } 

    [Required]
    public string custPasswordHash { get; set; } = null!;

    [Required, StringLength(20)]
    public Role custRole { get; set; } = Role.Customer; 

    public DateTime custCreatedAt { get; set; } = DateTime.Now;
}