﻿namespace FestivalManager.Entities.Instruments
{
    public class Drums : Instrument
    {
        private const int defaultRepairAmount = 20;

        protected override int RepairAmount => defaultRepairAmount;
    }
}
