namespace Abacus.Measures
{
    public sealed class StandardMeasure
    {
        static StandardMeasure()
        {
        }

        public static readonly Measure PricingModel = new Measure_PricingModel();
        public static readonly Measure PresentValue = new Measure_PresentValue();
        public static readonly Measure FutureValue = new Measure_FutureValue();
    }
}
