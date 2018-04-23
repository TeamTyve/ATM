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
        public void Output_CanFormatString_ConsoleReturnsString()
        {
            var uut = new Output();
            var logHelper = Substitute.For<ILogHelper>();
            uut.LogHelper = logHelper;

            var tracks = new List<Track>();

            var track = new Track("Tag;10001;10001;10001;00010101010101001");
            tracks.Add(track);

            uut.Print(tracks.AsEnumerable());

            logHelper.Received(1).Log(LoggerTarget.Console, "Blabla");
        }
    }
}