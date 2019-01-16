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

        public MeasureCalculationRegistrar RegisterDefaultInstance<TTarget, TCalculator>(MeasureType measureType) where TCalculator : IMeasureCalculator<TTarget>, new()
        {
            return RegisterInstance(measureType, new TCalculator());
        }

        public MeasureCalculationRegistrar RegisterInstance<TTarget>(MeasureType measureType, IMeasureCalculator<TTarget> calculator)
        {
            if (measureType == null)
            {
                throw new ArgumentNullException(nameof(measureType));
            }
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }

            Registrations.Add(Tuple.Create(measureType, typeof(IMeasureCalculator<TTarget>)), () => calculator);

            return this;
        }


        public MeasureCalculationRegistrar RegisterType<TTarget, TCalculator>(MeasureType measureType) where TCalculator : IMeasureCalculator<TTarget>
        {
            if (measureType == null)
            {
                throw new ArgumentNullException(nameof(measureType));
            }

            Registrations.Add(Tuple.Create(measureType, typeof(TCalculator)), () => _serviceProvider.GetService(typeof(TCalculator)));

            return this;
        }
    }
}
