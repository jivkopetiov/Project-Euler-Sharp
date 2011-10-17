using System.Linq;
using NUnit.Framework;
using System;
using Facet.Combinatorics;
using System.Collections.Generic;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 1258)]
    public class Euler93 : EulerProblem
    {
        // 1 is plus, 2 is multiply, 3 is minus, 4 is divide
        private readonly Variations<int> operationVariations = new Variations<int>(new[] { 1, 2, 3, 4 }, 3, GenerateOption.WithRepetition);

        [Test]
        public override void Solve()
        {
            var allSets = new Combinations<int>(Enumerable.Range(1, 9).ToArray(), 4, GenerateOption.WithoutRepetition);

            int topMax = 0;
            IList<int> topSet = null;

            foreach (IList<int> set in allSets)
            {
                int setMax = GetResultsForSet(set);

                if (setMax >= topMax)
                {
                    topMax = setMax;
                    topSet = set;
                }

            }

            Console.Write(topMax + " - ");
            string result = "";
            foreach (int i in topSet)
                result += i.ToString();

            int intResult = int.Parse(result);

            Verify(intResult);
        }

        private int GetResultsForSet(IList<int> set)
        {
            var setPermutations = new Permutations<int>(set, GenerateOption.WithoutRepetition);

            var results = new HashSet<int>();

            bool shouldPrint = (set[0] == 1 && set[1] == 2 && set[2] == 5 && set[3] == 6);

            foreach (IList<int> nums in setPermutations)
            {
                foreach (IList<int> ops in operationVariations)
                {
                    // Possible bracket combinations:

                    int a = 0;

                    try
                    {
                        // (1 2)(3 4)
                        a = Add(
                            O(O(nums[0], nums[1], ops[0]), O(nums[2], nums[3], ops[2]), ops[1]),
                            results);

                        //if (shouldPrint)
                        //    Console.WriteLine(string.Format("({0} {1} {2}) {3} ({4} {5} {6}) = {7}",
                        //                      nums[0], Op(ops[0]), nums[1], Op(ops[1]), nums[2], Op(ops[2]), nums[3], a));
                    }
                    catch { }

                    try
                    {
                        // ((1 2)3) 4
                        a = Add(
                            O(O(O(nums[0], nums[1], ops[0]), nums[2], ops[1]), nums[3], ops[2]),
                            results);
                    }
                    catch { }

                    try
                    {
                        // (1(2 3)) 4
                        a = Add(
                            O(O(nums[0], O(nums[1], nums[2], ops[1]), ops[0]), nums[3], ops[2]),
                            results);

                        //if (shouldPrint)
                        //    Console.WriteLine(string.Format(" ({0} {1} ({2} {3} {4})) {5} {6} = {7}",
                        //                      nums[0], Op(ops[0]), nums[1], Op(ops[1]), nums[2], Op(ops[2]), nums[3], a));
                    }
                    catch { }

                    try
                    {
                        // 1 ((2 3)4)
                        a = Add(
                            O(nums[0], O(O(nums[1], nums[2], ops[1]), nums[3], ops[2]), ops[0]),
                            results);
                    }
                    catch { }

                    try
                    {
                        // 1 (2(3 4))
                        a = Add(
                            O(nums[0], O(nums[1], O(nums[2], nums[3], ops[2]), ops[1]), ops[0]),
                            results);
                    }
                    catch { }
                }
            }

            var ordered = results.OrderBy(o => o).ToList();

            int lastMax = 0;

            for (int counter = 1; counter < ordered.Count; counter++)
            {
                if (ordered[counter] != ordered[counter - 1] + 1)
                {
                    lastMax = ordered[counter - 1];

                    break;
                }
            }

            //if (shouldPrint)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    foreach (int num in ordered)
            //        Console.Write(num + " ");

            //    Console.WriteLine();
            //    Console.WriteLine(lastMax);
            //    Console.WriteLine();
            //}

            return lastMax;
        }

        private int Add(int num, HashSet<int> results)
        {
            if (num <= 0 || num > 100000)
                return num;

            if (!results.Contains(num))
                results.Add(num);

            return num;
        }

        private string Op(int operation)
        {
            switch (operation)
            {
                case 1:
                    return "+";
                case 2:
                    return "*";
                case 3:
                    return "-";
                case 4:
                    return "/";
                default:
                    throw new Exception();
            }
        }

        private int O(int a, int b, int operation)
        {
            switch (operation)
            {
                case 1:
                    return a + b;
                case 2:
                    return a * b;
                case 3:
                    return a - b;
                case 4:
                    if (a % b != 0)
                        return int.MinValue;
                    else
                        return a / b;
                default:
                    throw new Exception();
            }
        }
    }
}
