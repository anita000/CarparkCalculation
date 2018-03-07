using CarparkCalculation.BusinessLayer;

namespace CarparkCalculation
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IParkingRateType>().To<ParkingRateType>();
            Kernel.Bind<IHourlyRate>().To<HourlyRate>();
            Kernel.Bind<INightRateConditions>().To<NightRateConditions>();
            Kernel.Bind<IWeekendRateConditions>().To<WeekendRateConditions>();
            Kernel.Bind<IEarlyBirdConditions>().To<EarlyBirdConditions>();
        }
    }
}
