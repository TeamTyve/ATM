﻿using System.Linq;
using ATM.Classes.Domain;
using ATM.Classes.Interfaces;
using NUnit.Framework;

namespace ATM.Unit.Test.Domain
{
    [TestFixture]
    public class TrackRepositoryUnitTest
    {
        private ITrackRepository uut;

        [SetUp]
        public void SetUp()
        {
            uut = new TrackRepository();
        }

        [TestCase("Tag;0;0;0;00010101010101001")]
        [TestCase("Tag;1;1;1;99991230235959999")]
        public void Tracks_CanAdd_ReturnsObject(string expected)
        {
            //uut.Add(expected);
            var actual = uut.FlightTracks.First(e => e.Tag == expected.Split(';')[0]);
            //var expectedTrack = new Track(expected);

            //Assert.That(actual.Tag, Is.EqualTo(expectedTrack.Tag));
            //Assert.That(actual.Vector.X, Is.EqualTo(expectedTrack.Vector.X));
            //Assert.That(actual.Vector.Y, Is.EqualTo(expectedTrack.Vector.Y));
            //Assert.That(actual.Vector.Z, Is.EqualTo(expectedTrack.Vector.Z));
            //Assert.That(actual.Timestamp, Is.EqualTo(expectedTrack.Timestamp));
        }

        [TestCase("Tag;0;0;0;00010101010101001")]
        [TestCase("Tag;1;1;1;99991230235959999")]
        public void Tracks_CanAddUpdate_ReturnsObject(string expected)
        {
            //uut.Add(expected);
            //uut.Add("Tag;2;2;2;99991230235959999");
            //var actual = uut.FlightTracks.First(e => e.Tag == expected.Split(';')[0]);
            //var expectedTrack = new Track("Tag;2;2;2;99991230235959999");

            //Assert.That(actual.Tag, Is.EqualTo(expectedTrack.Tag));
            //Assert.That(actual.Vector.X, Is.EqualTo(expectedTrack.Vector.X));
            //Assert.That(actual.Vector.Y, Is.EqualTo(expectedTrack.Vector.Y));
            //Assert.That(actual.Vector.Z, Is.EqualTo(expectedTrack.Vector.Z));
            //Assert.That(actual.Timestamp, Is.EqualTo(expectedTrack.Timestamp));
        }
    }
}
