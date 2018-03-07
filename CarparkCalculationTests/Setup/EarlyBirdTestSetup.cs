using System;
using System.Collections.Generic;

namespace CarparkCalculationTests.Setup
{
    public class EarlyBirdTestSetup
    {
        public static readonly IEnumerable<object[]> MeetEntryConditionDates = new List<object[]>
        {
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0)},
            new object[]{new DateTime(2018, 03, 05, 7, 0, 0)},
            new object[]{new DateTime(2018, 03, 05, 9, 0, 0)},
            new object[]{new DateTime(2018, 03, 05, 8, 30, 0)},
        };

        public static readonly IEnumerable<object[]> DoesNotMeetEntryConditionDates = new List<object[]>
        {
            new object[]{new DateTime(2018, 03, 05, 5, 0, 0)},
            new object[]{new DateTime(2018, 03, 05, 11, 0, 0)},
            new object[]{new DateTime(2018, 03, 05, 5, 30, 0)},
        };

        public static readonly List<object[]> MeetExitConditionDates = new List<object[]>
        {
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 05, 16, 0, 0)},
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 05, 15, 30, 0)},
            new object[]{new DateTime(2018, 03, 05, 11, 0, 0), new DateTime(2018, 03, 05, 23, 30, 0)}
        };

        public static readonly List<object[]> DoesNotMeetExitConditionDates = new List<object[]>
        {
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 05, 15, 0, 0)},
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 05, 15, 29, 59)},
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 06, 15, 30, 0)}
        };

        public static readonly List<object[]> InvalidExitConditionDates = new List<object[]>
        {
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 04, 15, 30, 0)},
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 05, 05, 0, 0)}
        };

        public static readonly List<object[]> MeetEntryExitConditionDates = new List<object[]>
        {
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 05, 16, 0, 0)},
            new object[]{new DateTime(2018, 03, 05, 7, 0, 0), new DateTime(2018, 03, 05, 15, 30, 0)},
            new object[]{new DateTime(2018, 03, 05, 6, 0, 0), new DateTime(2018, 03, 05, 23, 30, 0)}
        };
    }
}
