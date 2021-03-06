﻿using System;

namespace CarparkCalculation.BusinessLayer
{
    public interface IEarlyBirdConditions : IFlatRateConditions
    {
        bool MeetAllConditions(DateTime entryDateTime, DateTime exitDateTime);
    }
}
