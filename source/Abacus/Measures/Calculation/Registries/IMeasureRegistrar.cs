namespace Abacus.Measures.Services
{
    public interface IMeasureRegistrar : IMeasureRegistry
    {
        MeasureRegistrar RegisterCalculator<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : Measure, new();

        MeasureRegistrar RegisterMeasure<TTarget, TMeasure>() where TMeasure : Measure, new();
    }
}
