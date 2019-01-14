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

namespace Abacus.WebApi.Controllers
{
    [Route("api/calculate")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpGet("measures")]
        public IActionResult CalculateMeasures()
        {
            // done outside of controller:
            var calculatorRegistrar = new MeasureCalculationRegistrar()
                .RegisterInstance(StandardMeasures.PresentValue, FixedCouponBondPresentValueCalculator.Instance)
                .RegisterInstance(StandardMeasures.FutureValue, FixedCouponBondFutureValueCalculator.Instance);
            var calculator = new MeasuresCalculator(calculatorRegistrar);
            var marketData = new MarketData(); // created using market data requirements

            // resolved models from DTOs:
            var valuationDate = DateTime.Now;
            var instruments = new Instrument[]
            {
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(1_000_000, new Currency("GBP")), new Rate(0.0010m, AnnuallyFrequency.Instance), new ScheduleInfo(new DateTime(2019, 01, 01), new DateTime(2019, 01, 01).AddYears(1), AnnuallyFrequency.Instance)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(20_000_000, new Currency("GBP")), new Rate(0.0020m, AnnuallyFrequency.Instance), new ScheduleInfo(new DateTime(2019, 01, 01), new DateTime(2019, 01, 01).AddYears(2), SemiAnnuallyFrequency.Instance)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(500_000_000, new Currency("GBP")), new Rate(0.0025m, AnnuallyFrequency.Instance), new ScheduleInfo(new DateTime(2019, 01, 01), new DateTime(2019, 01, 01).AddYears(12), QuarterlyFrequency.Instance)),
                new FixedCouponBond(Counterparty.DummyCounterparty, new CurrencyAmount(1_000_000_000, new Currency("GBP")), new Rate(0.0002m, AnnuallyFrequency.Instance), new ScheduleInfo(new DateTime(2019, 01, 01), new DateTime(2019, 01, 01).AddMonths(6), MonthlyFrequency.Instance))
            };
            var measures = new MeasureType[]
            {
                StandardMeasures.PresentValue,
                StandardMeasures.FutureValue
            };

            // done in engine, called by service/controller:
            var calculationContext = new InstrumentsCalculationContext(instruments);
            var requirements = calculationContext.GetRequirements(calculator, valuationDate, measures).ToList();
            var results = calculationContext.CalculateMeasures(calculator, valuationDate, marketData, measures).ToList();

            // TODO
            return Ok(results);
        }
    }
}
