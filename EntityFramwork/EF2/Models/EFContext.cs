using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2.Models
{
    internal class EFContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> articleTags { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server =(local);database=ef2;uid=sa;pwd=123;Encrypt=False;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleTag>(entity => {
                entity.HasIndex(p => new { p.ArticleId, p.TagId })
                      .IsUnique();
            });
        }
    }
}
