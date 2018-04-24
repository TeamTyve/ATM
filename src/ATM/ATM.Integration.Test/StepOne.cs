using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Boundary;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Integration.Test
{
    [TestFixture]
    public class StepOne
    {
        private ILogHelper logHelper;
        private Classes.Interfaces.ILogger consoleLogger;
        private Classes.Interfaces.ILogger eventLogger;

        [SetUp]
        public void Init()
        {
            logHelper = new LogHelper();
            consoleLogger = Substitute.For<Classes.Interfaces.ILogger>();
            eventLogger = new EventLogger("\\");
        }

        // Isn't a real integration test, but provides value in the fact that
        // ConsoleLogger actually receives values.
        [Test]
        public void LogHelper_CanWriteToLogger_ConsoleIsCalled()
        {
            logHelper.Logger = consoleLogger;
            logHelper.Log(LoggerTarget.Console, "Hello World");

            consoleLogger.Received(1).WriteLine("Hello World");
        }

        [Test]
        public void LogHelper_CanClearLog_ConsoleIsCalled()
        {
            logHelper.Logger = consoleLogger;
            logHelper.Log(LoggerTarget.Console, String.Empty, true);

            consoleLogger.Received(1).Clear();
        }

        [Test]
        public void LogHelper_CanWriteToLogger_EventIsCalled()
        {
            logHelper.Log(LoggerTarget.Event, String.Empty, true);

            var expected = "Hello World";

            logHelper.Log(LoggerTarget.Event, expected);

            var msg = new char[11];
            using (var streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Events.txt"))
                streamReader.Read(msg, 0, 11);

            Assert.That(msg, Is.EqualTo(expected));
            logHelper.Log(LoggerTarget.Event, String.Empty, true);
        }

        [Test]
        public void LogHelper_CanClearLog_EventIsCalled()
        {
            logHelper.Log(LoggerTarget.Event, String.Empty, true);

            var expected = "Hello World";

            logHelper.Log(LoggerTarget.Event, expected);
            logHelper.Log(LoggerTarget.Event, String.Empty, true);

            var msg = new char[11];
            using (var streamReader = new StreamReader($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Events.txt"))
                streamReader.Read(msg, 0, 11);

            Assert.That(msg[0], Is.EqualTo('\u0000'));
            Assert.That(msg[10], Is.EqualTo('\u0000'));
        }
    }
}
