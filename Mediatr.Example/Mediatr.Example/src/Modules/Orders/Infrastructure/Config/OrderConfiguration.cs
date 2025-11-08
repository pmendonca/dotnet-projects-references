using Mediatr.Example.src.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mediatr.Example.src.Modules.Orders.Infrastructure.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> b)
        {
            b.ToTable("orders");
            b.HasKey(x => x.Id);
            b.Property(x => x.CustomerName).HasMaxLength(200).IsRequired();
            b.Property(x => x.Total).HasPrecision(18, 2);
            b.Ignore(x => x.DomainEvents);
        }
    }
}
