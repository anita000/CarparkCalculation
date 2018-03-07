using System;

namespace CarparkCalculation.BusinessLayer
{
    public interface IFlatRateConditions
    {
        bool MeetEntryCondition(DateTime entryDateTime);
        bool MeetExitCondition(DateTime entryDateTime, DateTime exitDateTime);
    }
}
