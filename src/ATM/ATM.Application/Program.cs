using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes;
using TransponderReceiver;

namespace ATM.Application
{
    class Program
    {
        public static Tracks Flights { get; set; } 
        static void Main(string[] args)
        {
            ITransponderReceiver reciever;
            reciever = TransponderReceiverFactory.CreateTransponderDataReceiver();
            reciever.TransponderDataReady += RecieverOnTransponderDataReady;
            Flights = new Tracks();
            while (true)
            {
               

            }
            
        }

        private static void RecieverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            foreach (var v in rawTransponderDataEventArgs.TransponderData)
            {
                Flights.FlightTracks.Add(new Track(v));
            }
        }

        
    }
}
