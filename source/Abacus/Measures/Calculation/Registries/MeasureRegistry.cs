using System;
using System.Collections.Generic;

namespace Abacus.Measures.Services
{

    public class MeasureRegistry : IMeasureRegistry
    {
        public IReadOnlyList<MeasureType> AllMeasures { get; }

        public IReadOnlyList<MeasureType> GetMeasuresForTarget<TTarget>()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<MeasureType> GetMeasuresForTarget<TTarget>(TTarget target)
        {
            return GetMeasuresForTarget<TTarget>();
        }
    }
}
