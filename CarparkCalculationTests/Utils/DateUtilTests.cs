using System;
using Xunit;
using CarparkCalculation.Utils;

namespace CarparkCalculationTests.Utils
{
    public class DateUtilTests
    {
        [Fact]
        public void IsWeekend_GivenSaturday_ReturnsTrue()
        {
            //Saturday
            var date = new DateTime(2018, 03, 10, 6, 0, 0);

            var isWeekend = DateUtil.IsWeekend(date);

            Assert.True(isWeekend);
        }

        [Fact]
        public void IsWeekend_GivenMonday_ReturnsFalse()
        {
            //Saturday
            var date = new DateTime(2018, 03, 05, 6, 0, 0);

            var isWeekend = DateUtil.IsWeekend(date);
            
            Assert.False(isWeekend);
        }
    }
}
