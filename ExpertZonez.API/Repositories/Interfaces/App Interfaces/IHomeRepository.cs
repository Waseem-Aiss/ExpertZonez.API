using ExpertZonez.API.Models;

namespace ExpertZonez.API.Repositories.Interfaces.App_Interfaces
{
    public interface IHomeRepository
    {
        public Task<(IEnumerable<Service> services, int totalPages)> GetServices(string sTerm = "", int genreId = 0,
                int pageSize = 8, int pageNumber = 1);
        public Task<IEnumerable<ServiceGenre>> Genres();
        
        public Task<IEnumerable<Service>> GetGenreWithServices(int id);

    }


}
