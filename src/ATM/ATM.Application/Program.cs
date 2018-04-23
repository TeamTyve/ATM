using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes;
using ATM.Classes.Boundary;
using ATM.Classes.Domain;
using TransponderReceiver;
using Console = System.Console;

namespace ATM.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var trackingSystem = new TrackingSystem();

            Console.ReadKey(); 
        }
    }
}
