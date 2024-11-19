using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawSqlQueriesDemo
{
    public class RawSqlQueriesDemoContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnectionFactory.Create("RawSqlQueriesDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
