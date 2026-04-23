using ExpertZonez.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpertZonez.API.Repositories.Interfaces
{
    public interface IWorkerRepository
    {
         Task<WorkerResponseDto> Repo_RegisterWorker(RegisterWorkerDto dto);

    }
}
