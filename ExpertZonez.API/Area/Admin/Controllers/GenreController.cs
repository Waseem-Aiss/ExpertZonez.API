using ExpertZonez.API.Models;
using ExpertZonez.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpertZonez.API.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _repo;
        public GenreController(IGenreRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("add-genre")]
        public async Task AddGenre(ServiceGenre genre)
        {
           await _repo.AddGenre(genre);
        }

        [HttpGet("get-genre-by-id")]
       public async Task<ServiceGenre> GetGenreById(int id)
        {
          ServiceGenre serviceGenre =   await _repo.GetGenreById(id);
            return serviceGenre;
        }
        [HttpPost("update-genre")]
        public async Task UpdateGenre(ServiceGenre genre)
        {
            await _repo.UpdateGenre(genre);
        }
        [HttpPost("delete-genre")]
       public async Task DeleteGenre(ServiceGenre del)
        {
           await _repo.DeleteGenre(del);
        }
        [HttpGet("get-services-by-genreId")]
        public async Task<ServiceGenre> GetGenreWithServices_Cont(int id)
        {
           ServiceGenre _serviceGenre = await _repo.GetGenreWithServices(id);
            return _serviceGenre;
        }
    }
}
