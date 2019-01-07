using System;
using Abacus.Common.Enums;
using Abacus.Common.Extensions;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures
{
    public abstract class Measure<TSelf> : Measure where TSelf : Measure<TSelf>, new()
    {
        static Measure()
        {
        }

        public static TSelf Instance = new TSelf();

        public override string Id { get; } = nameof(TSelf).ToCamelCase();
    }

    public abstract class Measure : Enumeration<string>
    {
        static Measure()
        {
        }

        public Measure()
        {
        }
    }
}
