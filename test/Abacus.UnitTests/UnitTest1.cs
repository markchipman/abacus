using System;
using Xunit;
using Abacus.Pricing.Measure;
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
            var measureCalculator = new MeasureCalculationService();

            measureCalculator.CalculateMeasures(valuationDate, instrument, Measure.PresentValue);

            Assert.True(true);
        }
    }
}
