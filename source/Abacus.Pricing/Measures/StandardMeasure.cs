using Abacus.Common.Extensions;

namespace Abacus.Pricing.Measures
{
    public sealed class StandardMeasure : Measure
    {
        public static readonly StandardMeasure PresentValue = new StandardMeasure(nameof(PresentValue).ToCamelCase());
        public static readonly StandardMeasure ForecaseValue = new StandardMeasure(nameof(ForecaseValue).ToCamelCase());

        private StandardMeasure(string id)
            : base(id)
        {
        }
    }
}
