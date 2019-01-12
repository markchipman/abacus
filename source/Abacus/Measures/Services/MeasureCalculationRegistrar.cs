﻿using System;
using Abacus.Measures.Calculators;
using Abacus.Services;

namespace Abacus.Measures.Services
{
    public class MeasureCalculationRegistrar : MeasureCalculationRegistry, IMeasureCalculationRegistrar
    {
        private readonly IServiceProvider _serviceProvider;

        public MeasureCalculationRegistrar()
            : this(ServiceDictionary.Empty)
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

        public MeasureCalculationRegistrar RegisterCalculator<TTarget>(MeasureType measure, MeasureCalculator<TTarget> calculator)
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

        public MeasureCalculationRegistrar RegisterCalculator<TTarget, TCalculator>(MeasureType measure) where TCalculator : MeasureCalculator<TTarget>
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
