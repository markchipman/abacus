namespace Abacus.Measures.Services
{
    public interface IMeasureRegistrar : IMeasureRegistry
    {
        MeasureRegistrar RegisterCalculator<TTarget, TMeasure>(TTarget target, TMeasure measureType) where TMeasure : MeasureType, new();

        MeasureRegistrar RegisterMeasure<TTarget, TMeasure>() where TMeasure : MeasureType, new();
    }
}
