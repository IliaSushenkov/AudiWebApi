using Audi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Audi.DAL.Context
{
    public class AudiContext : DbContext
    {
        public AudiContext()
        { }
    
        public DbSet<AudiModel> Audi { get; set; } = null;
        public AudiContext(DbContextOptions<AudiContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudiModel>().HasKey(x => x.Id);
            modelBuilder.Entity<AudiModel>().Property(x => x.Brand).HasMaxLength(10);
            modelBuilder.Entity<AudiModel>().Property(x => x.Model).HasMaxLength(10);
            modelBuilder.Entity<AudiModel>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<AudiModel>().Property(x => x.Description).HasMaxLength(50);

            modelBuilder.Entity<AudiModel>().HasData(
                new AudiModel() { Id = 1, Brand = "Audi", Model = "A8l", Description = "The most luxary model", Price = 1090321 },
                new AudiModel() { Id = 2, Brand = "Audi", Model = "RS Q8", Description = " The most faster jeep", Price = 1090321 },
                new AudiModel() { Id = 3, Brand = "Audi", Model = "RS7", Description = "Sooo beautiful))", Price = 1090321 }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-8MFRG8U;Initial Catalog=MSSQLDb;Database=Audidb;Integrated Security=True;");
            }
        }

    }
}
