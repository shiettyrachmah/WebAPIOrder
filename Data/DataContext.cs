using InspiroOrder.Models;
using Microsoft.EntityFrameworkCore;

namespace InspiroOrder.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}
