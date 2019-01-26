using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Abacus.Domain
{

    public class Curve : ReadOnlyCollection<Point>
    {
        public Curve(IEnumerable<Point> points)
            : this(points?.ToList() ?? throw new ArgumentNullException(nameof(points)))
        {
        }

        public Curve(IList<Point> points)
            : base(Sort(points ?? throw new ArgumentNullException(nameof(points))))
        {
        }

        public virtual decimal Y(decimal x)
        {
            return x;
        }

        private static IList<Point> Sort(IList<Point> points, bool returnNewList = false)
        {
            return InsertionSort(points, returnNewList);
        }

        private static IList<T> InsertionSort<T>(IList<T> list, bool returnNewList = false) where T : IComparable<T>
        {
            if (list is null)
            {
                return returnNewList ? new List<T>() : list;
            }

            var sorted = returnNewList ? new List<T>(list) : list;
            for (int i = 1, j; i < sorted.Count; i++)
            {
                var value = sorted[i];
                j = i - 1;
                while ((j >= 0) && (sorted[j].CompareTo(value) > 0))
                {
                    sorted[j + 1] = sorted[j];
                    j -= 1;
                }
                sorted[j + 1] = value;
            }

            return sorted;
        }

        public override string ToString()
        {
            return Count + " points";
        }
    }
}
