namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int defaultRepairAmount = 60;

        protected override int RepairAmount => defaultRepairAmount;
    }
}
