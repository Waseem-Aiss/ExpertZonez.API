namespace ExpertZonez.API.Models.DTOs
{
    public class AssignWorkerDto
    {
        public int requestId { get; set; } 
        public int workerId { get; set; }  
        public string? adminNotes { get; set; } 
    }
}
