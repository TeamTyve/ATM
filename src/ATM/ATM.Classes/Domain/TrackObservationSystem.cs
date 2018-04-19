using System.Collections.Generic;
using System.Linq;
using ATM.Classes.Interfaces;
using TransponderReceiver;

namespace ATM.Classes.Domain
{
    public class TrackObservationSystem : ITrackObservationSystem
    {
        public ITransponderReceiver Receiver { get; private set; }
        public ITrackRepository TrackRepository { get; private set; } = new TrackRepository();
        public IOutput Output { get; set; } = new Output();
        public IAirSpace AirSpace { get; private set; } = new AirSpace();
        public ISeperation Seperation { get; private set; } = new Seperation();
        public ISeperationAlertRepository SeperationAlertRepository { get; set; } = new SeperationAlertRepository();

        public bool ConsoleOut { get; set; } = true;

        public TrackObservationSystem(ITransponderReceiver receiver)
        {
            Receiver = receiver;
            receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
            Seperation.SeperationEvent += OnSeperation;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            Update();

            foreach (var v in rawTransponderDataEventArgs.TransponderData)
            {
                TrackRepository.Add(v);
            }

            foreach (var t in TrackRepository.GetAll())
            {
                t.IsInAirspace = AirSpace.CheckAirSpace(t.Vector);
                Seperation.CheckSeperation(TrackRepository.FlightTracks.ToList(), t);
            }

            if (ConsoleOut)
            {
                Display();
            }
        }

        private void OnSeperation(object sender, SeperationEventArgs e)
        {
            if (!e.Still) return;
            if (!ConsoleOut) return;

            var seperationAlert = new SeperationAlert(e.Tag1, e.Tag2, e.Time);

            SeperationAlertRepository.Add(seperationAlert);
        }

        private void Display()
        {
            Output.Print(TrackRepository.GetAll());
            foreach (var seperationAlert in SeperationAlertRepository.GetAll())
            {
                Output.SeperationAlert(seperationAlert);
            }
        }

        private void Update()
        {
            var tracks = TrackRepository.GetAll();
            var seperationAlerts = SeperationAlertRepository.GetAll();

            
        }
    }
}
