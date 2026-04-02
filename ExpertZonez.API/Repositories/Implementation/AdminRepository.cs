using ExpertZonez.API.Data;
using ExpertZonez.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpertZonez.API.Models.Enums;
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;
using ExpertZonez.API.Repositories.Interfaces;


namespace ExpertZonez.API.Repositories.Implementation

{
   public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _dbContext;

        public AdminRepository(AppDbContext _Context)
        {
            _dbContext = _Context;
            
        }
      public async Task<(Assignment data , string error)> AssignToWorker(AssignWorkerDto dto)
        {
            var request = await _dbContext.ServiceRequests.FindAsync(dto.requestId);
            var worker = await _dbContext.Workers.FindAsync(dto.workerId);

            if (request == null || worker == null)
                return (null, "Service Request not found.");


            if (!worker.didWorkerIsApproved)
                return (null, "Worker is not approved yet.");


            var assignment = new Assignment
            {
                requestId = dto.requestId,
                workerId = dto.workerId,
                adminNotes = dto.adminNotes,
                assignedAt = DateTime.Now,
                assignedByAdminId = 1
            };


            request.requestStatus = AssignmentStatus.Assigned;

            _dbContext.Assignments.Add(assignment);
            await _dbContext.SaveChangesAsync();

            return (assignment, null);



        }

        public async Task<List<ServiceRequest>> GetPendingRequests() // for List of getting pending requests access by admin
        {
          var pending = await _dbContext.ServiceRequests
                .Where(r => r.requestStatus == AssignmentStatus.Pending)
                .Include(r => r.service)
                .ToListAsync();
             return pending;
            
        }

        public async Task<Service> PostService(CreateServiceDto serviceDto) // Adding New Service
            {
            var service = new Service
            {
                serviceName = serviceDto.serviceName,
                serviceDescription = serviceDto.serviceDescription,
                serviceIcon = serviceDto.serviceIcon
            };

            _dbContext.Services.Add(service);
            await _dbContext.SaveChangesAsync();

            return (service);

        }
        public async Task<IEnumerable<Service>> GetAllServices() // For Getting List of All Services
        {
            return await _dbContext.Services.ToListAsync();
        }
        public async Task<Service> GetDeleteService(int id)   
        {
            Service foundService = await _dbContext.Services.FindAsync(id);
            return foundService;
        }
        public async Task<bool> DeleteService(Service obj)
        {
                    _dbContext.Services.Remove(obj);
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
            
        }
        public async Task<Service> GetEditService(int id)
        {
            Service Updatedservice = await _dbContext.Services.FindAsync(id);
            return Updatedservice;
        }
        public async Task<Service> EditService(Service obj)
        {
            

            _dbContext.Services.Update(obj);
            await _dbContext.SaveChangesAsync();
             return (obj);


        }
        public async Task<bool> ApproveWorker(int id)
        {
            var worker = await _dbContext.Workers.FindAsync(id);
            if (worker == null) {
                
                return (false);
            }
            worker.didWorkerIsApproved = true;
            await _dbContext.SaveChangesAsync();
            return (true);

        }
        public async Task<IEnumerable<Worker>> GetWorkers()
        {
            return await _dbContext.Workers
                .Include(w => w.WorkerServices)
                .ThenInclude(ws => ws.service)
                .ToListAsync();
        }
    }
}
