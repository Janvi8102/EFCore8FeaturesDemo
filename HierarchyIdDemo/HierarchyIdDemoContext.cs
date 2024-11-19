using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyIdDemo
{
    public class HierarchyIdDemoContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnectionFactory.Create("HierarchyIdDB"), builder => builder.UseHierarchyId());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
