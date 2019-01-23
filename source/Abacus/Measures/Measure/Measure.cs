using System;
using Abacus.Enums;

namespace Abacus.Measures
{
    public abstract class Measure : Enumeration<string>
    {
        protected Measure(string id)
            : base(id)
        {
        }
    }
}
