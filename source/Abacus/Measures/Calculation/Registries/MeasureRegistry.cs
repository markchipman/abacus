using System;
using System.Collections.Generic;

namespace Abacus.Measures.Services
{

    public class MeasureRegistry : IMeasureRegistry
    {
        public IReadOnlyList<Measure> AllMeasures { get; }

        public IReadOnlyList<Measure> GetMeasuresForTarget<TTarget>()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Measure> GetMeasuresForTarget<TTarget>(TTarget target)
        {
            return GetMeasuresForTarget<TTarget>();
        }
    }
}
