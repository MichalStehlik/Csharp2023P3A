// See https://aka.ms/new-console-template for more information
using CS01EFC.Data;
using CS01EFC.Models;

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
