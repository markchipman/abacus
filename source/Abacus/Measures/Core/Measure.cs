using System;
using Abacus.Enums;

namespace Abacus.Measures
{
    public abstract class Measure<TSelf> : Measure where TSelf : Measure<TSelf>, new()
    {
        public static TSelf Instance = new TSelf();

        static Measure()
        {
        }

        public override string Id { get; } = typeof(TSelf).Name.SplitPascalCase().ReplaceSpaceWith("-").ToLowerInvariant();
    }

    public abstract class Measure : Enumeration<string>
    {
    }
}
