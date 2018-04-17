using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    [TestFixture()]
    public class AirSpaceUnitTest
    {
        private AirSpace _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new AirSpace();
        }

        [TestCase(10000, 10000, 500, 90000, 90000, 20000)]
        public void AirSpace_CanInitialize_Default_ObjectInitialized(
            int x1, 
            int y1, 
            int z1,
            int x2, 
            int y2,
            int z2)
        {
            _uut = new AirSpace();
            Assert.That(_uut.Coordinate1.X, Is.EqualTo(x1));
            Assert.That(_uut.Coordinate1.Y, Is.EqualTo(y1));
            Assert.That(_uut.Coordinate1.Z, Is.EqualTo(z1));

            Assert.That(_uut.Coordinate2.X, Is.EqualTo(x2));
            Assert.That(_uut.Coordinate2.Y, Is.EqualTo(y2));
            Assert.That(_uut.Coordinate2.Z, Is.EqualTo(z2));
        }

        [TestCase(10000, 10000, 500)]
        [TestCase(89999, 89999, 19999)]
        public void AirSpace_CanInitialize_Lower_ObjectInitialized(int x, int y, int z)
        {
            _uut = new AirSpace(new Vector3D(x, y, z));
            Assert.That(_uut.Coordinate1.X, Is.EqualTo(x));
            Assert.That(_uut.Coordinate1.Y, Is.EqualTo(y));
            Assert.That(_uut.Coordinate1.Z, Is.EqualTo(z));
        }

        [TestCase(10001, 10001, 501)]
        [TestCase(90000, 90000, 20000)]
        public void AirSpace_CanInitialize_Higher_ObjectInitialized(int x, int y, int z)
        {
            _uut = new AirSpace(coordinate2: new Vector3D(x, y, z));
            Assert.That(_uut.Coordinate2.X, Is.EqualTo(x));
            Assert.That(_uut.Coordinate2.Y, Is.EqualTo(y));
            Assert.That(_uut.Coordinate2.Z, Is.EqualTo(z));
        }

        [TestCase(90000, 90000, 20000)]
        [TestCase(90000, 90000, 19999)]
        [TestCase(90000, 89999, 20000)]
        [TestCase(90000, 89999, 19999)]
        [TestCase(89999, 90000, 20000)]
        [TestCase(89999, 90000, 19999)]
        [TestCase(89999, 89999, 20000)]
        public void AirSpace_CanInitialize_Lower_WillThrow(int x, int y, int z)
        {
            Assert.Throws<ArgumentException>(() => _uut = new AirSpace(coordinate1: new Vector3D(x, y, z)));
        }

        [TestCase(10000, 10000, 500)]
        [TestCase(10000, 10000, 501)]
        [TestCase(10000, 10001, 500)]
        [TestCase(10000, 10001, 501)]
        [TestCase(10001, 10000, 500)]
        [TestCase(10001, 10001, 500)]
        public void AirSpace_CanInitialize_Higher_WillThrow(int x, int y, int z)
        {
            Assert.Throws<ArgumentException>(() => _uut = new AirSpace(coordinate2: new Vector3D(x, y, z)));
        }

        [TestCase(-1, -1, -1)]
        public void AirSpace_CanInitializeNegativeValues_Lower_WillThrow(int x, int y, int z)
        {
            Assert.Throws<ArgumentException>(() => _uut = new AirSpace(coordinate1: new Vector3D(x, y, z)));
        }

        [TestCase(-1, -1, -1)]

        public void AirSpace_CanInitializeNegativeValues_Higher_WillThrow(int x, int y, int z)
        {
            Assert.Throws<ArgumentException>(() => _uut = new AirSpace(coordinate2: new Vector3D(x, y, z)));
        }
    }
}
