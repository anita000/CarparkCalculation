using System;

namespace CarparkCalculation.BusinessLayer
{
    public interface IHourlyRate
    {
        decimal GetTotalPrice(DateTime entryDateTime, DateTime exitDateTime);
    }
}
