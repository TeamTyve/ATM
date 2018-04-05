using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransponderReceiver reciever;
            reciever = TransponderReceiverFactory.CreateTransponderDataReceiver();
            reciever.TransponderDataReady += RecieverOnTransponderDataReady;
            while (true)
            {
               

            }
            
            
        }

        private static void RecieverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            foreach (var v in rawTransponderDataEventArgs.TransponderData)
            {
                Console.WriteLine(v);
            }
        }
    }
}
