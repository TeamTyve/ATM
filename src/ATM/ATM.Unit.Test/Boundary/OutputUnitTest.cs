using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Classes;
using ATM.Classes.Boundary;
using ATM.Classes.Domain;
using ATM.Utility;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test.Boundary
{
    [TestFixture]
    public class OutputUnitTest
    {
        [Test]
        public void Output_PrintCanFormatString_ConsoleReturnsString()
        {
            var uut = new Output();
            var logHelper = Substitute.For<ILogHelper>();
            uut.LogHelper = logHelper;

            var tracks = new List<Track>();

            //var track = new Track("Tag;10001;10001;10001;00010101010101001") {IsInAirspace = true};
            //tracks.Add(track);

            uut.Print(tracks.AsEnumerable());

            logHelper.Received(1).Log(LoggerTarget.Console, "Tag:Tag | Altitude:10001 | x:10001, y:10001 | Timestamp:01/01/0001 01.01.01.1 | Airspeed:  | Is in airspace: True| Direction: 0");
        }

        [Test]
        public void Output_PrintCanFormatString_ConsoleReturnsEmptyString()
        {
            var uut = new Output();
            var logHelper = Substitute.For<ILogHelper>();
            uut.LogHelper = logHelper;

            var tracks = new List<Track>();

            //var track = new Track("Tag;10001;10001;10001;00010101010101001") { IsInAirspace = false };
            //tracks.Add(track);

            uut.Print(tracks.AsEnumerable());

            logHelper.Received(0).Log(LoggerTarget.Console, "Tag:Tag | Altitude:10001 | x:10001, y:10001 | Timestamp:01/01/0001 01.01.01.1 | Airspeed:  | Is in airspace: True| Direction: 0");
        }

        [Test]
        public void Output_SeperationAlertCanOutputEvent_ConsoleReturnsString()
        {
            var uut = new Output();
            var logHelper = Substitute.For<ILogHelper>();
            uut.LogHelper = logHelper;

            var seperationAlert = new SeperationAlert("Plane1", "Plane2", DateTime.Now);
            uut.SeperationAlert(seperationAlert);

            logHelper.Received(1).Log(LoggerTarget.Console, $"Flight: Plane1 collision warning with flight: Plane2. TIME:{seperationAlert.Time}");

        }
    }
}