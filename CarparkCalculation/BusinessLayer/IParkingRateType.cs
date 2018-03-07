using System;

namespace CarparkCalculation.BusinessLayer
{
    public interface IParkingRateType
    {
        RateName GetParkingRateName(DateTime entryDateTime, DateTime exitDateTime);
    }
}
