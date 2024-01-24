using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS05Singleon
{
    // v CSharpu se chová jako ThreadSafe
    internal sealed class SingletonExample
    {
        public int Value { get; }
        private static SingletonExample _instance = new SingletonExample();

        private SingletonExample() 
        {
            Value = Random.Shared.Next(100);
        }

        public static SingletonExample Instance
        {
            get { return _instance; }
        }
    }
}
