using System;
using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public class MeasureCalculationRegistry
    {
        public MeasureCalculator<TTarget, TMeasure> GetCalculator<TTarget, TMeasure>() where TMeasure : MeasureType, new()
        {
            throw new NotImplementedException();
        }

        public MeasureCalculator<TTarget, TMeasure> GetCalculator<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : MeasureType
        {
            throw new NotImplementedException();
        }
    }
}
