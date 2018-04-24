using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes;
using ATM.Classes.Domain;
using ATM.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    [TestFixture()]
    public class SeperationUnitTests
    {
        private ISeperation _uut;

        [SetUp]
        public void Init()
        {
            _uut = new Seperation();
        }

        [Test]
        public void Seperation_CheckSeperation_IsNotInAirspace()
        {
            var list = new List<ITrack>();

            //list.Add(new Track("Tag;10001;10001;10001;00010101010101001"));
            bool called = false;
            _uut.SeperationEvent += (object sender, SeperationEventArgs eventArgs) => { called = true; };


            _uut.CheckSeperation(list, list[0]);

            Assert.False(called);

        }

        [Test]
        public void Seperation_CheckSeperation_IsInAirspace()
        {
            var list = new List<ITrack>();
            //var track = new Track("Tag;10001;10001;10001;00010101010101001");

            //track.IsInAirspace = true;

            //list.Add(track);

            bool called = false;
            _uut.SeperationEvent += (object sender, SeperationEventArgs eventArgs) => { called = true; };


            _uut.CheckSeperation(list, list[0]);

            Assert.False(called);
        }

        [Test]
        public void Seperation_CheckSeperationIsSeperationEvent_IsInAirspace()
        {
            var list = new List<ITrack>();
            //var track = new Track("Tag;10001;10001;10001;00010101010101001");
            //var track2 = new Track("Tag2;10002;10002;10002;00010101010101001");

            //track.IsInAirspace = true;
            //track2.IsInAirspace = true;

            //list.Add(track);
            //list.Add(track2);

            bool called = false;
            _uut.SeperationEvent += (object sender, SeperationEventArgs eventArgs) => { called = true; };


            _uut.CheckSeperation(list, list[0]);

            Assert.True(called);
        }

        [Test]
        public void SeperationOverload_CheckSeperation_IsNotInAirspace()
        {
            var list = new List<ITrack>();
            //list.Add(new Track("Tag;10001;10001;10001;00010101010101001"));

            var actual = _uut.CheckSeperation(list);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void SeperationOverload_CheckSeperation_IsInAirspace()
        {
            var list = new List<ITrack>();
            //var track = new Track("Tag;10001;10001;10001;00010101010101001");

            //track.IsInAirspace = true;

            //list.Add(track);

            var actual = _uut.CheckSeperation(list);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void SeperationOverload_CheckSeperationIsSeperationEvent_IsInAirspace()
        {
            var list = new List<ITrack>();
            //var track = new Track("Tag;10001;10001;10001;00010101010101001");
            //var track2 = new Track("Tag2;10002;10002;10002;00010101010101001");

            //track.IsInAirspace = true;
            //track2.IsInAirspace = true;

            //list.Add(track);
            //list.Add(track2);

            var actual = _uut.CheckSeperation(list);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void SeperationOverload_CheckSeperationIsSeperationEvent_IsNotInAirspace()
        {
            var list = new List<ITrack>();
            //var track = new Track("Tag;10001;10001;10001;00010101010101001");
            //var track2 = new Track("Tag2;20002;20002;20002;00010101010101001");

            //track.IsInAirspace = true;
            //track2.IsInAirspace = true;

            //list.Add(track);
            //list.Add(track2);

            var actual = _uut.CheckSeperation(list);

            Assert.IsNotEmpty(actual);
        }
    }
}
