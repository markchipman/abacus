using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public interface IMeasureCalculationRegistry
    {
        IMeasureCalculator<TTarget> GetCalculator<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : MeasureType;
    }
}
