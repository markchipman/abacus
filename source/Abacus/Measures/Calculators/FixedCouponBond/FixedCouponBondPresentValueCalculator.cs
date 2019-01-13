using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Pricers;

namespace Abacus.Measures.Calculators
{
    public class FixedCouponBondPresentValueCalculator : IPresentValueCalculator<FixedCouponBond>
    {
        public static readonly IPresentValueCalculator<FixedCouponBond> Instance = new FixedCouponBondPresentValueCalculator();

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

        public IEnumerable<MarketDataRequirement> GetRequirements(FixedCouponBond target, DateTime valuationDate)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            yield return new MarketDataRequirement();
        }

        public MeasureResult CalculateMeasure(FixedCouponBond target, DateTime valuationDate, IMarketData marketData)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }

            var discountFactors = marketData.GetMarketDataOrDefault<DiscountFactors>(null, new DiscountFactors(valuationDate, new DayCountConvention(), new Curve()));
            var result = _pricer.PresentValue(target, valuationDate, discountFactors);

            return new MeasureResult(StandardMeasures.PresentValue, result);
        }
    }
}
