using CS01EFC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS01EFC.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=csMovies;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            builder.LogTo(Console.WriteLine, new[]
            {
                RelationalEventId.CommandExecuted,
                //RelationalEventId.CommandExecuting,
            } );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>(options =>
            {
                options.HasData(new Genre { GenreId = 1, Name = "Sci-fi" });
                options.HasData(new Genre { GenreId = 2, Name = "Horror" });
                options.HasData(new Genre { GenreId = 3, Name = "Životopis" });
            });
            modelBuilder.Entity<Movie>(options =>
            {
                options.HasData(new Movie { MovieId = 1, Name = "Dune", Duration = 3.0f, GenreId = 1});
                options.HasData(new Movie { MovieId = 2, Name = "Oppenheimer", Duration = 2.5f, GenreId = 3 });
            });
            
        }
    }
}
