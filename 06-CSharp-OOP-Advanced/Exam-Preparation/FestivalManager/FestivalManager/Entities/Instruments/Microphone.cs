namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int defaultRepairAmount = 80;

	    protected override int RepairAmount => defaultRepairAmount;
    }
}
