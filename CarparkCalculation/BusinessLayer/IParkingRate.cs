namespace CarparkCalculation.BusinessLayer
{
    public interface IParkingRate
    {
        string Name { get; set; }
        RateType Type { get; set; }
        decimal TotalPrice { get; set; }
    }
}
