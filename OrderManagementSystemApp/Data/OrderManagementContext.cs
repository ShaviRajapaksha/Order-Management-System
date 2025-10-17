using Microsoft.EntityFrameworkCore;
using OrderManagementSystemApp.Models;

namespace OrderManagementSystemApp.Data
{
    public class OrderManagementContext : DbContext
    {
        public OrderManagementContext(DbContextOptions<OrderManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}