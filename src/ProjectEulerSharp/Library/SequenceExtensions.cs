using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerSharp
{
    public static class SequenceExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> input)
        {
            return new HashSet<T>(input);
        }
    }
}
