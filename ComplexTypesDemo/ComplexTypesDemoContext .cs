using Common;
using Microsoft.EntityFrameworkCore;

namespace ComplexTypesDemo
{
    public class ComplexTypesDemoContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnectionFactory.Create("ComplexTypesDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ComplexProperty(p => p.Price);
        }
    }
}
