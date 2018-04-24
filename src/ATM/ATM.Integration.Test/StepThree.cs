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
            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10001;10001;10001;00010101010101001"
            }));

            output.LogHelper.Logger = consoleLogger;

            consoleLogger.Received(1)
                .WriteLine(
                    "Tag:Tag | Altitude:10001 | x:10001, y:10001 | Timestamp:01/01/0001 01.01.01.1 | Airspeed:  | Is in airspace: True| Direction: ");
            consoleLogger.Received(1)
                .WriteLine(
                    "Tag:Tag1 | Altitude:10001 | x:10001, y:10001 | Timestamp:01/01/0001 01.01.01.1 | Airspeed:  | Is in airspace: True| Direction: ");

            Assert.That(trackRepository.FlightTracks.Count, Is.EqualTo(2));
        }

        [Test]
        public void Output_SeperationAlert()
        {
            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10001;10001;10001;00010101010101001"
            }));

            output.LogHelper.Logger = consoleLogger;
            var datetime = DateTime.Now;

            trackObservationSystem.OnSeperation(new object(), new SeperationEventArgs("Tag", datetime, "Tag1"));

            consoleLogger.Received(1).WriteLine($"Flight: Tag1 collision warning with flight: Tag. TIME:{datetime}");

            Assert.That(seperationAlertRepository.GetAll().Count(), Is.EqualTo(2));
        }


        // TrackRepository

        [Test]
        public void TrackRepository_AddItems_ReturnsCorrectCount()
        {
            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10001;10001;10001;00010101010101001"
            }));

            Assert.That(trackRepository.FlightTracks.Count, Is.EqualTo(2));
        }


        // Airspace

        [Test]
        public void Airspace_AddItems_IsInAirspace()
        {
            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10001;10001;10001;00010101010101001"
            }));

            Assert.True(trackRepository.FlightTracks[0].IsInAirspace);
            Assert.True(trackRepository.FlightTracks[1].IsInAirspace);
        }

        [Test]
        public void Airspace_AddItems_NotInAirspace()
        {
            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;9000;10001;10001;00010101010101001",
                "Tag1;9000;10001;10001;00010101010101001"
            }));

            Assert.False(trackRepository.FlightTracks[0].IsInAirspace);
            Assert.False(trackRepository.FlightTracks[1].IsInAirspace);
        }


        // SeperationAlert

        [Test]
        public void SeperationAlert_AddSeperationEventArgs()
        {
            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10001;10001;10001;00010101010101001"
            }));

            output.LogHelper.Logger = consoleLogger;
            var datetime = DateTime.Now;

            trackObservationSystem.OnSeperation(new object(), new SeperationEventArgs("Tag", datetime, "Tag1"));

            Assert.That(seperationAlertRepository.GetAll().Count(), Is.EqualTo(2));
        }


        // SeperationAlertRepository

        [Test]
        public void SeperationAlertRepository_OnSeperation_InCollision()
        {
            //trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            //{
            //    "Tag;10001;10001;10001;00010101010101001",
            //    "Tag1;10001;10001;10001;00010101010101001"
            //}));

            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10000;10001;10001;00010101010101001"
            }));

            output.LogHelper.Logger = consoleLogger;
            var datetime = DateTime.Now;

            Assert.That(seperationAlertRepository.GetAll().Count(), Is.EqualTo(1));
        }

        [Test]
        public void SeperationAlertRepository_OnSeperation_NotInCollision()
        {
            //trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            //{
            //    "Tag;10001;10001;10001;00010101010101001",
            //    "Tag1;10001;10001;10001;00010101010101001"
            //}));

            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;30000;30001;11001;00010101010101001"
            }));

            output.LogHelper.Logger = consoleLogger;
            var datetime = DateTime.Now;

            Assert.That(seperationAlertRepository.GetAll().Count(), Is.EqualTo(0));
        }

        [Test]
        public void SeperationAlertRepository_OnSeperation_InCollisionUpdate()
        {
            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;20001;10001;10001;00010101010101001"
            }));

            Assert.That(seperationAlertRepository.GetAll().Count(), Is.EqualTo(0));

            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10001;10001;10001;00010101010101001"
            }));
            output.LogHelper.Logger = consoleLogger;
            var datetime = DateTime.Now;

            Assert.That(seperationAlertRepository.GetAll().Count(), Is.EqualTo(1));
        }


        // Seperation

        [Test]
        public void Seperation()
        {
            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;10001;10001;10001;00010101010101001"
            }));

            trackObservationSystem.ReceiverOnTransponderDataReady(new object(), new RawTransponderDataEventArgs(new List<string>()
            {
                "Tag;10001;10001;10001;00010101010101001",
                "Tag1;20001;10001;10001;00010101010101001"
            }));

            trackObservationSystem.ReceiverOnTransponderDataReady(new object(),
                new RawTransponderDataEventArgs(new List<string>()));

            output.LogHelper.Logger = consoleLogger;
            var datetime = DateTime.Now;

            Assert.That(seperationAlertRepository.GetAll().Count(), Is.EqualTo(1));
        }
    }
}
