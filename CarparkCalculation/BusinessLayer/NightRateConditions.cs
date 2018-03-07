using System;
using CarparkCalculation.Utils;

namespace CarparkCalculation.BusinessLayer
{
    public class NightRateConditions : INightRateConditions
    {

        private readonly TimeSpan _nightRateEntryStartTime = new TimeSpan(18, 0, 0);
        private readonly TimeSpan _nightRateEntryEndTime = new TimeSpan(0, 0, 0);
        private readonly TimeSpan _nightRateExitTime = new TimeSpan(6, 0, 0);

        public bool MeetAllConditions(DateTime entryDateTime, DateTime exitDateTime)
        {
            return MeetEntryCondition(entryDateTime) && MeetExitCondition(entryDateTime, exitDateTime);
        }

        public bool MeetEntryCondition(DateTime entryDateTime)
        {
            return ((!DateUtil.IsWeekend(entryDateTime) && entryDateTime.TimeOfDay > _nightRateEntryStartTime)
                || (!DateUtil.SundayOrMonday(entryDateTime) && entryDateTime.TimeOfDay <= _nightRateEntryEndTime));
        }

        public bool MeetExitCondition(DateTime entryDateTime, DateTime exitDateTime)
        {
            return ((DateUtil.IsSameDay(entryDateTime, exitDateTime) && (exitDateTime.TimeOfDay > entryDateTime.TimeOfDay))
                || DateUtil.IsTheNextDay(exitDateTime, entryDateTime) && exitDateTime.TimeOfDay < _nightRateExitTime);

        }
    }
}
