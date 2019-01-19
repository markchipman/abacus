using System;
using Abacus.Measures.Calculators;
using Abacus.Services;

namespace Abacus.Measures.Services
{
    public class MeasureCalculationRegistrar : MeasureCalculationRegistry, IMeasureCalculationRegistrar
    {
        private readonly IServiceProvider _serviceProvider;

        public MeasureCalculationRegistrar()
            : this(EmptyServiceProvider.Instance)
        {
        }

        public MeasureCalculationRegistrar(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _serviceProvider = serviceProvider;
        }

        public MeasureCalculationRegistrar RegisterDefaultInstance<TTarget, TCalculator>(Measure measure) where TCalculator : IMeasureCalculator<TTarget>, new()
        {
            return RegisterInstance(measure, new TCalculator());
        }

        public MeasureCalculationRegistrar RegisterInstance<TTarget>(Measure measure, IMeasureCalculator<TTarget> calculator)
        {
            if (measure == null)
            {
                throw new ArgumentNullException(nameof(measure));
            }
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }

            Registrations.Add(Tuple.Create(measure, typeof(IMeasureCalculator<TTarget>)), () => calculator);

            return this;
        }


        public MeasureCalculationRegistrar RegisterType<TTarget, TCalculator>(Measure measure) where TCalculator : IMeasureCalculator<TTarget>
        {
            if (measure == null)
            {
                throw new ArgumentNullException(nameof(measure));
            }

            Registrations.Add(Tuple.Create(measure, typeof(TCalculator)), () => _serviceProvider.GetService(typeof(TCalculator)));

            return this;
        }
    }
}
