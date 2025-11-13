using Microsoft.EntityFrameworkCore;
using StadiumAnalytics.StadiumAnalytics.Domain.Entities;

namespace StadiumAnalytics.StadiumAnalytics.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<GateEvent> GateEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GateEvent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GateName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Timestamp).IsRequired();
                entity.Property(e => e.NumberOfPeople).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();

                //indexes
                entity.HasIndex(e => new { e.GateName, e.Type });
                entity.HasIndex(e => e.Timestamp);
                entity.HasIndex(e => new { e.GateName, e.Type, e.Timestamp });
            });
        }
    }
}
