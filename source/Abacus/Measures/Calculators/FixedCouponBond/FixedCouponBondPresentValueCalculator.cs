using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain.Core;
using Abacus.Domain.Instruments;
using Abacus.Pricers;

namespace Abacus.Measures.Calculators
{
    public class FixedCouponBondPresentValueCalculator : MeasureCalculator<FixedCouponBond>, IFixedCouponBondPresentValueCalculator
    {
        private readonly IFixedCouponBondPricer _pricer;

        public FixedCouponBondPresentValueCalculator()
            : this(FixedCouponBondPricer.Instance)
        {
        }

        public FixedCouponBondPresentValueCalculator(IFixedCouponBondPricer pricer)
        {
            if (pricer == null)
            {
                throw new ArgumentNullException(nameof(pricer));
            }

            _pricer = pricer;
        }

        public override IEnumerable<MarketDataRequirement> GetRequirements(DateTime valuationDate, FixedCouponBond target)
        {
            yield return new MarketDataRequirement();
        }

        public override MeasureResult CalculateMeasure(DateTime valuationDate, IMarketData marketData, FixedCouponBond target)
        {
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }

            var discountFactors = marketData.GetMarketDataOrDefault<DiscountFactors>(null, new DiscountFactors(valuationDate, new DayCountConvention(), new Curve()));
            var result = _pricer.PresentValue(valuationDate, target, discountFactors);
            return new MeasureResult(StandardMeasures.PresentValue, result);
        }
    }
}
