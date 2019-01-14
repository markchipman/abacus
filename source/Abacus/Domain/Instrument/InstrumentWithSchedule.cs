namespace Abacus.Domain
{
    public abstract class InstrumentWithSchedule<TPeriod> : Instrument where TPeriod : Period
    {
        public abstract Schedule<TPeriod> Schedule { get; }
    }
}
