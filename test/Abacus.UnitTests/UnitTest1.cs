using System;
using Abacus.Pricing.Calculators;
using Abacus.Pricing.Data;
using Abacus.Pricing.Measures;
using Abacus.Pricing.Models;
using Xunit;

namespace Abacus.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var valuationDate = DateTime.UtcNow;
            var marketData = new MarketData();
            var bond = new FixedCouponBond();

            var measureRegistrar = new MeasureCalculatorRegistrar();
            measureRegistrar.Register<FixedCouponBond, PresentValue, FixedCouponBondPresentValueCalculator>();

            var measuresCalculator = new MeasuresCalculator(measureRegistrar);
            measuresCalculator.CalculateMeasures(valuationDate, marketData, bond, StandardMeasures.PresentValue);

            Assert.True(true);
        }
    }
}
