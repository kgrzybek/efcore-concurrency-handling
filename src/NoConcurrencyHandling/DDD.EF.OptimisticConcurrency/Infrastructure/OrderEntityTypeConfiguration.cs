using System;
using DDD.EF.OptimisticConcurrency.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.EF.OptimisticConcurrency.Infrastructure
{
    internal sealed class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "orders");

            builder.HasKey(b => b.Id);
            builder.Property("_modifyDate").HasColumnName("ModifyDate");

            builder.OwnsMany<OrderLine>("_orderLines", orderLine =>
            {
                orderLine.WithOwner().HasForeignKey("OrderId");

                orderLine.ToTable("OrderLines", "orders");

                orderLine.Property<Guid>("Id").ValueGeneratedNever();
                orderLine.HasKey("Id");
                orderLine.Property<string>("_productCode").HasColumnName("ProductCode");
            });
        }
    }
}