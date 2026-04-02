namespace ExpertZonez.API.DTOs
{
    public class CreateServiceDto
    {
        public string serviceName { get; set; } = null!;
        public string? serviceDescription { get; set; }
        public string? serviceIcon { get; set; }
        
    }
}
