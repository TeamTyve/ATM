using System;
using ATM.Classes.Interfaces;

namespace ATM.Classes
{
    public class ConsoleOut : IConsoleOut
    {
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