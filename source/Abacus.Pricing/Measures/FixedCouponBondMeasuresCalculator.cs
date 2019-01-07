using System;
using System.Collections.Generic;
using Abacus.Pricing.Models;
using Abacus.Pricing.Pricer;

namespace Abacus.Pricing.Measures
{
    public class FixedCouponBondMeasuresCalculator : InstrumentMeasuresCalculator<FixedCouponBond>
    {
        public FixedCouponBondMeasuresCalculator(InstrumentMeasureCalculator<FixedCouponBond, PresentValue> presentValueCalculator)
            : base(presentValueCalculator)
        {
        }

        public override object CalculateMeasures(DateTime valuationDate, MarketData marketData, FixedCouponBond instrument, params Measure[] measures)
        {
            throw new NotImplementedException();
        }
    }

    public class FixedCouponBondPresentValueMeasureCalculator : InstrumentMeasureCalculator<FixedCouponBond, PresentValue>
    {
        private readonly FixedCouponBondPricer pricer;

        public FixedCouponBondPresentValueMeasureCalculator(FixedCouponBondPricer pricer)
        {
            this.pricer = pricer ?? throw new ArgumentNullException(nameof(pricer));
        }

        public override object CalculateMeasure(DateTime valuationDate, MarketData marketData, FixedCouponBond instrument)
        {
            var discountFactors = marketData.GetMarketData<DiscountFactors>();
            return pricer.PresentValue(valuationDate, instrument, discountFactors);
        }
    }
}
