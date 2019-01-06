using System;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures
{
    public interface IInstrumentMeasuresCalculator<TInstrument> where TInstrument : Instrument
    {
        object CalculateMeasures(DateTime valuationDate, TInstrument instrument, params Measure[] measures);
    }
}
