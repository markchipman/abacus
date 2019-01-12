using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public interface IMeasureCalculationRegistrar
    {
        MeasureCalculationRegistrar RegisterCalculator<TTarget, TCalculator>(MeasureType measure) where TCalculator : MeasureCalculator<TTarget>;
        MeasureCalculationRegistrar RegisterCalculator<TTarget>(MeasureType measure, MeasureCalculator<TTarget> calculator);
    }
}