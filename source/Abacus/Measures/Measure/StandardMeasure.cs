namespace Abacus.Measures
{
    public sealed class StandardMeasure
    {
        public static readonly PricingModel PricingModel = PricingModel.Instance;
        public static readonly PresentValue PresentValue = PresentValue.Instance;
        public static readonly FutureValue FutureValue = FutureValue.Instance;
    }
}
