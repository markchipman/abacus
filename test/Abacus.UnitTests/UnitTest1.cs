using System;
using Xunit;
using Abacus.Pricing.Measures;
using Abacus.Pricing.Models;

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

            measuresCalculator.CalculateMeasures(valuationDate, marketData, instrument, StandardMeasure.PresentValue);

            Assert.True(true);
        }
    }
}
