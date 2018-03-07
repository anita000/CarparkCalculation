namespace CarparkCalculation.BusinessLayer
{
    public class WeekendRate : IParkingRate
    {
        public string Name { get; set; }
        public RateType Type { get; set; }
        public decimal TotalPrice { get; set; }

        public WeekendRate(string name)
        {
            Name = name;
            Type = RateType.FlatRate;
            TotalPrice = 10.00m;
        }
    }
}
