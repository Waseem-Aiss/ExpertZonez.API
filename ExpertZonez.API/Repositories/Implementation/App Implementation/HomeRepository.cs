using ExpertZonez.API.Data;
using ExpertZonez.API.Models;
using ExpertZonez.API.Repositories.Interfaces.App_Interfaces;
using Microsoft.EntityFrameworkCore;

    

namespace ExpertZonez.API.Repositories.Implementation.App_Implementation
    {
        public class HomeRepository : IHomeRepository
    {
            private readonly AppDbContext _dbContext;
        public HomeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ServiceGenre>> Genres()
        {

            return await _dbContext.ServiceGenres.ToListAsync();
        }
        public async Task<(IEnumerable<Service> services, int totalPages)> GetServices(string sTerm = "", int genreId = 0,
                int pageSize = 8, int pageNumber = 1)
            {
                sTerm = sTerm.ToLower();

                var service = from services in _dbContext.Services
                           join Genre in _dbContext.ServiceGenres
                           on services.genreId equals Genre.Id
                           where string.IsNullOrWhiteSpace(sTerm) || (services != null && services.serviceName.ToLower().StartsWith(sTerm))
                           select new Service
                           {
                               serviceId = services.serviceId,
                             //  Image = service.serviceId,
                               //AuthorName = Book.AuthorName,
                               serviceName = services.serviceName,
                               genreId = services.genreId,
                               serviceImage = services.serviceImage, 
                              // Price = Book.Price,
                               Genre=Genre                       };

                if (genreId > 0)
                {
                    service = service.Where(a => a.genreId == genreId);
                }

                int totalServices = await service.CountAsync();
                int totalViewPages = (int)Math.Ceiling((totalServices / (double)pageSize));
                var pageData = await service.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                return (pageData, totalViewPages);

            }

        }
    }


