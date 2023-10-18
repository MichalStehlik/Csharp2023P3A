// See https://aka.ms/new-console-template for more information
using CS04Events;

Publisher pub = new Publisher(10);
Subscriber sub = new Subscriber();
pub.ValueHasChanged += sub.OnValueChanged;
pub.ValueHasChanged += ReportChange;

for (int i = 0; i < 10; i++)
{
    pub.Value = i;
}
pub.ValueHasChanged -= ReportChange;
for (int i = 10; i > 0; i--)
{
    pub.Value = i;
}
static void ReportChange(object sender, ExampleEventArgs e)
{
    Console.WriteLine(sender.ToString() + " - " + e.Value);
}
