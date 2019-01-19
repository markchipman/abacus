using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public interface IMeasureCalculationRegistrar
    {
        MeasureCalculationRegistrar RegisterInstance<TTarget>(Measure measure, IMeasureCalculator<TTarget> calculator);

        MeasureCalculationRegistrar RegisterDefaultInstance<TTarget, TCalculator>(Measure measure) where TCalculator : IMeasureCalculator<TTarget>, new();

        MeasureCalculationRegistrar RegisterType<TTarget, TCalculator>(Measure measure) where TCalculator : IMeasureCalculator<TTarget>;
    }
}
