using ExpertZonez.API.Models;
using ExpertZonez.API.Repositories.Interfaces.App_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpertZonez.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    
        public class HomeController : ControllerBase
        {

            private readonly IHomeRepository _homeRepository;

            public HomeController(IHomeRepository homeRepository)
            {

                _homeRepository = homeRepository;
            }
        [HttpGet("get-services")]
            public async Task<DisplayServicesDto> Index(string sTerm = "", int genreId = 0, int pageNumber = 1)
            {
                var (service, totalPages) = await _homeRepository.GetServices(sTerm, genreId, 8, pageNumber);
                IEnumerable<ServiceGenre> Genres = await _homeRepository.Genres();

                DisplayServicesDto DisplayServices = new DisplayServicesDto
                {
                    services = service,
                    Genres = Genres,
                    pageSize = 8,
                    totalPages = totalPages,
                    currentPage = pageNumber,
                    sTerm = sTerm,
                    genreId = genreId
                };

                return (DisplayServices);
            }

        [HttpGet("get-genre")]
        public async Task<IEnumerable<ServiceGenre>> GetAllGenre()
        {
          return  await _homeRepository.Genres();
        }
       
        [HttpGet("get-services-by-genreId-homecontr/{id}")]
        public async Task<IEnumerable<Service>> GetGenreWithServices_Cont(int id)
        {
            var servicesList = await _homeRepository.GetGenreWithServices(id);
            return servicesList;
        }


    }
}

