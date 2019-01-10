using System;

namespace Abacus.Measures.Services
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

        public MeasureCalculator<TTarget, TMeasure> Get<TTarget, TMeasure>() where TMeasure : Measure, new()
        {
            throw new NotImplementedException();
        }

        public MeasureCalculator<TTarget, TMeasure> Get<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : Measure
        {
            throw new NotImplementedException();
        }
    }
}
