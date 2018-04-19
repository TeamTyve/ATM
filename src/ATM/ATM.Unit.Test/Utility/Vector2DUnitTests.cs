using ATM.Utility;
using NUnit.Framework;

namespace ATM.Unit.Test.Utility
{
    [TestFixture]
    public class Vector2DUnitTests
    {
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void Vector2D_IsPositive_ReturnsTrue(int x, int y)
        {
            Assert.True(new Vector2D(x, y).IsPositive());
        }

        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        [TestCase(-1, 0)]
        public void Vector2D_IsNegative_ReturnsFalse(int x, int y)
        {
            Assert.False(new Vector2D(x, y).IsPositive());
        }
    }
}
