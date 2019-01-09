using Abacus.Pricing.Data;
using Abacus.Pricing.Measures;
using System;

namespace Abacus.Pricing.Calculators
{
    public abstract class MeasureCalculator<TTarget, TMeasure> : MeasureCalculator<TTarget> where TMeasure : Measure
    {
    }

    public abstract class MeasureCalculator<TTarget>
    {
        public abstract object CalculateMeasure(DateTime valuationDate, MarketData marketData, TTarget target);
    }
}
