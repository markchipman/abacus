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
            var instrument = new FixedCouponBond();
            var measureCalculator = new FixedCouponBondMeasureCalculator();

            measureCalculator.CalculateMeasures(valuationDate, instrument, Measure.PresentValue);

            Assert.True(true);
        }
    }
}
