using ExpertZonez.API.Data;
using ExpertZonez.API.Models;
using ExpertZonez.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpertZonez.API.Repositories.Implementation
{
    public class GenreRepository:IGenreRepository
    {
        private readonly AppDbContext _context;
        public GenreRepository(AppDbContext _dbcontext)
        {
            _context = _dbcontext;
            
        }

       public async Task AddGenre(ServiceGenre genre)
        {
            _context.ServiceGenres.Add(genre);
            _context.SaveChanges();
        }

        public async Task DeleteGenre(ServiceGenre del)
        {
            _context.ServiceGenres.Remove(del);
            _context.SaveChanges();
        }

        public async Task<ServiceGenre> GetGenreById(int id)
        {
          ServiceGenre genById =  await _context.ServiceGenres.FindAsync(id);
            return genById;
        }

        public async Task<ServiceGenre> GetGenreWithServices(int id)
        {
          ServiceGenre GenreServices =   await _context.ServiceGenres.Include(x => x.services)
                .FirstOrDefaultAsync(u=>u.Id == id);
            return GenreServices;
        }

        public async Task UpdateGenre(ServiceGenre genre)
        {
            _context.ServiceGenres.Update(genre);
        }
    }
}
