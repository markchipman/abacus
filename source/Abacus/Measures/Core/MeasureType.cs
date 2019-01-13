using System;
using Abacus.Enums;

namespace Abacus.Measures
{
    public abstract class MeasureType<TSelf> : MeasureType where TSelf : MeasureType<TSelf>, new()
    {
        public static TSelf Instance = new TSelf();

        static MeasureType()
        {
        }

        protected MeasureType()
            : this(typeof(TSelf).Name.SplitPascalCase().ReplaceSpaceWith("-").ToLowerInvariant())
        {
        }

        protected MeasureType(string id)
            : base(typeof(TSelf).Name.SplitPascalCase().ReplaceSpaceWith("-").ToLowerInvariant())
        {
        }
    }

    public abstract class MeasureType : Enumeration<string>
    {
        protected MeasureType(string id)
        {
            Id = id;
        }

        public override string Id { get; }

    }
}
