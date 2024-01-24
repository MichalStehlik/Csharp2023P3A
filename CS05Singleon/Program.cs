using CS05Singleon;
using System.Runtime.Intrinsics.X86;

//var se = SingletonExample.Instance;
//Console.WriteLine(se.Value.ToString());
/*
Task t = new Task(() =>
{
    var se3 = SingletonExample.Instance;

    Console.WriteLine(se3.Value.ToString());
});
Task t2 = new Task(() =>
{
    var se4 = SingletonExample.Instance;
    Console.WriteLine(se4.Value.ToString());
});
t.Start();
t2.Start();
//Console.WriteLine(se.Value.ToString());

/*
var tsse = ThreadSafeSingletonExample.Instance;
Console.WriteLine(tsse.Value.ToString());
var tsse2 = ThreadSafeSingletonExample.Instance;
Console.WriteLine(tsse2.Value.ToString());
Task t = new Task(() =>
{
    var tsse3 = ThreadSafeSingletonExample.Instance;
    Console.WriteLine(tsse3.Value.ToString());
});
t.Start();
*/

Task<int> t = T();
Task<int> t2 = T();
Task.WaitAll(t,t2);

async Task<int> T()
{
    //await Task.Delay(1000);
    var se2 = SingletonExample.Instance;   
    //Console.WriteLine(se2.Value.ToString());
    //return se2.Value;
    int x = Random.Shared.Next(100);
    Console.WriteLine(x + " " + se2.Value);
    return x;
}