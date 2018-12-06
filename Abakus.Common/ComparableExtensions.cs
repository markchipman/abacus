using System;
using System.Linq;

namespace Abakus.Common
{
    public static class ComparableExtensions
    {
        public static int MultiLevelCompareTo<T>(this IComparable<T> comparable, params Func<int>[] compareToDelegates)
        {
            if (compareToDelegates == null)
            {
                throw new ArgumentNullException(nameof(compareToDelegates));
            }
            return compareToDelegates.Select(compareTo => compareTo()).FirstOrDefault(result => result != 0);
        }

        public static int MultiLevelCompareTo(this IComparable comparable, params Func<int>[] compareToDelegates)
        {
            if (compareToDelegates == null)
            {
                throw new ArgumentNullException(nameof(compareToDelegates));
            }
            return compareToDelegates.Select(compareTo => compareTo()).FirstOrDefault(result => result != 0);
        }
    }
}
