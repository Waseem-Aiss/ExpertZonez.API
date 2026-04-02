using ExpertZonez.API.Data;
using ExpertZonez.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpertZonez.API.Models.Enums;
using ExpertZonez.API.Repositories.Interfaces;

namespace ExpertZonez.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestRepository _repo;

        public RequestsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        
        [HttpPost("submit-request")]
        public async Task<IActionResult> SubmitRequest(CreateRequestDto dto)
        {

          var (requestedServiceStatus , info) = await _repo.CustSubmitRequest(dto);
            if (requestedServiceStatus != null)
            {
                return BadRequest(info);
            }
            else
            {
                return Ok(requestedServiceStatus);
            }
        }

       
        
    }
}