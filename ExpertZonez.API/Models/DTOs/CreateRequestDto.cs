namespace ExpertZonez.API.Models.DTOs
{
    public class CreateRequestDto
    {
        public int serviceId { get; set; } // Konsi service chahiye?
        public string custName { get; set; } = null!;
        public string custPhoneNumber { get; set; } = null!;
        public string custLocation { get; set; } = null!;
        public DateTime serviceDateAndTIme { get; set; }
    }
}
