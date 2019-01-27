using System;
using System.Linq;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Engine;
using Abacus.Measures;
using Abacus.Measures.Calculation;
using Abacus.Measures.Calculators;
using Abacus.Measures.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Abacus.WebApi.Controllers
{
    [ApiController]
    [Route("api/calculate")]
    public class CalculationController : ControllerBase
    {
        [HttpGet("measureTypes")]
        public IActionResult CalculateMeasures()
        {
            // done outside of controller:
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient(typeof(PricingModelAsMeasureResult<>), typeof(PricingModelAsMeasureResult<>));
            var calculatorRegistrar = new MeasureCalculationRegistrar()
                .RegisterInstance(StandardMeasure.PricingModel, PricingModelAsMeasureResult<FixedCouponBond>.Instance)
                .RegisterInstance(StandardMeasure.PresentValue, FixedCouponBondPresentValueCalculator.Instance)
                .RegisterInstance(StandardMeasure.FutureValue, FixedCouponBondFutureValueCalculator.Instance);
            var calculator = new MeasuresCalculator(calculatorRegistrar);
            var marketData = new MarketData(); // created using market data requirements

            // resolved models from DTOs:
            var tradeStartDate = new DateTime(2018, 01, 01);
            var valuationDate = DateTime.Now;
            var instruments = new Instrument[]
            {
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(1_000_000m, new Currency("GBP")), new Rate(0.00_1m, StandardFrequency._Annually), new ScheduleInfo(tradeStartDate, tradeStartDate.AddYears(2), StandardFrequency._Monthly, StandardDayRollConvention._IMM)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(20_000_000m, new Currency("GBP")), new Rate(0.00_2m, StandardFrequency._Annually), new ScheduleInfo(tradeStartDate, tradeStartDate.AddYears(5), StandardFrequency._Quarterly)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(500_000_000m, new Currency("GBP")), new Rate(0.00_25m, StandardFrequency._Annually), new ScheduleInfo(tradeStartDate, tradeStartDate.AddYears(10), StandardFrequency._SemiAnnually)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(1_000_000_000m, new Currency("GBP")), new Rate(0.00_02m, StandardFrequency._Annually), new ScheduleInfo(valuationDate, valuationDate.AddMonths(6), StandardFrequency._Weekly))
            };
            var measureTypes = new Measure[]
            {
                StandardMeasure.PricingModel,
                StandardMeasure.PresentValue,
                StandardMeasure.FutureValue
            };

            // done in engine, called by service/controller:
            var calculationContext = new InstrumentsCalculationContext(instruments);
            var requirements = calculationContext.GetRequirements(calculator, valuationDate, measureTypes).ToList();
            var results = calculationContext.CalculateMeasures(calculator, valuationDate, marketData, measureTypes).ToList();

            // TODO
            return Ok(results);
        }
    }
}
