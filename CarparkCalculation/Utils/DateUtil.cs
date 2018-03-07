using System;

namespace CarparkCalculation.Utils
{
    public static class DateUtil
    {
        public static bool IsTheNextDay(DateTime nextdayDate, DateTime startDate)
        {
            return startDate.Date.AddDays(1) == nextdayDate.Date;
        }

        public static bool IsSameDay(DateTime startDate, DateTime enddate)
        {
            return startDate.Date == enddate.Date;
        }

        public static bool IsWeekend(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }

        public static bool SundayOrMonday(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Monday)
            {
                return true;
            }
            return false;
        }

        public static DateTime NextDayofTheWeek(this DateTime from, DayOfWeek dayOfWeek)
        {
            var start = from.DayOfWeek;
            var target = dayOfWeek;
            if (target <= start)
            {
                target += 7;
            }
            return from.AddDays(target - start);
        }

        public static bool ValidDates(DateTime entryDateTime, DateTime exitDateTime)
        {
            if (exitDateTime < entryDateTime)
            {
                Console.WriteLine("Exit date has to be after entry date. Please try again.");
                return false;
            }
            return true;
        }
    }
}
