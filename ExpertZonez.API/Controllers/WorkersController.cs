using ExpertZonez.API.Data;
using ExpertZonez.API.DTOs;
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

        
        [HttpPost("register-worker")]
        public async Task<IActionResult> RegisterWorker(RegisterWorkerDto dto)
        {
            
         var registerWorker  =   _repo.RegisterWorker(dto);
            return Ok(new { message = "Registration successful! Wait for Admin approval." });
        }

        
        

        
        
    }
}