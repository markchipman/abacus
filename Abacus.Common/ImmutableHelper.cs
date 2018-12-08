using System;

namespace Abacus.Common
{
    public class ImmutableHelper
    {
        private int? _cachedHashCode;
        private string _cachedToString;

        public int GetCachedHashCode(Func<int> generateHashCode)
        {
            if (generateHashCode == null) throw new ArgumentNullException(nameof(generateHashCode));
            return _cachedHashCode ?? (_cachedHashCode = generateHashCode()).Value;
        }

        public string GetCachedToString(Func<string> generateToString)
        {
            if (generateToString == null) throw new ArgumentNullException(nameof(generateToString));
            return _cachedToString ?? (_cachedToString = generateToString());
        }
    }
}
