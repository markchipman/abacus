using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Pricers;

namespace Abacus.Measures.Calculators
{
    public class FixedCouponBondFutureValueCalculator : MeasureCalculator<FixedCouponBond>, IFixedCouponBondFutureValueCalculator
    {
        public static readonly IFixedCouponBondFutureValueCalculator Instance = new FixedCouponBondFutureValueCalculator();

        private readonly IFixedCouponBondPricer _pricer;

        static FixedCouponBondFutureValueCalculator()
        {
        }

        public FixedCouponBondFutureValueCalculator()
            : this(FixedCouponBondPricer.Instance)
        {
        }

        public FixedCouponBondFutureValueCalculator(IFixedCouponBondPricer pricer)
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

            var result = _pricer.FutureValue(valuationDate, target);

            return new MeasureResult(StandardMeasures.FutureValue, result);
        }
    }
}
