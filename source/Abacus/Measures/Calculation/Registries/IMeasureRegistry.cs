using System.Collections.Generic;

namespace Abacus.Measures.Services
{
    public interface IMeasureRegistry
    {
        IReadOnlyList<Measure> AllmeasureTypes { get; }

        IReadOnlyList<Measure> GetmeasureTypesForTarget<TTarget>();

        IReadOnlyList<Measure> GetmeasureTypesForTarget<TTarget>(TTarget target);
    }
}
