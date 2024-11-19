using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveCollectionsDemo
{
    public class PrimitiveCollectionsDemoContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnectionFactory.Create("PrimitiveCollectionsDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
