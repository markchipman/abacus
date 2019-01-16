using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public interface IMeasureCalculationRegistry
    {
        IMeasureCalculator<TTarget> GetCalculator<TTarget, TMeasure>(TTarget target, TMeasure measureType) where TMeasure : MeasureType;
    }
}
