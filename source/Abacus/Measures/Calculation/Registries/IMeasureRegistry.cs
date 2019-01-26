using System.Collections.Generic;

namespace Abacus.Measures.Services
{
    public interface IMeasureRegistry
    {
        IReadOnlyList<Measure> AllMeasures { get; }

        IEnumerable<Measure> GetMeasuresForTarget<TTarget>();

        IEnumerable<Measure> GetMeasuresForTarget<TTarget>(TTarget target);
    }
}
