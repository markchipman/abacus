namespace Abacus.Measures.Services
{
    public class MeasureRegistrar : MeasureRegistry, IMeasureRegistrar
    {
        public MeasureRegistrar RegisterMeasure<TTarget, TMeasure>() where TMeasure : Measure, new()
        {
            return this;
        }

        public MeasureRegistrar RegisterCalculator<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : Measure, new()
        {
            return RegisterMeasure<TTarget, TMeasure>();
        }
    }
}
