using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public interface IMeasureCalculationRegistrar
    {
        MeasureCalculationRegistrar RegisterInstance<TTarget>(MeasureType measure, IMeasureCalculator<TTarget> calculator);

        MeasureCalculationRegistrar RegisterDefaultInstance<TTarget, TCalculator>(MeasureType measure) where TCalculator : IMeasureCalculator<TTarget>, new();

        MeasureCalculationRegistrar RegisterType<TTarget, TCalculator>(MeasureType measure) where TCalculator : IMeasureCalculator<TTarget>;
    }
}
