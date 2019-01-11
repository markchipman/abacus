using System;
using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public class MeasureCalculatorRegistry
    {
        public MeasureCalculator<TTarget, TMeasure> Get<TTarget, TMeasure>() where TMeasure : Measure, new()
        {
            throw new NotImplementedException();
        }

        public MeasureCalculator<TTarget, TMeasure> Get<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : Measure
        {
            throw new NotImplementedException();
        }
    }
}
