using Abacus.Pricing.Data;
using Abacus.Pricing.Measures;
using Abacus.Pricing.Models;
using Abacus.Pricing.Calculators;

namespace Abacus.UnitTests {
    public class UnitTest1 {
        [Fact]
        public void Test1() {
            var valuationDate = DateTime.UtcNow;
            var marketData = new MarketData();
            var instrument = new FixedCouponBond();
            var measuresCalculator = new FixedCouponBondMeasuresCalculator(null);

            var measureRegistrar = new MeasureCalculatorRegistrar();
            measureRegistrar.Register<FixedCouponBond, PresentValue, FixedCouponBondPresentValueCalculator>();

            measuresCalculator.CalculateMeasures(valuationDate, marketData, instrument, StandardMeasures.PresentValue);

            Assert.True(true);
        }
    }
}
