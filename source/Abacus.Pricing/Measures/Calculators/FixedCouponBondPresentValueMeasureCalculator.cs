using System;
using Abacus.Pricing.Data;
using Abacus.Pricing.Models;
using Abacus.Pricing.Pricers;

namespace Abacus.Pricing.Measures.Calculators
{
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
