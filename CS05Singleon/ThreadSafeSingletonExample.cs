using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS05Singleon
{
    internal class ThreadSafeSingletonExample
    {
        public int Value { get; }
        private static object padlock = new object();
        private static ThreadSafeSingletonExample? _instance = null;

        private ThreadSafeSingletonExample()
        {
            Value = Random.Shared.Next(100);
        }
        public static ThreadSafeSingletonExample Instance
        {
            get 
            { 
                lock (padlock)
                {
                    if (_instance == null) 
                    {
                        _instance = new ThreadSafeSingletonExample();
                    }
                    return _instance;
                }
            }
        }
    }
}
