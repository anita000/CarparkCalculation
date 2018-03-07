using System;
using Xunit;
using CarparkCalculationTests.Setup;
using CarparkCalculation.BusinessLayer;

namespace CarparkCalculationTests.BusinessLayer
{
    public class EarlyBirdConditionsTests
    {
        [Theory]
        [MemberData(nameof(EarlyBirdTestSetup.MeetEntryConditionDates), MemberType = typeof(EarlyBirdTestSetup))]
        public void MeetEntryCondition_TimeWithinTimeLimit_ReturnsTrue(DateTime entryDateTime)
        {
            var earlyBirdConditions = new EarlyBirdConditions();
            var result = earlyBirdConditions.MeetEntryCondition(entryDateTime);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(EarlyBirdTestSetup.DoesNotMeetEntryConditionDates), MemberType = typeof(EarlyBirdTestSetup))]
        public void MeetEntryCondition_TimeNotWithinTimeLimit_ReturnsFalse(DateTime entryDateTime)
        {
            var earlyBirdConditions = new EarlyBirdConditions();
            var result = earlyBirdConditions.MeetEntryCondition(entryDateTime);

            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(EarlyBirdTestSetup.MeetExitConditionDates), MemberType = typeof(EarlyBirdTestSetup))]
        public void MeetExitCondition_TimeWithinTimeLimit_ReturnsTrue(DateTime entryDateTime, DateTime exitDateTime)
        {
            var earlyBirdConditions = new EarlyBirdConditions();
            var result = earlyBirdConditions.MeetExitCondition(entryDateTime, exitDateTime);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(EarlyBirdTestSetup.DoesNotMeetExitConditionDates), MemberType = typeof(EarlyBirdTestSetup))]
        public void MeetExitCondition_TimeNotWithinTimeLimit_ReturnsFalse(DateTime entryDateTime, DateTime exitDateTime)
        {
            var earlyBirdConditions = new EarlyBirdConditions();
            var result = earlyBirdConditions.MeetExitCondition(entryDateTime, exitDateTime);

            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(EarlyBirdTestSetup.InvalidExitConditionDates), MemberType = typeof(EarlyBirdTestSetup))]
        public void MeetExitCondition_InvalidDate_ThrowsException(DateTime entryDateTime, DateTime exitDateTime)
        {
            var earlyBirdConditions = new EarlyBirdConditions();

            Assert.Throws<Exception>(() => earlyBirdConditions.MeetExitCondition(entryDateTime, exitDateTime));
        }

        [Theory]
        [MemberData(nameof(EarlyBirdTestSetup.MeetEntryExitConditionDates), MemberType = typeof(EarlyBirdTestSetup))]
        public void MeetAllConditions_TimeWithinTimeLimit_ReturnsTrue(DateTime entryDateTime, DateTime exitDateTime)
        {
            var earlyBirdConditions = new EarlyBirdConditions();
            var result = earlyBirdConditions.MeetAllConditions(entryDateTime, exitDateTime);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(EarlyBirdTestSetup.DoesNotMeetExitConditionDates), MemberType = typeof(EarlyBirdTestSetup))]
        public void MeetAllConditions_TimeNotWithinTimeLimit_ReturnsFalse(DateTime entryDateTime, DateTime exitDateTime)
        {
            var earlyBirdConditions = new EarlyBirdConditions();
            var result = earlyBirdConditions.MeetAllConditions(entryDateTime, exitDateTime);

            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(EarlyBirdTestSetup.InvalidExitConditionDates), MemberType = typeof(EarlyBirdTestSetup))]
        public void MeetAllConditions_InvalidDate_ThrowsException(DateTime entryDateTime, DateTime exitDateTime)
        {
            var earlyBirdConditions = new EarlyBirdConditions();

            Assert.Throws<Exception>(() => earlyBirdConditions.MeetAllConditions(entryDateTime, exitDateTime));
        }
    }
}
