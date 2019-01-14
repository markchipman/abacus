using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Abacus.Data.MarketData;
using Abacus.Domain;
using Abacus.Measures;
using Abacus.Measures.Calculation;

namespace Abacus.Engine
{
    public class InstrumentsCalculationContext : ReadOnlyCollection<ICalculationContext>, ICalculationContext
    {
        public InstrumentsCalculationContext(IEnumerable<Instrument> instruments)
            : base(CreateCalculationContexts(instruments).ToList())
        {
        }

        public IEnumerable<MarketDataRequirement> GetRequirements(MeasuresCalculator calculator, DateTime valuationDate, params MeasureType[] measures)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }
            if (measures == null)
            {
                throw new ArgumentNullException(nameof(measures));
            }

            foreach (var calculationContext in this)
            {
                var requirements = calculationContext.GetRequirements(calculator, valuationDate, measures);
                foreach (var requirement in requirements)
                {
                    yield return requirement;
                }
            }
        }

        public IEnumerable<MeasureResult> CalculateMeasures(MeasuresCalculator calculator, DateTime valuationDate, IMarketData marketData, params MeasureType[] measures)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }
            if (marketData == null)
            {
                throw new ArgumentNullException(nameof(marketData));
            }
            if (measures == null)
            {
                throw new ArgumentNullException(nameof(measures));
            }

            foreach (var calculationContext in this)
            {
                var measureResults = calculationContext.CalculateMeasures(calculator, valuationDate, marketData, measures);
                foreach (var measureResult in measureResults)
                {
                    yield return measureResult;
                }
            }
        }

        public static IReadOnlyList<ICalculationContext> CreateCalculationContexts(IEnumerable<Instrument> instruments)
        {
            if (instruments == null)
            {
                throw new ArgumentNullException(nameof(instruments));
            }

            var calculationContexts = new List<ICalculationContext>();
            foreach (var instrument in instruments)
            {
                var instrumentCalculationContext = instrument.ToCalculationContext();
                calculationContexts.Add(instrumentCalculationContext);
            }
            return calculationContexts;
        }
    }
}
