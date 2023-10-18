using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS04Events
{
    internal class Subscriber
    {
        public void OnValueChanged(object sender, ExampleEventArgs e)
        {
            Console.WriteLine(e.PreviousValue + "->" + e.Value);
        }
    }
}
