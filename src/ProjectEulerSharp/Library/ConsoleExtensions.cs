using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerSharp
{
    public static class ConsoleExtensions
    {
        public static IEnumerable<T> Dump<T>(this IEnumerable<T> target)
        {
            foreach (var item in target)
            {
                Console.WriteLine(item);
            }

            return target;
        }

        public static IEnumerable<T> DumpLine<T>(this IEnumerable<T> target)
        {
            return DumpLine(target, " ");
        }

        public static IEnumerable<T> DumpLine<T>(this IEnumerable<T> target, string separator)
        {
            if (target.Count() == 0)
            {
                return target;
            }

            var builder = new StringBuilder();
            foreach (var item in target)
            {
                builder.Append(item + separator);
            }
            String result = builder.ToString();
            result = result.Substring(0, result.Length - 1);

            Console.WriteLine(result);

            return target;
        }
    }
}
