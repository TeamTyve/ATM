using ATM.Classes;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class TrackUnitTest 
    {
        [TestCase("Tag;0;0;0;00010101010101001")]
        [TestCase("Tag;1;1;1;99991230235959999")]
        public void Extract_CanExtract(string expected)
        {
            var uut = new Track(expected);

            Assert.That(uut.Tag, Is.EqualTo(expected.Split(';')[0]));
            Assert.That(uut.Altitude.ToString(), Is.EqualTo(expected.Split(';')[1]));
            Assert.That(uut.XCoordinate.ToString(), Is.EqualTo(expected.Split(';')[2]));
            Assert.That(uut.YCoordinate.ToString(), Is.EqualTo(expected.Split(';')[3]));
            Assert.That(uut.Timestamp.ToString("yyyyMMddHHmmssfff"), Is.EqualTo(expected.Split(';')[4]));

        }
    }
}