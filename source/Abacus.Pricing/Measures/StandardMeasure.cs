using Abacus.Common.Extensions;

namespace Abacus.Pricing.Measures
{
    public sealed class PresentValue : Measure<PresentValue>
    {
    }

    public sealed class ForecaseValue : Measure<ForecaseValue>
    {
    }

    public sealed class StandardMeasure
    {
        public static readonly PresentValue PresentValue = PresentValue.Instance;
        public static readonly ForecaseValue ForecaseValue = ForecaseValue.Instance;
    }
}
