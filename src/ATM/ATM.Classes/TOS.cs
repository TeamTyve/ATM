using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Interfaces;
using TransponderReceiver;

namespace ATM.Classes
{
    public class TOS : ITOS
    {
        public ITransponderReceiver Receiver { get; private set; }
        public ITracks Tracks { get; private set; } = new Tracks();
        public IOutput Output { get; set; } = new Output();
        public IAirSpace AirSpace { get; private set; } = new AirSpace();
        public ISeperation Seperation { get; private set; } = new Seperation();

        public TOS(ITransponderReceiver receiver)
        {
            Receiver = receiver;
            receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
            Seperation.SeperationEvent += OnSeperation; 
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            foreach (var v in rawTransponderDataEventArgs.TransponderData)
            {
                Tracks.Add(v);
            }

            foreach (var t in Tracks.FlightTracks)
            {
                t.IsInAirspace=AirSpace.CheckAirSpace(t.Vector);
                Seperation.CheckSeperation(Tracks.FlightTracks.ToList(),t);
            }

            Output.Print(Tracks.FlightTracks);
        }

        private void OnSeperation(object sender, SeperationEventArgs e)
        {
            if (e.Still)
            {
            Output.SeperationAlert(e.Tag1,e.Tag2,e.Time, Tracks.FlightTracks);
            }
        }
    }
}
