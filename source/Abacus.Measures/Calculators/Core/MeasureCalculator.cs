using System;
using Abacus.Data.MarketData;

namespace Abacus.Measures
{
    public abstract class MeasureCalculator<TTarget, TMeasure> : MeasureCalculator<TTarget> where TMeasure : Measure
    {
    }

    public abstract class MeasureCalculator<TTarget>
    {
        public abstract object CalculateMeasure(DateTime valuationDate, IMarketData marketData, TTarget target);
    }
}
