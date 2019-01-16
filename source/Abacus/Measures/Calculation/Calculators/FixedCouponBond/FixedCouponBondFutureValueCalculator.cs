using System;
using System.Collections.Generic;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Pricers;

namespace Abacus.Measures.Calculators
{
    public class FixedCouponBondFutureValueCalculator : IMeasureCalculator<FixedCouponBond>
    {
        public static readonly IMeasureCalculator<FixedCouponBond> Instance = new FixedCouponBondFutureValueCalculator();

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

            var result = _pricer.FutureValue(target, valuationDate);

            return new MeasureResult(StandardMeasures.FutureValue, result);
        }
    }
}
