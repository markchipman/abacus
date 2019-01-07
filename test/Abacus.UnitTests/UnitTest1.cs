using System;
using Xunit;
using Abacus.Pricing.Data;
using Abacus.Pricing.Measures;
using Abacus.Pricing.Models;
using Abacus.Pricing.Measures.Calculators;

namespace Abacus.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var valuationDate = DateTime.UtcNow;
            var marketData = new MarketData();
            var instrument = new FixedCouponBond();
            var measuresCalculator = new FixedCouponBondMeasuresCalculator(null);

            measuresCalculator.CalculateMeasures(valuationDate, marketData, instrument, StandardMeasures.PresentValue);

            Assert.True(true);
        }
    }
}
