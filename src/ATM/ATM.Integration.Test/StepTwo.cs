using System;
using System.Collections;
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
            eventLogger = new EventLogger();
        }

        [Test]
        public void Output_PrintString_ConsoleLoggerReceivesString()
        {
            IEnumerable<ITrack> tracks = new List<ITrack>
            {
                new Track("Tag;10001;10001;10001;00010101010101001")
            };


            output.Print(tracks);

            consoleLogger.Received(1).WriteLine("Blabla");
        }
    }
}
