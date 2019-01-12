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

        public MeasureCalculationRegistrar RegisterDefaultInstance<TTarget, TCalculator>(MeasureType measure) where TCalculator : IMeasureCalculator<TTarget>, new()
        {
            return RegisterInstance(measure, new TCalculator());
        }

        public MeasureCalculationRegistrar RegisterInstance<TTarget>(MeasureType measure, IMeasureCalculator<TTarget> calculator)
        {
            if (measure == null)
            {
                throw new ArgumentNullException(nameof(measure));
            }
            if (measure.GetType() == typeof(MeasureType))
            {
                throw new ArgumentException("Invalid MeasureType: " + measure.GetType());
            }
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }

            Registrations.Add(new Tuple<Type, MeasureType>(typeof(TTarget), measure), () => calculator);

            return this;
        }


        public MeasureCalculationRegistrar RegisterType<TTarget, TCalculator>(MeasureType measure) where TCalculator : IMeasureCalculator<TTarget>
        {
            if (measure == null)
            {
                throw new ArgumentNullException(nameof(measure));
            }
            if (measure.GetType() == typeof(MeasureType))
            {
                throw new ArgumentException("Invalid MeasureType: " + measure.GetType());
            }

            Registrations.Add(new Tuple<Type, MeasureType>(typeof(TTarget), measure), () => _serviceProvider.GetService(typeof(TCalculator)));

            return this;
        }
    }
}
