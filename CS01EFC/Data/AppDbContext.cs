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
        public DbSet<Artist> Artists { get; set; }

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
            Movie dune = new Movie { MovieId = 1, Name = "Dune", Duration = 3.0f, GenreId = 1 };
            modelBuilder.Entity<Movie>(options =>
            {
                options.HasData(dune);
                options.HasData(new Movie { MovieId = 2, Name = "Oppenheimer", Duration = 2.5f, GenreId = 3 });
            });
            Artist keanu = new Artist { ArtistId = 1, FirstName = "Keanu", LastName = "Reeves", Gender = Gender.Male, WebAddress = "https://www.imdb.com/name/nm0000206/" };
            Artist zendaya = new Artist { ArtistId = 3, LastName = "Zendaya", Gender = Gender.Female };
            modelBuilder.Entity<Artist>(options =>
            {
                options.HasData(keanu);
                options.HasData(new Artist { ArtistId = 2, FirstName = "Timothée", LastName = "Chalamet", Gender = Gender.Male });
                options.HasData(zendaya);
                options.HasMany(m => m.Movies).WithMany(a => a.Artists).UsingEntity<ArtistMovie>(
                        am => am.HasOne(am => am.Movie).WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.Restrict),
                        am => am.HasOne(am => am.Artist).WithMany().HasForeignKey("ArtistId").OnDelete(DeleteBehavior.Restrict)
                    ).ToTable("ArtistMovies")
                    .HasKey(am => new { am.MovieId, am.ArtistId });
            });
        }
    }
}
