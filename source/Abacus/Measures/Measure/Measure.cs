using System;
using Abacus.Enums;

namespace Abacus.Measures
{
    public abstract class Measure<TSelf> : Measure where TSelf : Measure<TSelf>, new()
    {
        public static TSelf Instance = new TSelf();

        protected Measure()
            : this(typeof(TSelf).Name.SplitPascalCase().ReplaceSpaceWith("-").ToLowerInvariant())
        {
        }

        protected Measure(string id)
            : base(typeof(TSelf).Name.SplitPascalCase().ReplaceSpaceWith("-").ToLowerInvariant())
        {
        }
    }

    public abstract class Measure : Enumeration<string>
    {
        protected Measure(string id)
            : base(id)
        {
        }
    }
}
