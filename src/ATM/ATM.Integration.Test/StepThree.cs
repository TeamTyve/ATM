using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes;
using ATM.Classes.Boundary;
using ATM.Classes.Domain;
using ATM.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace ATM.Integration.Test
{
    [TestFixture()]
    public class StepThree
    {
        // Driver
        private TrackObservationSystem trackObservationSystem;

        // Stub
        private Classes.Interfaces.ILogger consoleLogger;
        private ITransponderReceiver transponderReceiver;

        // Included
        private IOutput output;
        private ITrackRepository trackRepository;
        private ISeperation seperation;
        private ILogHelper logHelper;
        private Classes.Interfaces.ILogger eventLogger;
        private ITrack track;
        private SeperationEventArgs seperationEventArgs;
        private IAirSpace airspace;


        [SetUp]
        public void Init()
        {
            consoleLogger = Substitute.For<Classes.Interfaces.ILogger>();
            output = new Output();
            trackRepository = new TrackRepository();
            seperation = new Seperation();
            logHelper = new LogHelper();
            logHelper.Logger = consoleLogger;
            eventLogger = new EventLogger();
            output.LogHelper = logHelper;
            airspace = new AirSpace();
            transponderReceiver = Substitute.For<ITransponderReceiver>();

            trackObservationSystem = new TrackObservationSystem(transponderReceiver);
            trackObservationSystem.TrackRepository = trackRepository;
            trackObservationSystem.Output = output;
            trackObservationSystem.AirSpace = AirSpace;


        }
    }
}
