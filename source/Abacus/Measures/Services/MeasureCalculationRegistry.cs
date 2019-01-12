using System;
using System.Collections.Generic;
using Abacus.Measures.Calculators;

namespace Abacus.Measures.Services
{
    public class MeasureCalculationRegistry
    {
        protected IDictionary<Tuple<Type, MeasureType>, Func<object>> Registrations = new Dictionary<Tuple<Type, MeasureType>, Func<object>>();

        public MeasureCalculator<TTarget> GetCalculator<TTarget, TMeasure>(TTarget target, TMeasure measure) where TMeasure : MeasureType
        {
            if (Registrations.TryGetValue(new Tuple<Type, MeasureType>(typeof(TTarget), measure), out var registration))
            {
                var instance = registration();
                switch (instance)
                {
                    case MeasureCalculator<TTarget> measureCalculator:
                        return measureCalculator;
                    case null:
                        throw new ApplicationException("Null instance resolved from registration.");
                    default:
                        throw new ApplicationException("Expected calculator of type '" + typeof(MeasureCalculator<TTarget>).Name + "', was calculator of type '" + instance.GetType() + "'.");
                }
            }
            return null;
        }
    }
}
