using ExpertZonez.API.Models;

namespace ExpertZonez.API.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task AddGenre(ServiceGenre genre);
        

        Task<ServiceGenre> GetGenreById(int id);

        Task UpdateGenre(ServiceGenre genre);

        Task DeleteGenre(ServiceGenre del);
        Task<ServiceGenre> GetGenreWithServices(int id); 
    }
}
