using System.Collections.Generic;

namespace Abacus.Measures.Services
{
    public interface IMeasureRegistry
    {
        IReadOnlyList<MeasureType> AllMeasures { get; }
        IReadOnlyList<MeasureType> GetMeasuresForTarget<TTarget>();
        IReadOnlyList<MeasureType> GetMeasuresForTarget<TTarget>(TTarget target);
    }
}
