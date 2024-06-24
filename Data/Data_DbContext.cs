using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class Data_DbContext:DbContext
    {
        public Data_DbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Couriers> Couriers { get; set; }
    }
}
