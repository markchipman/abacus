using System;
using Abacus.Pricing.Data;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures.Calculators
{
    public abstract class MeasureCalculator<TTarget, TMeasure> : MeasureCalculator<TTarget> where TMeasure : Measure, new()
    {
        public override Measure Measure => new TMeasure();
    }

    public abstract class MeasureCalculator<TTarget>
    {
        public abstract Measure Measure { get; }

        public abstract object CalculateMeasure(DateTime valuationDate, MarketData marketData, TTarget target);
    }
}
