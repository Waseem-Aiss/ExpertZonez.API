
using ExpertZonez.API.Models;
using ExpertZonez.API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ExpertZonez.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerService> WorkerServices { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<ServiceGenre> ServiceGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
    .HasOne(s => s.Genre)
    .WithMany(g => g.services)
    .HasForeignKey(s => s.GenreId);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

     
            modelBuilder.Entity<Service>().HasData(
                new Service { serviceId = 1, serviceName = "Plumber", serviceDescription = "All plumbing works", GenreId = 1 },
                new Service { serviceId = 2, serviceName = "Electrician", serviceDescription = "Electrical repairs", GenreId = 2 },
                new Service { serviceId = 3, serviceName = "Carpenter", serviceDescription = "Wood work", GenreId = 3 },
                new Service { serviceId = 4, serviceName = "Painter", serviceDescription = "Painting services", GenreId = 4},
                new Service { serviceId = 5, serviceName = "Core Cutter", serviceDescription = "Concrete cutting", GenreId = 5 }
            );
            modelBuilder.Entity<ServiceGenre>().HasData(
                new ServiceGenre { Id = 1, genreName = "Plumbing" },
                new ServiceGenre { Id = 2, genreName = "Electrical" },
                 new ServiceGenre { Id = 3, genreName = "Carpenter" },
                 new ServiceGenre { Id = 4, genreName = "Painter" },
                new ServiceGenre {Id = 5, genreName = "Core Cutter" }

        );
        }
    }
}
