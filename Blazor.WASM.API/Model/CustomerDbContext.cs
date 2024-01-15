using Microsoft.EntityFrameworkCore;

namespace Blazor.WASM.API.Model
{
    public class CustomerDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public CustomerDbContext()
        {
        }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
