using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Context
{
    public class CommonDbContext:DbContext
    {
        public CommonDbContext(DbContextOptions<Context.CommonDbContext> options)
            : base(options)
        { }

        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Department>()
               .ToTable("Departments");

        }
    }
}
