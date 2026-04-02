using ExpertZonez.API.Data;
using ExpertZonez.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpertZonez.API.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        public Task<Service> PostService(CreateServiceDto serviceDto);
        public Task<Service> GetDeleteService(int id);
        public Task<bool> DeleteService(Service ojb);
        public Task<Service> GetEditService(int id);
        public Task<Service> EditService(Service id);
        public Task<(Assignment data, string error)> AssignToWorker(AssignWorkerDto dto);
        public Task<List<ServiceRequest>> GetPendingRequests();
        public  Task<IEnumerable<Service>> GetAllServices();
        public Task<bool> ApproveWorker(int id);
        public Task<IEnumerable<Worker>> GetWorkers();
    }
}
