using System;
using System.Collections.Generic;
using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public class MeasureCalculationRegistry : IMeasureCalculationRegistry
    {
        protected IDictionary<Tuple<MeasureType, Type>, Func<object>> Registrations = new Dictionary<Tuple<MeasureType, Type>, Func<object>>();

        public IMeasureCalculator<TTarget> GetCalculator<TTarget, TMeasure>(TTarget target, TMeasure measureType) where TMeasure : MeasureType
        {
            if (Registrations.TryGetValue(Tuple.Create<MeasureType, Type>(measureType, typeof(IMeasureCalculator<TTarget>)), out var registration))
            {
                var instance = registration();
                switch (instance)
                {
                    case IMeasureCalculator<TTarget> measureCalculator:
                        return measureCalculator;
                    case null:
                        throw new ApplicationException("Null instance resolved from registration.");
                    default:
                        throw new ApplicationException("Resolved calculator type '" + instance.GetType() + " is not a '" + typeof(IMeasureCalculator<TTarget>).Name + "'.");
                }
            }
            return null;
        }
    }
}
