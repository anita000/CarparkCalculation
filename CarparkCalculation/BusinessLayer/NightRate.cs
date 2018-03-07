namespace CarparkCalculation.BusinessLayer
{
    public class NightRate : IParkingRate
    {
        public string Name {  get; set; }
        public RateType Type { get; set; }
        public decimal TotalPrice { get; set; }

        public NightRate(string name)
        {
            Name = name;
            Type = RateType.FlatRate;
            TotalPrice = 6.5m;
        }
    }
}
