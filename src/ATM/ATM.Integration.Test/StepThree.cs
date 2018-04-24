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
        private ISeperationAlertRepository seperationAlertRepository;


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
            seperationAlertRepository = new SeperationAlertRepository();
            transponderReceiver = Substitute.For<ITransponderReceiver>();

            trackObservationSystem = new TrackObservationSystem(transponderReceiver)
            {
                TrackRepository = trackRepository,
                Output = output,
                AirSpace = airspace,
                SeperationAlertRepository = seperationAlertRepository
            };
        }


        // Output

        [Test]
        public void Output_OutputTracks()
        {
            output.LogHelper.Logger = Substitute.For<Classes.Interfaces.ILogger>();

            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10001;10001;10001;00010101010101001"
            }));

            output.LogHelper.Received(1).Log(LoggerTarget.Console, "bla");
        }


        // TrackRepository

        public void TrackRepository()
        {

        }


        // Airspace

        public void Airspace()
        {

        }


        // SeperationAlert

        public void SeperationAlert()
        {

        }


        // SeperationAlertRepository

        public void SeperationAlertRepository()
        {

        }


        // Seperation

        public void Seperation()
        {

        }


        // TrackingSystem

        public void TrackingSystem()
        {

        }
    }
}
