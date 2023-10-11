// See https://aka.ms/new-console-template for more information
using CS03Mongo.Helpers;
using CS03Mongo.Models;

Console.WriteLine("Hello, World!");

MongoCRUD db = new MongoCRUD("playground");
Address mas1 = new Address { Street = "Masarykova", Municipality = "Liberec", ZipCode=46003};
Address tyr1 = new Address { Street = "Tyršova", Municipality = "Liberec", ZipCode = 46003 };
//db.Create("contacts",mas1);
Person per1 = new Person { FirstName = "Adam", HomeAddress = mas1 };
//db.Create("people",per1);

foreach (var x in db.List<Address>("contacts"))
{
    if (x is Address)
    {
        Console.WriteLine(x!.Street + " " + x.Id);
    }
    else
    {
        Console.WriteLine("---");
    }
    ;
}
foreach (var x in db.List<Person>("people"))
{
    if (x is Person)
    {
        Console.WriteLine(x.Id + " " + x!.FirstName + " " + x.HomeAddress.Street);
    }
    else
    {
        Console.WriteLine("---");
    }
    ;
}
/*
Address? tyr = db.Read<Address>("contacts", "65264c5dbd256deeeaf25078");
if (tyr != null)
{
    Console.WriteLine(tyr.Id + " " + tyr.Street + " " + tyr.Municipality);
}
else
{
    Console.WriteLine("nic nezískáno");
}

Person? pp = db.Read<Person>("contacts", "65264c5dbd256deeeaf25078");
if (tyr != null)
{
    Console.WriteLine(tyr.Id + " " + tyr.Street + " " + tyr.Municipality);
}
else
{
    Console.WriteLine("nic nezískáno");
}

db.Upsert("contacts", "65264c5dbd256deeeaf25078", new { Municipality = "Praha"});
foreach (var x in db.List<Address>("contacts"))
{
    Console.WriteLine(x.Id + " " + x.Street + " " + x.Municipality);
}
*/