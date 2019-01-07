using Abacus.Common.Extensions;

namespace Abacus.Pricing.Measures
{
    public sealed class StandardMeasures
    {
        public static readonly PresentValue PresentValue = PresentValue.Instance;
        public static readonly ForecastValue ForecaseValue = ForecastValue.Instance;
    }
}
