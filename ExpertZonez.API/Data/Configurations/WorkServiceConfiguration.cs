using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpertZonez.API.Data.Configurations
{
    public class WorkServiceConfiguration : IEntityTypeConfiguration<WorkerService>
    {
        public void Configure(EntityTypeBuilder<WorkerService> builder)
        {
            builder.HasOne(ws => ws.worker)
               .WithMany(w => w.WorkerServices)
               .HasForeignKey(ws => ws.workerId);

            builder.HasOne(ws => ws.service)
               .WithMany(s => s.workerServices)
               .HasForeignKey(ws => ws.serviceId);

            builder.HasKey(ws => new { ws.workerId, ws.serviceId });
        }
    }
}
