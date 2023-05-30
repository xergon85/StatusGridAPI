using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StatusGridAPI.Models;

namespace StatusGridAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<GridConfiguration> GridConfigurations => Set<GridConfiguration>();
        public DbSet<Status> Statuses => Set<Status>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=StatusGrid.db");
    }
}