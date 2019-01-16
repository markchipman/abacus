using System;
using System.Collections.Generic;

namespace Abacus.Measures.Services
{

    public class MeasureRegistry : IMeasureRegistry
    {
        public IReadOnlyList<MeasureType> AllmeasureTypes { get; }

        public IReadOnlyList<MeasureType> GetmeasureTypesForTarget<TTarget>()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<MeasureType> GetmeasureTypesForTarget<TTarget>(TTarget target)
        {
            return GetmeasureTypesForTarget<TTarget>();
        }
    }
}
