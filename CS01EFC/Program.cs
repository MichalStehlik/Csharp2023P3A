// See https://aka.ms/new-console-template for more information
using CS01EFC.Data;
using CS01EFC.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

var db = new AppDbContext();

// Add-Migration Initial
// Update-Database

List<Movie> movies1 = db.Movies.ToList();
foreach (Movie movie in movies1)
{
    Console.WriteLine(movie.Name);
}

List<Movie> movies2 = db.Movies.Where(x => x.Name.Contains("une")).ToList();
foreach (Movie movie in movies2)
{
    Console.WriteLine(movie.Name);
}

List<Movie> movies3 = db.Movies.Include(x => x.Genre).ToList();
foreach (Movie movie in movies3)
{
    Console.WriteLine(movie.Name + " " + movie.Genre!.Name);
}

Movie mov = db.Movies.Where(x => x.MovieId == 1).SingleOrDefault();
db.Entry(mov).Reference(x => x.Genre);
// Single, SingleOrDefault, First, FirstOrDefault, ToList
Console.WriteLine(mov.Name);
Console.WriteLine(mov.Genre.Name);

Genre g = db.Genres.Where(x => x.GenreId == 1).SingleOrDefault();
db.Entry(g).Collection(x => x.Movies);
// Single, SingleOrDefault, First, FirstOrDefault, ToList
Console.WriteLine(g.Name);
foreach(var m in g.Movies)
{
    Console.WriteLine(m.Name);
}

/*
string newName = Console.ReadLine();
db.Movies.Add(new Movie { Name = newName, Duration = 1});
try
{
    db.SaveChanges();
    Console.WriteLine("Uloženo.");
}
catch(Exception ex)
{
    Console.WriteLine("Chyba:" + ex.Message);
}
*/