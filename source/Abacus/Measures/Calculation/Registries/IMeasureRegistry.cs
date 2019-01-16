using System.Collections.Generic;

namespace Abacus.Measures.Services
{
    public interface IMeasureRegistry
    {
        IReadOnlyList<MeasureType> AllmeasureTypes { get; }

        IReadOnlyList<MeasureType> GetmeasureTypesForTarget<TTarget>();

        IReadOnlyList<MeasureType> GetmeasureTypesForTarget<TTarget>(TTarget target);
    }
}
