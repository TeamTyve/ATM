using ATM.Utility;
using NUnit.Framework;

namespace ATM.Unit.Test.Utility
{
    [TestFixture]
    public class Vector3DUnitTests
    {
        [TestCase(0, 0, 0)]
        [TestCase(0, 0, 1)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        [TestCase(1, 1, 1)]
        public void Vector3D_IsPositive_ReturnsTrue(int x, int y, int z)
        {
            Assert.True(new Vector3D(x, y, z).IsPositive());
        }

        [TestCase(0, 0, -1)]
        [TestCase(0, -1, 0)]
        [TestCase(0, -1, -1)]
        [TestCase(-1, 0, 0)]
        [TestCase(-1, 0, 1)]
        [TestCase(-1, -1, 0)]
        [TestCase(-1, -1, -1)]
        public void Vector3D_IsNegative_ReturnsFalse(int x, int y, int z)
        {
            Assert.False(new Vector3D(x, y, z).IsPositive());
        }
    }
}