namespace CarparkCalculation.BusinessLayer
{
    public class EarlyBirdRate : IParkingRate
    {
        public string Name { get; set; }
        public RateType Type { get; set; }
        public decimal TotalPrice { get; set; }

        public EarlyBirdRate(string name)
        {
            Name = name;
            Type = RateType.FlatRate;
            TotalPrice = 13.00m;
        }
    }
}
