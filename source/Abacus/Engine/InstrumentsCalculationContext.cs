using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Abacus.Data.MarketData;
using Abacus.Domain.Core;
using Abacus.Measures;
using Abacus.Measures.Calculation;

namespace Abacus.Engine
{
    public class InstrumentsCalculationContext : ReadOnlyCollection<InstrumentCalculationContext>
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

            foreach (var instrumentContext in this)
            {
                var requirements = instrumentContext.GetRequirements(calculator, valuationDate, measures);
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

            foreach (var instrumentContext in this)
            {
                var measureResults = instrumentContext.CalculateMeasures(calculator, valuationDate, marketData, measures);
                foreach (var measureResult in measureResults)
                {
                    yield return measureResult;
                }
            }
        }

        public static IReadOnlyList<InstrumentCalculationContext> CreateCalculationContexts(IEnumerable<Instrument> instruments)
        {
            if (instruments == null)
            {
                throw new ArgumentNullException(nameof(instruments));
            }

            var instrumentContexts = new List<InstrumentCalculationContext>();
            foreach (var instrument in instruments)
            {
                var contextProvider = new InstrumentCalculationContextProvider();
                instrument.ProvideContext(contextProvider);
                var instrumentContext = contextProvider.Context;
                instrumentContexts.Add(instrumentContext);
            }
            return instrumentContexts;
        }
    }
}
