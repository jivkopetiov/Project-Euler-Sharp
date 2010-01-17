using System;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 171)]
    class Euler19 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            // We know that 1 January 1901 is Tuesday
            int year = 1901;
            Month month = Month.January;
            int day = 1;
            DayOfWeek weekDay = DayOfWeek.Tuesday;
            // --------------------------------------

            int sundaysThatAreDay1 = 0;

            while (year < 2001)
            {
                if (weekDay == DayOfWeek.Sunday && day == 1)
                {
                    sundaysThatAreDay1++;
                }

                day = day.GetNextDay(month, year);
                weekDay = weekDay.GetNextWeekDay();

                if (day == 1)
                {
                    month = month.GetNextMonth();
                    if (month == Month.January)
                    {
                        year++;
                    }
                }
            }

            Verify(sundaysThatAreDay1);
        }
    }
}
