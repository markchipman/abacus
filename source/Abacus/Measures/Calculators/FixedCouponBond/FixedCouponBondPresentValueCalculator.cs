﻿using System;
using Abacus.Data.MarketData;
using Abacus.Domain.Core;
using Abacus.Domain.Instruments;
using Abacus.Pricers;

namespace Abacus.Measures.Calculators
{
    public class FixedCouponBondPresentValueCalculator : MeasureCalculator<FixedCouponBond, PresentValue>
    {
        private readonly FixedCouponBondPricer pricer;

        public FixedCouponBondPresentValueCalculator(FixedCouponBondPricer _pricer)
        {
            if (_pricer == null)
            {
                throw new ArgumentNullException(nameof(_pricer));
            }

            this.pricer = _pricer;
        }

        public override object MarketDataRequirements(DateTime valuationDate, FixedCouponBond target)
        {
            throw new NotImplementedException();
        }

        public override object CalculateMeasure(DateTime valuationDate, IMarketData marketData, FixedCouponBond target)
        {
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }

            var discountFactors = marketData.GetMarketData<DiscountFactors>(null);
            return pricer.PresentValue(valuationDate, target, discountFactors);
        }
    }
}
