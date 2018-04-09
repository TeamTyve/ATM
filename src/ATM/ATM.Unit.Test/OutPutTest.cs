using System;
using System.Collections.ObjectModel;
using System.IO;
using ATM.Classes;
using ATM.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class OutPutTest
    {
        [Test]
        public void Output_Format_Text()
        {
            var dateTime = System.DateTime.Now;
            var uut = new Output
            {
                ConsoleOut = Substitute.For<IConsoleOut>()
            };

            uut.Print(new ObservableCollection<ITrack>
            {
                new Track("Tag;0;0;0;00010101010101001")
            });

            uut.ConsoleOut.Received(1).WriteLine("Tag:Tag | Altitude:0 | x:0, y:0 | Timestamp:01/01/0001 01.01.01.1");
        }
    }
}