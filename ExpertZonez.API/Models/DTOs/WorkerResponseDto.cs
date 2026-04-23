namespace ExpertZonez.API.Models.DTOs
{
    public class WorkerResponseDto
    {
        public string workerName { get; set; } = null!;
        public string workerPhoneNumber { get; set; } = null!;
        public string workerCNIC { get; set; } = null!;
        public int workerExperienceYears { get; set; }
        public string workerAddress { get; set; } = null!;

        public List<int> serviceIds { get; set; }
    }
}