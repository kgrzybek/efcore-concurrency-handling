using DDD.EF.OptimisticConcurrency.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DDD.EF.OptimisticConcurrency
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersContext).Assembly);
        }
    }
}