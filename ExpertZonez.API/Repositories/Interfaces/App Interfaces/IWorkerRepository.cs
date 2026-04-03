using ExpertZonez.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpertZonez.API.Repositories.Interfaces
{
    public interface IWorkerRepository
    {
        public Task<Worker> RegisterWorker(RegisterWorkerDto dto);

    }
}
