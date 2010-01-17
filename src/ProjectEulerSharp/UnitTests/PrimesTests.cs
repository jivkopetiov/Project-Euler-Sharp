using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ProjectEulerSharp.UnitTests
{
    [TestFixture]
    public class PrimesTests
    {
        [Test]
        public void BelowTenMillion_IsCorrectSize()
        {
            var primes = Primes.BelowTenMillion;
            Assert.AreEqual(664579, primes.Count());
            Assert.AreEqual(9999991, primes.Last());
        }
    }
}
