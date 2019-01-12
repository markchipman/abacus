using System;
using System.Collections.Generic;

namespace Abacus.Measures.Services
{
    public class MeasureRegistrar : MeasureRegistry
    {
        public MeasureRegistrar RegisterMeasure<TTarget, TMeasure>() where TMeasure : MeasureType, new()
        {
            return this;
        }

        public MeasureRegistrar RegisterCalculator<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : MeasureType, new()
        {
            return RegisterMeasure<TTarget, TMeasure>();
        }
    }

    public class MeasureRegistry
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

        // TODO - create an InstrumentType enumeration
        //public IReadOnlyList<TTarget> GetTargetTypesForMeasureType<TMeasure>()
        //{
        //    throw new NotImplementedException();
        //}

        //public IReadOnlyList<TTarget> GetTargetTypesForMeasureType<TMeasure>(TTarget target)
        //{
        //    return GetMeasuresForTarget<TTarget>();
        //}
    }
}
