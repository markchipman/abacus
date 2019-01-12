using System;
using System.Linq;
using Abacus.Data.MarketData;
using Abacus.Domain.Core;
using Abacus.Domain.Instruments;
using Abacus.Engine;
using Abacus.Measures;
using Abacus.Measures.Calculation;
using Abacus.Measures.Calculators;
using Abacus.Measures.Services;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebAPI.Controllers
{
    [Route("api/calculate")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpGet("measures")]
        public IActionResult CalculateMeasures()
        {
            var instrument1 = new FixedCouponBond(new Counterparty(), new CurrencyAmount(1000000, new Currency("USD")), new Rate(0.025m, Frequency.Annually), new ScheduleInfo(DateTime.Today, DateTime.Today.AddYears(1)));
            var instruments = new Instrument[] { instrument1 };

            var valuationDate = DateTime.Now;
            var measures = new MeasureType[] { StandardMeasures.PresentValue };

            var calculatorRegistrar = new MeasureCalculationRegistrar();
            calculatorRegistrar.RegisterCalculator(StandardMeasures.PresentValue, new FixedCouponBondPresentValueCalculator());

            var calculator = new MeasuresCalculator(calculatorRegistrar);

            var marketData = new MarketData(); // created using market data requirements

            var calculationContext = new InstrumentsCalculationContext(instruments);

            var requirements = calculationContext.GetRequirements(calculator, valuationDate, measures).ToList();
            var results = calculationContext.CalculateMeasures(calculator, valuationDate, marketData, measures).ToList();


            return Ok();
        }
    }
}
