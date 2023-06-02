using Microsoft.EntityFrameworkCore;
using StatusGridAPI.Models;

namespace StatusGridAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=StatusGrid.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GridConfiguration>()
                .HasMany(p => p.Statuses);
        }

        public DbSet<GridConfiguration> GridConfigurations { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}