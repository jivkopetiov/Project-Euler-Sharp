using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ProjectEulerSharp.UnitTests
{
    [TestFixture]
    public class NumberExtensionsTests
    {
        [Test]
        public void IsPalindrome_OddDigitsCorrectPalindrome()
        {
            Assert.IsTrue(5609065.IsPalindrome());
        }

        [Test]
        public void IsPalindrome_EvenDigitsCorrectPalindrome()
        {
            Assert.IsTrue(569965.IsPalindrome());
        }

        [Test]
        public void IsPalindrome_OddDigitsIncorrectPalindrome()
        {
            Assert.IsFalse(5699651.IsPalindrome());
        }
    }
}
