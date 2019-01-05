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

    public class FixedCouponBondPresentValueMeasureCalculator : IMeasureCalculator<FixedCouponBond, PresentValue>
    {
        private readonly FixedCouponBondPricer pricer;

        public FixedCouponBondPresentValueMeasureCalculator(FixedCouponBondPricer pricer)
        {
            this.pricer = pricer ?? throw new ArgumentNullException(nameof(pricer));
        }

        public IList<MarketDataRequirement> Requirements(DateTime valuationDate, FixedCouponBond instrument)
        {
            throw new NotImplementedException();
        }

        public PresentValue Calculate(DateTime valuationDate, IMarketData marketData, FixedCouponBond instrument)
        {
            var discountFactors = marketData.Get<DiscountFactors>();
            var result = pricer.PresentValue(valuationDate, instrument, discountFactors);
            return new PresentValue(result);
        }
    }

    public interface IMeasureCalculator<TInstrument, TMeasure> where TInstrument : Instrument where TMeasure : Measure
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

    public class Measure
    {
    }

    public class MarketDataRequirement
    {
    }
}
