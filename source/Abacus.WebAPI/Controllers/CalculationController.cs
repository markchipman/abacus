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
    [Route("api/calculate")]
    [ApiController]
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
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(1_000_000m, new Currency("GBP")), new Rate(0.00_1m, Frequency_Annual.Instance), new ScheduleInfo(tradeStartDate, tradeStartDate.AddYears(2), Frequency_Monthly.Instance, RollConvention_IMM.Instance)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(20_000_000m, new Currency("GBP")), new Rate(0.00_2m, Frequency_Annual.Instance), new ScheduleInfo(tradeStartDate, tradeStartDate.AddYears(5), Frequency_Quarterly.Instance)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(500_000_000m, new Currency("GBP")), new Rate(0.00_25m, Frequency_Annual.Instance), new ScheduleInfo(tradeStartDate, tradeStartDate.AddYears(10), Frequency_SemiAnnual.Instance)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(1_000_000_000m, new Currency("GBP")), new Rate(0.00_02m, Frequency_Annual.Instance), new ScheduleInfo(valuationDate, valuationDate.AddMonths(6), Frequency_Weekly.Instance))
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
