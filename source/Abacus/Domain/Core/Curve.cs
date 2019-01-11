namespace Abacus.Domain.Core
{
    public class Curve
    {
        public decimal Y(decimal x)
        {
            return 1m;
        }
    }

    public class Point
    {
        public decimal X { get; }

        public decimal Y { get; }
    }
}
