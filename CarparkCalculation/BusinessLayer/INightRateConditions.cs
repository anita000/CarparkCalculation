using System;

namespace CarparkCalculation.BusinessLayer
{
    public interface INightRateConditions : IFlatRateConditions
    {
        bool MeetAllConditions(DateTime entryDateTime, DateTime exitDateTime);
    }
}
