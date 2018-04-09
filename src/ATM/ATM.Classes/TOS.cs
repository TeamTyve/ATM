using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;
using TransponderReceiver;

namespace ATM.Classes
{
    public class TOS
    {
        public ITransponderReceiver Receiver { get; private set; }
        public ITracks Tracks { get; private set; } = new Tracks();
        public IOutput Output { get; set; } = new Output();

        public TOS(ITransponderReceiver receiver)
        {
            Receiver = receiver;
            receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            foreach (var v in rawTransponderDataEventArgs.TransponderData)
            {
                Tracks.Add(v);
            }

            Output.Print(Tracks.FlightTracks);
        }
    }
}
