// See https://aka.ms/new-console-template for more information
using CS02SQLite.Data;
using Microsoft.EntityFrameworkCore;

var db = new ApplicationDbContext(@"Data Source=myGamesDatabase.sqlite");
foreach (var c in db.Companies.ToList())
{
    Console.WriteLine(c.Name);
}
foreach (var g in db.Games.Include(g => g.Developments).ThenInclude(d => d.Company).ToList())
{
    Console.WriteLine(g.Name);
    foreach(var c in g.Developments)
    {
        Console.WriteLine("  " + c.Company.Name);
    }
}
