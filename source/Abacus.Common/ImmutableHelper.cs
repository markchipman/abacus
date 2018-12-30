using System;

namespace Abacus.Common
{
    public class ImmutableHelper
    {
        private int? cachedHashCode;
        private string cachedToString;

        public int GetCachedHashCode(Func<int> generateHashCode)
        {
            if (generateHashCode == null) throw new ArgumentNullException(nameof(generateHashCode));
            return cachedHashCode ?? (cachedHashCode = generateHashCode()).Value;
        }

        public string GetCachedToString(Func<string> generateToString)
        {
            if (generateToString == null) throw new ArgumentNullException(nameof(generateToString));
            return cachedToString ?? (cachedToString = generateToString());
        }
    }
}
