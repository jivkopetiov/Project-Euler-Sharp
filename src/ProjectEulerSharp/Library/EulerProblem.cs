using System;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;

namespace ProjectEulerSharp
{
    public abstract class EulerProblem
    {
        private Stopwatch _stopwatch;
        protected long _result;

        [SetUp]
        public void Initialize()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        protected virtual void Verify(long actual)
        {
            Type eulerType = this.GetType();

            string eulerName = eulerType.Name;

            MetadataAttribute[] attributes =
                (MetadataAttribute[])eulerType.GetCustomAttributes(typeof(MetadataAttribute), true);
            var metadata = attributes.First();

            Console.WriteLine(eulerName + " :: " + actual + " :: (" + _stopwatch.ElapsedMilliseconds + " milli)");

            Assert.AreEqual(metadata.Result, actual);
        }

        public abstract void Solve();

        public static EulerProblem Create(int number)
        {
            Type eulerType = Type.GetType("ProjectEulerSharp.Euler" + number.ToString());
            if (eulerType == null)
            {
                throw new InvalidOperationException(
                    string.Format("EulerProblem with id {0} not found", number));
            }
            var eulerProblem = Activator.CreateInstance(eulerType) as EulerProblem;
            if (eulerProblem == null)
            {
                throw new InvalidOperationException(
                    string.Format("EulerProblem with id {0} could not be created", number));
            }
            return eulerProblem;
        }
    }
}
