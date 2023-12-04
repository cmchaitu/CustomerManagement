using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Models
{
    public class CustomerDBContext : DbContext

    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlServer("Server=localhost;Database=CustomersDB;User Id=sa;Password=fms@123;"); 
        }
    }
}
