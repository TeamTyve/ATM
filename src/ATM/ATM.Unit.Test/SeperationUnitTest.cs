using ATM.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Domain;
using ATM.Classes.Interfaces;
using Castle.Core.Internal;
using NSubstitute;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    
    [TestFixture]
    public class SeperationUnitTest
    {
        private Seperation _uut;
        [SetUp]
        public void SetUp()
        {
            _uut = new Seperation();
        }

        [Test]
        public void CheckSeperation_NotInAirSpaceAndSameTag_Empty()
        {
            bool called = false;
            var track = new Track("Tag;0;0;0;00010101010101001");
            var list = new List<ITrack>();
            list.Add(track);
            _uut.SeperationEvent += (o, e) => called = true;
            _uut.CheckSeperation(list, track);
            Assert.IsFalse(called);
        }

        [Test]
        public void CheckSeperation_InAirSpaceAndSameTag_Empty()
        {
            bool called = false;
            var track = new Track("Tag;0;0;0;00010101010101001");
            track.IsInAirspace = true; 
            var list = new List<ITrack>();
            list.Add(track);
            _uut.SeperationEvent += (o, e) => called = true;
            _uut.CheckSeperation(list, track);
            Assert.IsFalse(called);
        }

        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;0;0;0;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5000;5000;300;00010101010101001")]
        public void CheckSeperation_InAirSpaceAndDifferentTagInDanger_EventRaised(string tag1, string tag2)
        {
            var list = new List<ITrack>();
            bool called = false;
            var track1 = new Track(tag1);
            track1.IsInAirspace = true;
            var track2 = new Track(tag2);
            track2.IsInAirspace = true;
            list.Add(track2);
            _uut.SeperationEvent += (o, e) => called = true;
            _uut.CheckSeperation(list, track1);
            Assert.IsTrue(called);
        }

        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5001;5000;300;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5000;5001;300;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5001;5000;301;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5000;5001;301;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5000;5000;301;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5001;5001;301;00010101010101001")]
        public void CheckSeperation_InAirSpaceAndDifferentTagOutOfDanger_EventNotRaised(string tag1, string tag2)
        {
            var list = new List<ITrack>();
            bool called = false;
            var track1 = new Track(tag1);
            track1.IsInAirspace = true;
            var track2 = new Track(tag2);
            track2.IsInAirspace = true;
            list.Add(track2);
            _uut.SeperationEvent += (o, e) => called = true;
            _uut.CheckSeperation(list, track1);
            Assert.IsFalse(called);
        }

        [Test]
        public void CheckSeperationTuple_SameTag_EmptyList()
        {
            var list = new List<ITrack>();
            bool called = false;
            var track1 = new Track("Tag1;0;0;0;00010101010101001");
            list.Add(track1);
            list.Add(track1);
            var result = _uut.CheckSeperation(list);
            Assert.IsTrue(result.IsNullOrEmpty());
        }

        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5001;5000;300;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5000;5001;300;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5001;5000;301;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5000;5001;301;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5000;5000;301;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5001;5001;301;00010101010101001")]
        public void CheckSeperationTupple_InAirSpaceAndDifferentTagOutOfDanger_AddedToList(string tag1, string tag2)
        {
            var list = new List<ITrack>();
            var track1 = new Track(tag1);
            var track2 = new Track(tag2);
            list.Add(track2);
            list.Add(track1);
            var result = _uut.CheckSeperation(list);
            var Tuple = new Tuple<ITrack,ITrack>(track2,track1);
            Assert.IsTrue(result.Contains(Tuple));
        }


        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;0;0;0;00010101010101001")]
        [TestCase("Tag1;0;0;0;00010101010101001", "Tag2;5000;5000;300;00010101010101001")]
        public void CheckSeperationTuple_InAirSpaceAndDifferentTagInDanger_ListEmpty(string tag1, string tag2)
        {
            var list = new List<ITrack>();
            var track1 = new Track(tag1);
            var track2 = new Track(tag2);
            list.Add(track2);
            list.Add(track1);
            var result = _uut.CheckSeperation(list);
            Assert.IsTrue(result.IsNullOrEmpty());
        }
    }
}
