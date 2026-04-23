using ExpertZonez.API.Data;
using ExpertZonez.API.Models.DTOs;
using ExpertZonez.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpertZonez.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerRepository _repo;

        public WorkersController(IWorkerRepository repo)
        {
            _repo = repo;
        }

        //Register New Worker Action Method
        
        [HttpPost("register-worker")]
        public async Task<IActionResult> RegisterWorker(RegisterWorkerDto dto)
        {
            
         var registerWorker  = await  _repo.Repo_RegisterWorker(dto);
            return Ok(registerWorker);
        }

        
        

        
        
    }
}