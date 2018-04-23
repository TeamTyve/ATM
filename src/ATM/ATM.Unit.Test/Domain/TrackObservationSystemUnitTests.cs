using System.Collections.Generic;
using ATM.Classes.Domain;
using ATM.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Unit.Test.Domain
{
    [TestFixture]
    public class TrackObservationSystemUnitTests
    {
        private ITrackObservationSystem _uut;
        private ITransponderReceiver _transponderReceiver;

        [SetUp]
        public void Setup()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new TrackObservationSystem(_transponderReceiver);
            _uut.Output = Substitute.For<IOutput>();
        }

        [Test]
        public void ReceiverOnTransponderDataReady_FireEvent_PrintObject()
        {
            var args = new TransponderDataEventArgs();
            _transponderReceiver.TransponderDataReady += Raise.EventWith(new object(), new RawTransponderDataEventArgs(new List<string>
           {
               "Tag;0;0;0;00010101010101001"
           }));

            var track = new Track("Tag;0;0;0;00010101010101001");

            Assert.That(_uut.TrackRepository.FlightTracks[0].Tag, Is.EqualTo(track.Tag));
            Assert.That(_uut.TrackRepository.FlightTracks[0].Vector.Z, Is.EqualTo(track.Vector.Z));
            Assert.That(_uut.TrackRepository.FlightTracks[0].Vector.X, Is.EqualTo(track.Vector.X));
            Assert.That(_uut.TrackRepository.FlightTracks[0].Vector.Y, Is.EqualTo(track.Vector.Y));
            Assert.That(_uut.TrackRepository.FlightTracks[0].Timestamp, Is.EqualTo(track.Timestamp));
        }

        [Test]
        public void ReceiverOnTransponderDataReady_FireEvent_ReceivedStrings()
        {
            _uut.TrackRepository = Substitute.For<ITrackRepository>();

            var args = new TransponderDataEventArgs();
            _transponderReceiver.TransponderDataReady += Raise.EventWith(new object(), new RawTransponderDataEventArgs(new List<string>
            {
                "Tag;0;0;0;00010101010101001"
            }));
            
            _uut.TrackRepository.Received(1).Add("Tag;0;0;0;00010101010101001");
        }

        [Test]
        public void ReceiverOnTransponderDataReady_FireEvent_CallUpdate()
        {
            _uut.TrackRepository = Substitute.For<ITrackRepository>();

            var args = new TransponderDataEventArgs();
            _transponderReceiver.TransponderDataReady += Raise.EventWith(new object(), new RawTransponderDataEventArgs(new List<string>
            {
                "Tag;0;0;0;00010101010101001"
            }));

            _uut.TrackRepository.Received(3).GetAll();
        }
    }
}