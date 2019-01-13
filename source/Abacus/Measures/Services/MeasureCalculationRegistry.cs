using System;
using System.Collections.Generic;
using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public class MeasureCalculationRegistry : IMeasureCalculationRegistry
    {
        protected IDictionary<Tuple<Type, MeasureType>, Func<object>> Registrations = new Dictionary<Tuple<Type, MeasureType>, Func<object>>();

        public IMeasureCalculator<TTarget> GetCalculator<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : MeasureType
        {
            if (Registrations.TryGetValue(Tuple.Create<Type, MeasureType>(typeof(TTarget), measure), out var registration))
            {
                var instance = registration();
                switch (instance)
                {
                    case IMeasureCalculator<TTarget> measureCalculator:
                        return measureCalculator;
                    case null:
                        throw new ApplicationException("Null instance resolved from registration.");
                    default:
                        throw new ApplicationException("Expected calculator of type '" + typeof(IMeasureCalculator<TTarget>).Name + "', but was provided calculator of type '" + instance.GetType() + "'.");
                }
            }
            return null;
        }
    }
}
