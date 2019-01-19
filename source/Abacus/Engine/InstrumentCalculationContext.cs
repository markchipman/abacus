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

        public IEnumerable<MarketDataRequirement> GetRequirements(IMeasuresCalculator calculator, DateTime valuationDate, params Measure[] measureTypes)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }
            if (measureTypes == null)
            {
                throw new ArgumentNullException(nameof(measureTypes));
            }

            return calculator.GetRequirements(Instrument, valuationDate, measureTypes);
        }

        public IEnumerable<MeasureResult> CalculateMeasures(IMeasuresCalculator calculator, DateTime valuationDate, IMarketData marketData, params Measure[] measureTypes)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }
            if (measureTypes == null)
            {
                throw new ArgumentNullException(nameof(measureTypes));
            }

            return calculator.CalculateMeasures(Instrument, valuationDate, marketData, measureTypes);
        }
    }
}
