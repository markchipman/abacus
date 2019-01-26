using System;

namespace Abacus.Domain
{
    internal sealed class Frequency_Once : Frequency
    {
        public override DateTime? Next(DateTime date) => null;
    }
}
