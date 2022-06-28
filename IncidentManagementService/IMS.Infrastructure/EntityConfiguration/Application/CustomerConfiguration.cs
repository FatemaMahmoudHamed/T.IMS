using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IMS.Core.Entities;

namespace IMS.Infrastructure.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "IMS");

            builder.Property(m => m.Id);
              //.ValueGeneratedNever();

        }
    }
}
