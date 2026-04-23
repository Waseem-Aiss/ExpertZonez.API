using ExpertZonez.API.Data;
using ExpertZonez.API.Models.DTOs;
using ExpertZonez.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpertZonez.API.Repositories.Implementation
{
    public class WorkerRepository:IWorkerRepository
    {
        private readonly AppDbContext _context;
        public WorkerRepository(AppDbContext context)
        {
         _context = context;   
        }

        // Register a New Wo
        public async Task<WorkerResponseDto> Repo_RegisterWorker(RegisterWorkerDto dto)
        {
            var worker = new Worker
            {
                workerName = dto.workerName,
                workerPhoneNumber = dto.workerPhoneNumber,
                workerCNIC = dto.workerCNIC,
                workerExperienceYears = dto.workerExperienceYears,
                workerAddress = dto.workerAddress,
                didWorkerIsApproved = false,
                didWorkerIsActive = false,
                WorkerServices = new List<WorkerService>()
            };


            foreach (var sId in dto.workerServiceIds)
            {
                worker.WorkerServices.Add(new WorkerService { serviceId = sId });
            }

            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            return new WorkerResponseDto
            {
                workerName = worker.workerName,
                workerPhoneNumber = worker.workerPhoneNumber,
                workerCNIC = worker.workerCNIC,
                workerExperienceYears = worker.workerExperienceYears,
                workerAddress = worker.workerAddress,

                serviceIds = worker.WorkerServices.Select(ws => ws.serviceId).ToList() };
        }

    }
}
