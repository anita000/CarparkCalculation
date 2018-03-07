using System;
using CarparkCalculation.Utils;

namespace CarparkCalculation.BusinessLayer
{
    public class WeekendRateConditions : IWeekendRateConditions
    {
        public bool MeetAllConditions(DateTime entryDateTime, DateTime exitDateTime)
        {
            return MeetEntryCondition(entryDateTime) && MeetExitCondition(entryDateTime, exitDateTime);
        }

        public bool MeetEntryCondition(DateTime entryDateTime)
        {
            return DateUtil.IsWeekend(entryDateTime);
        }

        public bool MeetExitCondition(DateTime entryDateTime, DateTime exitDateTime)
        {
            var followingSunday = DateUtil.NextDayofTheWeek(entryDateTime, DayOfWeek.Sunday);

            return exitDateTime.Date <= followingSunday.Date;
        }
    }
}
