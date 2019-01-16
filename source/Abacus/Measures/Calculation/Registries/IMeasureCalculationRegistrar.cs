using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public interface IMeasureCalculationRegistrar
    {
        MeasureCalculationRegistrar RegisterInstance<TTarget>(MeasureType measureType, IMeasureCalculator<TTarget> calculator);

        MeasureCalculationRegistrar RegisterDefaultInstance<TTarget, TCalculator>(MeasureType measureType) where TCalculator : IMeasureCalculator<TTarget>, new();

        MeasureCalculationRegistrar RegisterType<TTarget, TCalculator>(MeasureType measureType) where TCalculator : IMeasureCalculator<TTarget>;
    }
}
