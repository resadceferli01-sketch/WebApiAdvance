using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiAdvance.Entities;

namespace WebApiAdvance.DAL.Configuration
{
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder. Property(oi =>oi.Description).IsRequired().HasMaxLength(200);

            builder.Property(oi => oi.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
