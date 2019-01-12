using System;
using System.Collections.Generic;

namespace Abacus.Services
{
    public class ServiceDictionary : Dictionary<Type, object>, IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return this[serviceType];
        }
    }
}
