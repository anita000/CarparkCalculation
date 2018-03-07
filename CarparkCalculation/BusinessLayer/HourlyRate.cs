using System;

namespace CarparkCalculation.BusinessLayer
{
    public class HourlyRate : IHourlyRate
    {
        public decimal GetTotalPrice(DateTime entryDateTime, DateTime exitDateTime)
        {
            decimal totalPrice = 0;
            var numOfHours = (exitDateTime - entryDateTime).TotalHours;

            if (numOfHours <= 1)
            {
                totalPrice = 5.00m;
            }
            else if (numOfHours <= 2)
            {
                totalPrice = 10.00m;
            }
            else if (numOfHours <= 3)
            {
                totalPrice = 15.00m;
            }
            else
            {
                totalPrice = (decimal)Math.Ceiling((exitDateTime - entryDateTime).TotalDays) * 20.00m;
            }
            return totalPrice;
        }
    }
}
