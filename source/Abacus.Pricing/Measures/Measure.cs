using System;
using Abacus.Common.Enums;
using Abacus.Common.Extensions;
using Abacus.Pricing.Models;

namespace Abacus.Pricing.Measures
{
    public abstract class Measure : Enumeration<string>
    {
        protected Measure(string id)
            : base(id)
        {
        }
    }
}
