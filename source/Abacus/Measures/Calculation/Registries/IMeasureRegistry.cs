using System.Collections.Generic;

namespace Abacus.Measures.Services
{
    public interface IMeasureRegistry
    {
        IReadOnlyList<Measure> AllMeasures { get; }

        IReadOnlyList<Measure> GetMeasuresForTarget<TTarget>();

        IReadOnlyList<Measure> GetMeasuresForTarget<TTarget>(TTarget target);
    }
}
