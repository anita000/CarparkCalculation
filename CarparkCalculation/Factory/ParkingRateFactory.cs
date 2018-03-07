using CarparkCalculation.BusinessLayer;

namespace CarparkCalculation.Factory
{
    public class ParkingRateFactory
    {
        public virtual IParkingRate CreateParkingRate(RateName rateType)
        {
            IParkingRate parkingRate = null;

            switch (rateType)
            {
                case RateName.Standard:
                    parkingRate = new StandardRate("Standard Rate");
                    break;
                case RateName.Night:
                    parkingRate = new NightRate("Night Rate");
                    break;
                case RateName.EarlyBird:
                    parkingRate = new EarlyBirdRate("Early Bird Rate");
                    break;
                case RateName.Weekend:
                    parkingRate = new WeekendRate("Weekend Rate");
                    break;
            }
            return parkingRate;
        }
    }
}
