using System;
using System.Collections.Generic;

namespace Abacus.Measures.Services
{

    public class MeasureRegistry : IMeasureRegistry
    {
        public IReadOnlyList<Measure> AllMeasures { get; }

        public IEnumerable<Measure> GetMeasuresForTarget<TTarget>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Measure> GetMeasuresForTarget<TTarget>(TTarget target)
        {
            throw new NotImplementedException();
        }
    }
}
