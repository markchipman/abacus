using System;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Pricing;

namespace Abacus.Measures.Calculators
{
    public class FixedCouponBondPresentValueCalculator : MeasureCalculator<FixedCouponBond, PresentValue>
    {
        private readonly FixedCouponBondPricer pricer;

        public FixedCouponBondPresentValueCalculator(FixedCouponBondPricer pricer)
        {
            this.pricer = pricer ?? throw new ArgumentNullException(nameof(pricer));
        }

        public override object CalculateMeasure(DateTime valuationDate, IMarketData marketData, FixedCouponBond target)
        {
            var discountFactors = marketData.GetMarketData<DiscountFactors>();
            return pricer.PresentValue(valuationDate, target, discountFactors);
        }
    }
}
