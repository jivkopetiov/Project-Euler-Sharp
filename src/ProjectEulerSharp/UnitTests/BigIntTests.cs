using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ProjectEulerSharp.UnitTests
{
    [TestFixture]
    public class BigIntTests
    {
        [Test]
        public void Multiply_SmallNumbers()
        {
            int b = 34031;
            int a = 10340;
            Assert.AreEqual(a * b,
                            (new BigInt(a) * b).ToNumber(),
                            string.Format("{0} * {1} should be {2}", a * b, a, b));
        }

        [Test]
        public void Multiply_BigBySmall()
        {
            var big = new BigInt("2892858921897322738439223225");
            int small = 93743224;
            Assert.AreEqual("271185921915819230469801513167177400",
                            (big * small).ToString());
        }
    }
}
