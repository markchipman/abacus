using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures
{
    public abstract class InstrumentMeasuresCalculator<TInstrument> where TInstrument : Instrument
    {
        public InstrumentMeasuresCalculator(IDictionary<Measure, InstrumentMeasureCalculator<TInstrument>> measureCalculators)
        {
            if (measureCalculators == null)
            {
                throw new ArgumentNullException(nameof(measureCalculators));
            }

            MeasureCalculators = new ReadOnlyDictionary<Measure, InstrumentMeasureCalculator<TInstrument>>(measureCalculators);
        }
        public Type InstrumentType => typeof(TInstrument);

        public IReadOnlyList<Measure> Measures { get; }

        protected IReadOnlyDictionary<Measure, InstrumentMeasureCalculator<TInstrument>> MeasureCalculators { get; }

        public abstract object CalculateMeasures(DateTime valuationDate, TInstrument instrument, params Measure[] measures);
    }
}
