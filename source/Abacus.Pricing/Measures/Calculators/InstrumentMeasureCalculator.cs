using System;
using Abacus.Pricing.Data;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures.Calculators
{
    public abstract class InstrumentMeasureCalculator<TInstrument, TMeasure> : InstrumentMeasureCalculator<TInstrument> where TInstrument : Instrument where TMeasure : Measure, new()
    {
        public override Measure Measure => new TMeasure();
    }

    public abstract class InstrumentMeasureCalculator<TInstrument> where TInstrument : Instrument
    {
        public abstract Measure Measure { get; }

        public abstract object CalculateMeasure(DateTime valuationDate, MarketData marketData, TInstrument instrument);
    }
}
