using System;

namespace CarparkCalculation.BusinessLayer
{
    public interface IWeekendRateConditions : IFlatRateConditions
    {
        bool MeetAllConditions(DateTime entryDateTime, DateTime exitDateTime);
    }
}
