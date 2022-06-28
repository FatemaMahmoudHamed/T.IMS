using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IMS.Core.Entities;

namespace IMS.Infrastructure.EntityConfiguration
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidents", "IMS");

            builder.Property(m => m.Id);
               //.ValueGeneratedNever();

            builder.HasOne(m => m.Customer)
                .WithMany()
                .HasForeignKey(m => m.CustomerId);
        }
    }
}
