using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Utility;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
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
