using System;
using System.Diagnostics;
using ATM.Classes.Interfaces;

namespace ATM.Classes.Boundary
{
    public class ConsoleLogger : ILogger
    {
        public object LockObj { get; set; }

        public void Clear()
        {
            Console.Clear();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}