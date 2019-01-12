using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Pricers;

namespace Abacus.Measures.Calculators
{
    public class FixedCouponBondPresentValueCalculator : MeasureCalculator<FixedCouponBond>, IFixedCouponBondPresentValueCalculator
    {
        public static readonly IFixedCouponBondPresentValueCalculator Instance = new FixedCouponBondPresentValueCalculator();

        private readonly IFixedCouponBondPricer _pricer;

        static FixedCouponBondPresentValueCalculator()
        {
        }

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
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            yield return new MarketDataRequirement();
        }

        public override MeasureResult CalculateMeasure(DateTime valuationDate, IMarketData marketData, FixedCouponBond target)
        {
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var discountFactors = marketData.GetMarketDataOrDefault<DiscountFactors>(null, new DiscountFactors(valuationDate, new DayCountConvention(), new Curve()));
            var result = _pricer.PresentValue(valuationDate, target, discountFactors);

            return new MeasureResult(StandardMeasures.PresentValue, result);
        }
    }
}
