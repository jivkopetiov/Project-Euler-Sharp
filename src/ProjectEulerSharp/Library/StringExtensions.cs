using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ProjectEulerSharp
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string input)
        {
            for (int index = 0; index < input.Length / 2; index++)
            {
                if (input[index] != input[input.Length - index - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static string ReplaceWithRegex(this string input, string regex, string replacement)
        {
            return Regex.Replace(input, regex, replacement);
        }

        /// <summary>
        ///     Only works against lower-case letters
        /// </summary>
        public static int AlphabeticalWeight(this string word)
        {
            int number = 0;

            foreach (char ch in word)
            {
                number += ((int)ch - 96);
            }

            return number;
        }
    }
}
