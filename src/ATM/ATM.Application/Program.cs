using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes;
using TransponderReceiver;
using Console = System.Console;

namespace ATM.Application
{
    class Program
    {
        public static Tracks Flights { get; set; } 
        static void Main(string[] args)
        {
            var tos = new TOS(TransponderReceiverFactory.CreateTransponderDataReceiver());
            while (true){}
        }


    }
}
