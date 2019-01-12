using System;
using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public class MeasureCalculationRegistrar : MeasureCalculationRegistry
    {
        public MeasureCalculationRegistrar RegisterCalculator<TTarget, TMeasure, TCalculator>() where TMeasure : MeasureType, new() where TCalculator : MeasureCalculator<TTarget, TMeasure>
        {
            return this;
        }

        public MeasureCalculationRegistrar RegisterCalculator<TTarget, TMeasure, TCalculator>(TCalculator instance) where TMeasure : MeasureType, new() where TCalculator : MeasureCalculator<TTarget, TMeasure>
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return this;
        }

        public MeasureCalculationRegistrar RegisterCalculator<TTarget, TMeasure, TCalculator>(Func<TCalculator> factory) where TMeasure : MeasureType, new() where TCalculator : MeasureCalculator<TTarget, TMeasure>
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            return this;
        }
    }
}
