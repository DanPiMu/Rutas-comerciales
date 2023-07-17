using Microsoft.EntityFrameworkCore;
using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<SpyReport> SpyReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.PlanetName).IsRequired();
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Sector).IsRequired();
            });

            modelBuilder.Entity<Distance>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.OriginPlanetCode).IsRequired();
                entity.Property(e => e.DestinationPlanetCode).IsRequired();
                entity.Property(e => e.LunarYears).IsRequired();
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Sector).IsRequired();
                entity.Property(e => e.PricesPerLunarDay).IsRequired();
            });

            modelBuilder.Entity<SpyReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.PlanetCode).IsRequired();
                entity.Property(e => e.RebelInfluence).IsRequired();
            });
        }
    }

}
