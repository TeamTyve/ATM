using System;
using System.Collections.ObjectModel;
using ATM.Classes;
using ATM.Classes.Boundary;
using ATM.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Extensions;
using NUnit.Framework;

namespace ATM.Unit.Test.Boundary
{
    [TestFixture]
    public class LogHelperUnitTest
    {
        [Test]
        public void LogHelper_ConsoleWriteMsg_Returns()
        {
            var uut = new LogHelper
            {
                Logger = Substitute.For<ILogger>()
            };

            uut.Log(LoggerTarget.Console, "Bla");
            uut.Logger.Received(1).WriteLine("Bla");
        }

        [Test]
        public void LogHelper_EventWriteMsg_Returns()
        {
            var uut = new LogHelper
            {
                Logger = Substitute.For<ILogger>()
            };

            uut.Log(LoggerTarget.Event, "Bla");
            uut.Logger.Received(1).WriteLine("Bla");
        }

        [Test]
        public void LogHelper_ConsoleWriteMsg_NoLoggerReturns()
        {
            var uut = new LogHelper
            {
                Logger = null
            };

            uut.Log(LoggerTarget.Console, "Bla");

            Assert.NotNull(uut.Logger);
        }

        [Test]
        public void LogHelper_ConsoleClear_Clears()
        {
            var uut = new LogHelper
            {
                Logger = Substitute.For<ILogger>()
            };

            uut.Log(LoggerTarget.Console, String.Empty, true);

            uut.Logger.Received(1).Clear();
        }

        [Test]
        public void LogHelper_EventWriteMsg_NoLoggerReturns()
        {
            var uut = new LogHelper
            {
                Logger = null
            };

            uut.Log(LoggerTarget.Event, "Bla");

            Assert.NotNull(uut.Logger);
        }

        [Test]
        public void LogHelper_EventClear_Clears()
        {
            var uut = new LogHelper
            {
                Logger = Substitute.For<ILogger>()
            };

            uut.Log(LoggerTarget.Event, String.Empty, true);

            uut.Logger.Received(1).Clear();
        }
    }
}