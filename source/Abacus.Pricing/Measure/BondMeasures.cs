using System;
using System.Collections.Generic;
using Abacus.Pricing.Models;
using Abacus.Pricing.Pricer;

namespace Abacus.Pricing.Measure
{
    public interface IMarketData
    {
        T Get<T>();
    }

    public class FixedCouponBondMeasures : ICalculateMeasure<FixedCouponBond, PresentValue>
    {
        private readonly FixedCouponBondPricer pricer;

        public FixedCouponBondMeasures(FixedCouponBondPricer pricer)
        {
            this.pricer = pricer ?? throw new ArgumentNullException(nameof(pricer));
        }

        IList<MarketDataRequirement> ICalculateMeasure<FixedCouponBond, PresentValue>.Requirements(DateTime valuationDate, FixedCouponBond instrument)
        {
            throw new NotImplementedException();
        }

        PresentValue ICalculateMeasure<FixedCouponBond, PresentValue>.Calculate(DateTime valuationDate, IMarketData marketData, FixedCouponBond instrument)
        {
            var discountFactors = marketData.Get<DiscountFactors>();
            var result = pricer.PresentValue(valuationDate, instrument, discountFactors);
            return new PresentValue(result);
        }
    }

    public interface ICalculateMeasure<TInstrument, TMeasure> where TInstrument : Instrument where TMeasure : Measure
    {
        IList<MarketDataRequirement> Requirements(DateTime valuationDate, TInstrument instrument);

        TMeasure Calculate(DateTime valuationDate, IMarketData marketData, TInstrument instrument);
    }

    public class PresentValue : Measure
    {
        public PresentValue(CurrencyAmount value)
        {
            Value = value;
        }

        public CurrencyAmount Value { get; }
    }

    public class ForecaseValue : Measure
    {
        public ForecaseValue(CurrencyAmount value)
        {
            Value = value;
        }

        public CurrencyAmount Value { get; }
    }

    public class Measure
    {
    }

    public class MarketDataRequirement
    {
    }
}
