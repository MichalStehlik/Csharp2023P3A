using CS02SQLite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS02SQLite.Data
{
    internal class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString = String.Empty;

        public DbSet<Company> Companies { get; set; }
        public DbSet<Game> Games { get; set; }
        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.LogTo(Console.WriteLine, new[]
            {
                RelationalEventId.CommandExecuted,
            });
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().HasData(new Company { CompanyId = 1, Name = "CD Projekt"});
            modelBuilder.Entity<Game>().HasData(new Game { GameId = 1, Name = "Cyberpunk 2077" });
            modelBuilder.Entity<Development>(options =>
            {
                options.HasKey(e => new { e.CompanyId, e.GameId });
                options.HasData(new Development { CompanyId = 1, GameId = 1 });
            }
            );
        }
    }
}
