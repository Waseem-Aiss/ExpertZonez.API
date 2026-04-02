using ExpertZonez.API.Data;
using ExpertZonez.API.DTOs;
using ExpertZonez.API.Models.Enums;
using ExpertZonez.API.Repositories.Implementation;
using ExpertZonez.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace ExpertZonez.API.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminToWorkerController : ControllerBase
    {
        private readonly IAdminRepository _repo;

        public AdminToWorkerController(IAdminRepository repo)
        {
            _repo =  repo;
        }

        
        [HttpPost("assign-worker")]
        public async Task<IActionResult> AssignWorker(AssignWorkerDto dto)
        {
           var (data, error) = await _repo.AssignToWorker(dto);
            if (error != null) 
            { 
            return BadRequest(error);

            }
            else
            {
                return Ok(data);
            }
         }
        
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveWorker(int id)
        {
            bool isApproved = await _repo.ApproveWorker(id);
            if(isApproved==false)
            return Ok("Worker is not Available in List");
            else
            {
                return Ok("Worker is Approved");
            }
        }
        [HttpGet("get-workers")]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
        {
            IEnumerable<Worker> workers = await _repo.GetWorkers();
            if (workers == null)
            {
                return BadRequest(string.Empty);
            }

            return Ok(workers);
        }

    }
}