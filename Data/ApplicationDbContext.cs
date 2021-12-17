using ASAP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .Property(p => p.FullName)
                .HasComputedColumnSql("[FirstName]+' '+[LastName]");
            modelBuilder.Entity<Address>()
                .Property(p => p.DisplayAddress)
                .HasComputedColumnSql("[BuildingCode]+' /'+[Street]+' /'+[City]+' /'+[Country]");
        }
        

        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }

    }
}
