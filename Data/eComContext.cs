using eCom_EF_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace eCom_EF_Core.Data
{
    public class eComContext : DbContext
    {
        public eComContext (DbContextOptions<eComContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
