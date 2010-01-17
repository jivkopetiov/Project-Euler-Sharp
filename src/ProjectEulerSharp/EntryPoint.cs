using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ProjectEulerSharp
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                int currentProblem = 14;

                if (args != null && args.Length > 0)
                {
                    currentProblem = int.Parse(args[0]);
                }

                var problem = EulerProblem.Create(currentProblem);
                problem.Solve();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private static void HandleError(Exception ex)
        {
            // try to hide target invocation exception because it does not carry any value
            if (ex is TargetInvocationException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.InnerException ?? ex);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
            }
        }
    }
}
