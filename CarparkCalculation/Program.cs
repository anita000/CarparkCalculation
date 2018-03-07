using System;
using Ninject;
using System.Reflection;
using CarparkCalculation.BusinessLayer;
using CarparkCalculation.Factory;
using System.Globalization;
using CarparkCalculation.Utils;

namespace CarparkCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var parkingRateType = kernel.Get<IParkingRateType>();
            var hourlyRate = kernel.Get<IHourlyRate>();

            Console.WriteLine("Press ESC to stop");

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                var entryDateTime = DateTime.MinValue;
                var exitDateTime = DateTime.MinValue;

                do
                {
                    entryDateTime = GetDate("Entry");
                    exitDateTime = GetDate("Exit");
                }
                while (!DateUtil.ValidDates(entryDateTime, exitDateTime));

                var rateType = parkingRateType.GetParkingRateName(entryDateTime, exitDateTime);

                var parkingRatefactory = new ParkingRateFactory();
                var rate = parkingRatefactory.CreateParkingRate(rateType);

                var totalPrice = rate.Type == RateType.FlatRate ? rate.TotalPrice : hourlyRate.GetTotalPrice(entryDateTime, exitDateTime);
                Console.WriteLine();
                Console.WriteLine("Rate name : {0}", rate.Name);
                Console.WriteLine("Total price : {0}", totalPrice);
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private static DateTime GetDate(string dateType)
        {
            string[] formats = { "dd/MM/yy HH:mm:ss" };

            Console.WriteLine("Please enter {0} date and time (dd/MM/yy HH:mm:ss)", dateType);
            DateTime dateTime;
            while (!DateTime.TryParseExact(Console.ReadLine(), formats, new CultureInfo("en-US"),
                                    DateTimeStyles.None, out dateTime))
            {
                Console.WriteLine("You have entered an incorrect date.");
                Console.WriteLine("Please enter {0} date and time (dd/mm/yy hh:mm:ss)", dateType);
                Console.ReadLine();
            }
            return dateTime;
        }
    }
}
