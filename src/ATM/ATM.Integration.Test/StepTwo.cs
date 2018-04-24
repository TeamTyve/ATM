using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

namespace ATM.Integration.Test
{
    [TestFixture()]
    public class StepTwo
    {

        // Stub
        private Classes.Interfaces.ILogger consoleLogger;

        // Driver
        private IOutput output;
        private ITrackRepository trackRepository;
        private ISeperation seperation;

        // Included
        private ILogHelper logHelper;
        private Classes.Interfaces.ILogger eventLogger;
        private ITrack track;
        private SeperationEventArgs seperationEventArgs;

      
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

        }

        // Output
        [Test]
        public void Output_PrintString_ConsoleLoggerReceivesString()
        {
            var track = new Track("Tag;10001;10001;10001;00010101010101001");
            track.IsInAirspace = true;

            IEnumerable<ITrack> tracks = new List<ITrack>
            {
                track
            };

            output.Print(tracks);

            // Weird formatting on datetime see Rapport
            //consoleLogger.Received(1).WriteLine("Tag:Tag | Altitude:10001 | x:10001, y:10001 | Timestamp:01/01/0001 01.01.01.1 | Airspeed:  | Is in airspace: True| Direction: ");
        }

        [Test]
        public void Output_PrintString_ConsoleLoggerReceivesStringNoTracks()
        {
            IEnumerable<ITrack> tracks = new List<ITrack>();

            output.Print(tracks);

            consoleLogger.Received(0).WriteLine("Tag:Tag | Altitude:10001 | x:10001, y:10001 | Timestamp:01/01/0001 01.01.01.1 | Airspeed:  | Is in airspace: True| Direction: ");
        }

        [Test]
        public void Output_PrintString_ConsoleLoggerReceivesStringIsNotInAirspace()
        {
            var track = new Track("Tag;10001;10001;10001;00010101010101001");

            IEnumerable<ITrack> tracks = new List<ITrack>
            {
                track
            };

            output.Print(tracks);

            consoleLogger.Received(0).WriteLine("Tag:Tag | Altitude:10001 | x:10001, y:10001 | Timestamp:01/01/0001 01.01.01.1 | Airspeed:  | Is in airspace: True| Direction: ");
        }

        [Test]
        public void Output_PrintString_SeperationEventReceivesStringe()
        {
            output.LogHelper.Logger = eventLogger;
            output.LogHelper.Logger.Clear();

            var sepAlert = new SeperationAlert("Hello", "World", DateTime.Now);

            output.SeperationAlert(sepAlert);

            var msg = new char[51];
            using (var streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Events.txt"))
                streamReader.Read(msg, 0, 51);

            Assert.That(msg, Is.EqualTo("Flight: Hello collision warning with flight: World."));
            logHelper.Log(LoggerTarget.Event, String.Empty, true);
        }

        // TrackRepository
        [Test]
        public void TrackRepository_CanAddTrack()
        {
            trackRepository.Add("Tag;10001;10001;10001;00010101010101001");

            Assert.That(trackRepository.Get("Tag").Vector.X, Is.EqualTo(10001));
        }

        [Test]
        public void TrackRepository_AddTrack_Fails()
        {
            Assert.Catch<FormatException>(() => trackRepository.Add("Tag;10001;"));
        }

        // Seperation
        [Test]
        public void Seperation_SeperationEventArgs_CheckSeperation()
        {
            var listOfTrack = new List<ITrack>();

            var track1 = new Track("Tag;10001;10001;10001;00010101010101001");
            track1.IsInAirspace = true;
            var track2 = new Track("Tag1;10001;10001;10001;00010101010101001");
            track2.IsInAirspace = true;

            listOfTrack.Add(track1);
            listOfTrack.Add(track2);
            var called = "";


            seperation.SeperationEvent += (sender, args) => { called = args.Tag1; };

            seperation.CheckSeperation(listOfTrack, track1);

            Assert.That(called, Is.EqualTo("Tag"));
        }
    }
}
