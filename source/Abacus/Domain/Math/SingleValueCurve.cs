using System;

namespace Abacus.Domain
{
    public sealed class ZeroSlopeCurve : Curve
    {
        public ZeroSlopeCurve(decimal value)
            : base(new[] { new Point(1, value) })
        {

        }

        public ZeroSlopeCurve(Point point)
            : base(new[] { point ?? throw new ArgumentNullException(nameof(point)) })
        {

        }


        public override decimal Y(decimal x)
        {
            return this[0].Y;
        }
    }
}
