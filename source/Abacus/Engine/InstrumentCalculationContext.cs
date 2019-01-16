using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Measures;
using Abacus.Measures.Calculation;

namespace Abacus.Engine
{
    public class InstrumentCalculationContext<TTarget> : ICalculationContext where TTarget : Instrument
    {
        public InstrumentCalculationContext(TTarget instrument)
        {
            if (instrument == null)
            {
                throw new ArgumentNullException(nameof(instrument));
            }

            Instrument = instrument;
        }

        public TTarget Instrument { get; }

        public IEnumerable<MarketDataRequirement> GetRequirements(MeasuresCalculator calculator, DateTime valuationDate, params MeasureType[] measures)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }
            if (measures == null)
            {
                throw new ArgumentNullException(nameof(measures));
            }

            return calculator.GetRequirements(Instrument, valuationDate, measures);
        }

        public IEnumerable<MeasureResult> CalculateMeasures(MeasuresCalculator calculator, DateTime valuationDate, IMarketData marketData, params MeasureType[] measures)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }
            if (measures == null)
            {
                throw new ArgumentNullException(nameof(measures));
            }

            return calculator.CalculateMeasures(Instrument, valuationDate, marketData, measures);
        }
    }
}
