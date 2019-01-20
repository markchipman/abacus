namespace Abacus.Measures
{
    public sealed class StandardMeasure
    {
        public static readonly Measure PricingModel = Measure_PricingModel.Instance;
        public static readonly Measure PresentValue = Measure_PresentValue.Instance;
        public static readonly Measure FutureValue = Measure_FutureValue.Instance;
    }
}
