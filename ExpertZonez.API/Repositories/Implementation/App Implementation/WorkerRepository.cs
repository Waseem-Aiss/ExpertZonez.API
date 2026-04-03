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
        public async Task<Worker> RegisterWorker(RegisterWorkerDto dto)
        {
            var worker = new Worker
            {
                workerName = dto.workerName,
                workerPhoneNumber = dto.workerPhoneNumber,
                workerCNIC = dto.workerCNIC,
                workerExperienceYears = dto.workerExperienceYears,
                workerAddress = dto.workerAddress,
                didWorkerIsApproved = false,
                didWorkerIsActive = false
            };


            foreach (var sId in dto.workerServiceIds)
            {
                worker.WorkerServices.Add(new WorkerService { serviceId = sId });
            }

            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
            return worker;
        }

    }
}
