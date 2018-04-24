using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Domain;
using ATM.Classes.Interfaces;
using TransponderReceiver;

namespace ATM.Classes
{
    public class TrackingSystem
    {
        public ITrackObservationSystem TrackObservationSystem { get; set; }

        public TrackingSystem()
        {
            var transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            //TrackObservationSystem = new TrackObservationSystem();
        }

    }
}
