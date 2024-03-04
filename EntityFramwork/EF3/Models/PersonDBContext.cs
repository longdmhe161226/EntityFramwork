using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3.Models
{
    internal class PersonDBContext : DbContext
    {

        public DbSet<Person> Persons { get; set;}
        public DbSet<Mark> Marks{ get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =(local);database=ef3;uid=sa;pwd=123;Encrypt=False;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mark>(entity => {
                entity.HasIndex(p => new { p.PersonID})
                      .IsUnique();
            });
        }
    }
}
