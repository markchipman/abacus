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
                new FixedCouponBond(new Counterparty(), new CurrencyAmount(500000, new Currency("GBP")), new Rate(0.011m, AnnuallyFrequency.Instance), new ScheduleInfo(DateTime.Today.Date, DateTime.Today.Date.AddYears(1), NoneRollConvention.Instance, ActActDayCountConvention.Instance , AnnuallyFrequency.Instance)),
                new FixedCouponBond(new Counterparty(), new CurrencyAmount(500000, new Currency("GBP")), new Rate(0.011m, AnnuallyFrequency.Instance), new ScheduleInfo(DateTime.Today.Date, DateTime.Today.Date.AddYears(1), NoneRollConvention.Instance, ActActDayCountConvention.Instance , SemiAnnuallyFrequency.Instance)),
                new FixedCouponBond(new Counterparty(), new CurrencyAmount(500000, new Currency("GBP")), new Rate(0.011m, AnnuallyFrequency.Instance), new ScheduleInfo(DateTime.Today.Date, DateTime.Today.Date.AddYears(1), NoneRollConvention.Instance, ActActDayCountConvention.Instance , QuarterlyFrequency.Instance)),
                new FixedCouponBond(new Counterparty(), new CurrencyAmount(500000, new Currency("GBP")), new Rate(0.011m, AnnuallyFrequency.Instance), new ScheduleInfo(DateTime.Today.Date, DateTime.Today.Date.AddYears(1), NoneRollConvention.Instance, ActActDayCountConvention.Instance , MonthlyFrequency.Instance))
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
