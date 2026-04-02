using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpertZonez.API.Data;
using ExpertZonez.API.Models.Enums;

namespace ExpertZonez.API.Data.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.assignmentId);

            builder.HasOne(a => a.serviceRequest)
                   .WithMany()
                   .HasForeignKey(a => a.requestId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Enum conversion yahan karein
            builder.Property(a => a.status)
    .HasConversion<string>()
    .HasDefaultValue(AssignmentStatus.Pending);
        }
    }
}
