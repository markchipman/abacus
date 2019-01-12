﻿using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain.Core;
using Abacus.Measures;
using Abacus.Measures.Calculation;

namespace Abacus.Engine
{
    public class InstrumentCalculationContext<TTarget> : CalculationContext where TTarget : Instrument
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

        public override IEnumerable<MarketDataRequirement> GetRequirements(MeasuresCalculator calculator, DateTime valuationDate, params MeasureType[] measures)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }
            if (measures == null)
            {
                throw new ArgumentNullException(nameof(measures));
            }

            return calculator.GetRequirements(valuationDate, Instrument, measures);
        }

        public override IEnumerable<MeasureResult> CalculateMeasures(MeasuresCalculator calculator, DateTime valuationDate, IMarketData marketData, params MeasureType[] measures)
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

            return calculator.CalculateMeasures(valuationDate, marketData, Instrument, measures);
        }
    }
}