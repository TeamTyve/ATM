using System;
using System.IO;
using ATM.Classes.Boundary;
using NUnit.Framework;

namespace ATM.Unit.Test.Boundary
{
    [TestFixture]
    public class EventLoggerUnitTest
    {
        [Test]
        public void EventLogger_WriteToLog_ReturnsCorrectFile()
        {
            var uut = new EventLogger();
            uut.Clear();
            var expected = "Hello World";

            uut.WriteLine(expected);
            var msg = new char[11];
            using (var streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Events.txt"))
                streamReader.Read(msg, 0, 11);

            Assert.That(msg, Is.EqualTo(expected));
            uut.Clear();
        }

        [Test]
        public void EventLogger_ClearLog_ReturnsEmptyFile()
        {
            var uut = new EventLogger();
            uut.Clear();
            var expected = "Hello World";
            uut.WriteLine(expected);

            uut.Clear();
            var msg = new char[11];
            using (var streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Events.txt"))
                streamReader.Read(msg, 0, 11);

            Assert.That(msg[0], Is.EqualTo('\u0000'));
            Assert.That(msg[10], Is.EqualTo('\u0000'));
            uut.Clear();
        }
    }
}