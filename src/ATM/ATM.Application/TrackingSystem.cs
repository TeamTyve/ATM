using ATM.Classes.Domain;
using ATM.Classes.Interfaces;
using TransponderReceiver;

namespace ATM.Application
{
    public class TrackingSystem
    {
        public ITrackObservationSystem TrackObservationSystem { get; set; }

        public TrackingSystem()
        {
            var transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            TrackObservationSystem = new TrackObservationSystem(transponderReceiver);
        }

    }
}
