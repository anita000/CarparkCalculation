using System;

namespace CarparkCalculation.BusinessLayer
{
    public class EarlyBirdConditions : IEarlyBirdConditions
    {
        private readonly TimeSpan _earlyBirdRateEntryStartTime = new TimeSpan(6, 0, 0);
        private readonly TimeSpan _earlyBirdRateEntryEndTime = new TimeSpan(9, 0, 0);
        private readonly TimeSpan _earlyBirdRateExitStartTime = new TimeSpan(15, 30, 0);
        private readonly TimeSpan _earlyBirdRateExitEndTime = new TimeSpan(23, 30, 0);

        public bool MeetAllConditions(DateTime entryDateTime, DateTime exitDateTime)
        {
            if (exitDateTime < entryDateTime)
            {
                throw new Exception("Exit date must be after entry date");
            }
            return MeetEntryCondition(entryDateTime) && MeetExitCondition(entryDateTime, exitDateTime);
        }

        public bool MeetEntryCondition(DateTime entryDateTime)
        {
            return entryDateTime.TimeOfDay >= _earlyBirdRateEntryStartTime && entryDateTime.TimeOfDay <= _earlyBirdRateEntryEndTime;
        }

        public bool MeetExitCondition(DateTime entryDateTime, DateTime exitDateTime)
        {
            if (exitDateTime < entryDateTime)
            {
                throw new Exception("Exit date must be after entry date");
            }
            return exitDateTime.Date == entryDateTime.Date && exitDateTime.TimeOfDay >=_earlyBirdRateExitStartTime && exitDateTime.TimeOfDay <= _earlyBirdRateExitEndTime;
        }
    }
}
