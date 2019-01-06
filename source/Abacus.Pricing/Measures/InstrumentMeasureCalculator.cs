using System;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures
{
    public abstract class InstrumentMeasureCalculator<TInstrument, TMeasure> : InstrumentMeasureCalculator<TInstrument> where TInstrument : Instrument where TMeasure : Measure
    {
        public override Type MeasureType => typeof(TMeasure);
    }

    public abstract class InstrumentMeasureCalculator<TInstrument> where TInstrument : Instrument
    {
        public Type InstrumentType => typeof(TInstrument);

        public abstract Type MeasureType { get; }

        public abstract object CalculateMeasure(DateTime valuationDate, TInstrument instrument);
    }
}
