using System;
using System.Collections.Generic;

namespace Abacus.Measures.Services
{

    public class MeasureRegistry : IMeasureRegistry
    {
        public IReadOnlyList<Measure> AllmeasureTypes { get; }

        public IReadOnlyList<Measure> GetmeasureTypesForTarget<TTarget>()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Measure> GetmeasureTypesForTarget<TTarget>(TTarget target)
        {
            return GetmeasureTypesForTarget<TTarget>();
        }
    }
}
