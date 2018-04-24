using ATM.Classes;
using ATM.Classes.Domain;
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
            //var uut = new Track(expected);

            //Assert.That(uut.Tag, Is.EqualTo(expected.Split(';')[0]));
            //Assert.That(uut.Vector.Z.ToString(), Is.EqualTo(expected.Split(';')[1]));
            //Assert.That(uut.Vector.X.ToString(), Is.EqualTo(expected.Split(';')[2]));
            //Assert.That(uut.Vector.Y.ToString(), Is.EqualTo(expected.Split(';')[3]));
            //Assert.That(uut.Timestamp.ToString("yyyyMMddHHmmssfff"), Is.EqualTo(expected.Split(';')[4]));

        }
    }
}