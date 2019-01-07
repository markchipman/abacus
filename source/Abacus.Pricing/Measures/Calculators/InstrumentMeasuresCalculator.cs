using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Abacus.Pricing.Data;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures.Calculators
{

    public abstract class InstrumentMeasuresCalculator<TInstrument> where TInstrument : Instrument
    {
        public InstrumentMeasuresCalculator(params InstrumentMeasureCalculator<TInstrument>[] measureCalculators)
        {
            if (measureCalculators == null)
            {
                throw new ArgumentNullException(nameof(measureCalculators));
            }

            MeasureCalculators = new Dictionary<Measure, InstrumentMeasureCalculator<TInstrument>>(measureCalculators.ToDictionary(x => x.Measure));
        }

        public InstrumentMeasuresCalculator(IDictionary<Measure, InstrumentMeasureCalculator<TInstrument>> measureCalculators)
        {
            if (measureCalculators == null)
            {
                throw new ArgumentNullException(nameof(measureCalculators));
            }

            MeasureCalculators = new Dictionary<Measure, InstrumentMeasureCalculator<TInstrument>>(measureCalculators);
        }

        public Type InstrumentType => typeof(TInstrument);

        public IReadOnlyList<Measure> Measures { get; }

        protected IReadOnlyDictionary<Measure, InstrumentMeasureCalculator<TInstrument>> MeasureCalculators { get; }

        public abstract object CalculateMeasures(DateTime valuationDate, MarketData marketData, TInstrument instrument, params Measure[] measures);
    }
}
