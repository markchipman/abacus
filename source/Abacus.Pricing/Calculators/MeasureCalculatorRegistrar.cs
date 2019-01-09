using System;

namespace Abacus.Pricing.Measures.Calculators
{
    public class MeasureCalculatorRegistrar
    {

        public MeasureCalculatorRegistrar Register<TTarget, TMeasure, TCalculator>() where TMeasure : Measure, new() where TCalculator : MeasureCalculator<TTarget, TMeasure>
        {
            return this;
        }

        public MeasureCalculatorRegistrar Register<TTarget, TMeasure, TCalculator>(TCalculator instance) where TMeasure : Measure, new() where TCalculator : MeasureCalculator<TTarget, TMeasure>
        {
            if (instance == null)
            {
                throw new System.ArgumentNullException(nameof(instance));
            }

            return this;
        }

        public MeasureCalculatorRegistrar Register<TTarget, TMeasure, TCalculator>(Func<TCalculator> factory) where TMeasure : Measure, new() where TCalculator : MeasureCalculator<TTarget, TMeasure>
        {
            if (factory == null)
            {
                throw new System.ArgumentNullException(nameof(factory));
            }

            return this;
        }
    }
}
