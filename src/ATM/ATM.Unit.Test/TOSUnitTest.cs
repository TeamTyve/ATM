﻿using System;
using System.Collections.Generic;
using ATM.Classes;
using ATM.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TransponderReceiver;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class TOSUnitTest
    {
        private ITOS _uut;
        private ITransponderReceiver _transponderReceiver;

        [SetUp]
        public void Setup()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new TOS(_transponderReceiver);
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

            Assert.That(_uut.Tracks.FlightTracks[0].Tag, Is.EqualTo(track.Tag));
            Assert.That(_uut.Tracks.FlightTracks[0].Altitude, Is.EqualTo(track.Altitude));
            Assert.That(_uut.Tracks.FlightTracks[0].XCoordinate, Is.EqualTo(track.XCoordinate));
            Assert.That(_uut.Tracks.FlightTracks[0].YCoordinate, Is.EqualTo(track.YCoordinate));
            Assert.That(_uut.Tracks.FlightTracks[0].Timestamp, Is.EqualTo(track.Timestamp));
        }


    }
}