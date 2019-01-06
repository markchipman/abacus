using System;
using System.Collections.Generic;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures
{
    public class FixedCouponBondMeasuresCalculator : IInstrumentMeasuresCalculator<FixedCouponBond>
    {
        private readonly IDictionary<Measure, IInstrumentMeasureCalculator<FixedCouponBond>> measureCalculators = new Dictionary<Measure, IInstrumentMeasureCalculator<FixedCouponBond>>();

        public object CalculateMeasures(DateTime valuationDate, FixedCouponBond instrument, params Measure[] measures)
        {
            throw new NotImplementedException();
        }
    }

    public interface IInstrumentMeasureCalculator<TInstrument>
    {
        object CalculateMeasure(DateTime valuationDate, TInstrument instrument);
    }
}
