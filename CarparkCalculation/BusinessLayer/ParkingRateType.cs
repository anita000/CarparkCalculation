using Ninject;
using System;

namespace CarparkCalculation.BusinessLayer
{
    public class ParkingRateType : IParkingRateType
    {
        private readonly INightRateConditions _nightRateConditions;
        private readonly IWeekendRateConditions _weekendRateConditions;
        private readonly IEarlyBirdConditions _earlyBirdRateConditions;

        public ParkingRateType()
        {
        }

        public ParkingRateType (INightRateConditions nightRateConditions, IWeekendRateConditions weekendRateConditions, IEarlyBirdConditions earlyBirdRateConditions)
        {
            _nightRateConditions = nightRateConditions;
            _weekendRateConditions = weekendRateConditions;
            _earlyBirdRateConditions = earlyBirdRateConditions;
        }

        public RateName GetParkingRateName(DateTime entryDateTime, DateTime exitDateTime)
        {
            if (exitDateTime < entryDateTime)
                throw new Exception("Exit date cannot be less than entry date");

            var rateType = RateName.Standard;

            if (_nightRateConditions.MeetAllConditions(entryDateTime, exitDateTime))
            {
                rateType = RateName.Night;
            }
            else if (_weekendRateConditions.MeetAllConditions(entryDateTime, exitDateTime))
            {
                rateType = RateName.Weekend;
            }
            else if (_earlyBirdRateConditions.MeetAllConditions(entryDateTime, exitDateTime))
            {
                rateType = RateName.EarlyBird;
            }
            return rateType;
        }
    }

    public enum RateName
    {
        EarlyBird,
        Night,
        Weekend,
        Standard
    }

    public enum RateType
    {
        FlatRate,
        HourlyRate
    }
}
