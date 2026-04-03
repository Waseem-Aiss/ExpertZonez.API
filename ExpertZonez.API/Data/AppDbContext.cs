
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
