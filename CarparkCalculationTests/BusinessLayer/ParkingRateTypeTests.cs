using System;
using CarparkCalculation.BusinessLayer;
using Moq;
using Xunit;

namespace CarparkCalculationTests.BusinessLayer
{
    public class ParkingRateTypeTests
    {
        [Fact]
        public void GetParkingRateName_NightRateNotWeekendNotEarlyBird_ReturnsNightRate()
        {
            //arrange
            var entryDateTime = new DateTime(2018, 03, 05, 18, 0, 0);
            var exitDateTime = new DateTime(2018, 03, 05, 22, 0, 0);

            var mockNightRateConditions = new Mock<INightRateConditions>();
            var mockWeekendRateConditions = new Mock<IWeekendRateConditions>();
            var mockEarlyBirdConditions = new Mock<IEarlyBirdConditions>();

            mockNightRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(true);
            mockWeekendRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            mockEarlyBirdConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);

            var parkingRateType = new ParkingRateType(mockNightRateConditions.Object, mockWeekendRateConditions.Object, mockEarlyBirdConditions.Object);

            //act
            var rateName = parkingRateType.GetParkingRateName(entryDateTime, exitDateTime);

            //assert
            Assert.Equal(rateName.ToString(), RateName.Night.ToString());
        }

        [Fact]
        public void GetParkingRateName_WeekendNotNightRateNotEarlyBird_ReturnsWeekendRate()
        {
            //arrange
            var entryDateTime = new DateTime(2018, 03, 05, 18, 0, 0);
            var exitDateTime = new DateTime(2018, 03, 05, 22, 0, 0);

            var mockNightRateConditions = new Mock<INightRateConditions>();
            var mockWeekendRateConditions = new Mock<IWeekendRateConditions>();
            var mockEarlyBirdConditions = new Mock<IEarlyBirdConditions>();

            mockNightRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            mockWeekendRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(true);
            mockEarlyBirdConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);

            var parkingRateType = new ParkingRateType(mockNightRateConditions.Object, mockWeekendRateConditions.Object, mockEarlyBirdConditions.Object);

            //act
            var rateName = parkingRateType.GetParkingRateName(entryDateTime, exitDateTime);

            //assert
            Assert.Equal(rateName.ToString(), RateName.Weekend.ToString());
        }

        [Fact]
        public void GetParkingRateName_EarlyBirdNotWeekendNotNightRate_ReturnsEarlyBird()
        {
            //arrange
            var entryDateTime = new DateTime(2018, 03, 05, 18, 0, 0);
            var exitDateTime = new DateTime(2018, 03, 05, 22, 0, 0);

            var mockNightRateConditions = new Mock<INightRateConditions>();
            var mockWeekendRateConditions = new Mock<IWeekendRateConditions>();
            var mockEarlyBirdConditions = new Mock<IEarlyBirdConditions>();

            mockNightRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            mockWeekendRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            mockEarlyBirdConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(true);
            var parkingRateType = new ParkingRateType(mockNightRateConditions.Object, mockWeekendRateConditions.Object, mockEarlyBirdConditions.Object);

            //act
            var rateName = parkingRateType.GetParkingRateName(entryDateTime, exitDateTime);

            //assert
            Assert.Equal(rateName.ToString(), RateName.EarlyBird.ToString());
        }

        [Fact]
        public void GetParkingRateName_NotEarlyBirdNotWeekendNotNightRate_ReturnsStandard()
        {
            //arrange
            var entryDateTime = new DateTime(2018, 03, 05, 18, 0, 0);
            var exitDateTime = new DateTime(2018, 03, 05, 22, 0, 0);

            var mockNightRateConditions = new Mock<INightRateConditions>();
            var mockWeekendRateConditions = new Mock<IWeekendRateConditions>();
            var mockEarlyBirdConditions = new Mock<IEarlyBirdConditions>();

            mockNightRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            mockWeekendRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            mockEarlyBirdConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            var parkingRateType = new ParkingRateType(mockNightRateConditions.Object, mockWeekendRateConditions.Object, mockEarlyBirdConditions.Object);

            //act
            var rateName = parkingRateType.GetParkingRateName(entryDateTime, exitDateTime);

            //assert
            Assert.Equal(rateName.ToString(), RateName.Standard.ToString());
        }

        [Fact]
        public void GetParkingRateName_InvalidDate_ThrowsException()
        {
            //arrange
            var entryDateTime = new DateTime(2018, 03, 05, 18, 0, 0);
            var exitDateTime = new DateTime(2018, 03, 04, 22, 0, 0);

            var mockNightRateConditions = new Mock<INightRateConditions>();
            var mockWeekendRateConditions = new Mock<IWeekendRateConditions>();
            var mockEarlyBirdConditions = new Mock<IEarlyBirdConditions>();

            mockNightRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            mockWeekendRateConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(false);
            mockEarlyBirdConditions.Setup(x => x.MeetAllConditions(entryDateTime, exitDateTime)).Returns(true);

            var parkingRateType = new ParkingRateType(mockNightRateConditions.Object, mockWeekendRateConditions.Object, mockEarlyBirdConditions.Object);

            //act
            //assert
            Assert.Throws<Exception>(() => parkingRateType.GetParkingRateName(entryDateTime, exitDateTime));
        }
    }
}
