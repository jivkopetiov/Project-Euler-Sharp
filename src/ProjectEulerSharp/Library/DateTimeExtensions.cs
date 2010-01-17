using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerSharp
{
    public static class DateTimeExtensions
    {
        public static Month GetNextMonth(this Month month)
        {
            if (month == Month.December)
            {
                return Month.January;
            }
            else
            {
                return month + 1;
            }
        }

        public static DayOfWeek GetNextWeekDay(this DayOfWeek weekDay)
        {
            if (weekDay == DayOfWeek.Saturday)
            {
                return DayOfWeek.Sunday;
            }
            else
            {
                return weekDay + 1;
            }
        }

        public static int GetNextDay(this int day, Month month, int year)
        {
            int daysInMonth = DateTime.DaysInMonth(year, (int)month);
            if (day == daysInMonth)
            {
                return 1;
            }
            else
            {
                return day + 1;
            }
        }
    }

    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
