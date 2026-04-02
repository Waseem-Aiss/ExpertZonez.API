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
    
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IAdminRepository _repo;

        public ServiceController(IAdminRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("pending-requests")]
        public async Task<IActionResult> GetPendingRequests()
        {
            var data = await _repo.GetPendingRequests();


            if (data == null || data.Count == 0)
            {
                return NotFound("No Data Found");
            }
            else
            {
                return Ok(data);
            }
        }
            
            [HttpPost("post-service")]  // for adding new Service
            public async Task<Service> PostService(CreateServiceDto serviceDto)
            {
                var postedService = await _repo.PostService(serviceDto);
                return (postedService);

            }
        [HttpGet("all-services")]
        public async Task<IEnumerable<Service>> GetAllServices()
        {

            return await _repo.GetAllServices();

        }
        [HttpGet("get-delete-preview")]
        public async Task<ActionResult<Service>> GetDeleteService(int id)
        {
            var foundData = await _repo.GetDeleteService(id);
            return (foundData);
        }
        [HttpPost("delete-service")]
        public async Task<IActionResult> DeleteService(Service obj)
        {
            bool isDeleted = await _repo.DeleteService(obj);
            return Ok("Deleted Seccessfull");
        }
        [HttpGet("get-edit-preview")]
        public async Task<Service> GetEditService(int id)
        {
            Service foundData = await _repo.GetEditService(id);
            return (foundData);
        }
        [HttpPost("edit-service")]
        public async Task<Service> EditService(Service obj)
        {
            Service UpdatedData = await _repo.EditService(obj);
            return (UpdatedData);
        }









    }
}
