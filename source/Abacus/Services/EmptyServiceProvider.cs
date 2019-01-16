using System;
using System.Collections.Generic;

namespace Abacus.Services
{
    public sealed class EmptyServiceProvider : IServiceProvider
    {
        public static readonly IServiceProvider Instance = new EmptyServiceProvider();

        static EmptyServiceProvider()
        {
        }

        public object GetService(Type serviceType)
        {
            throw new KeyNotFoundException("Empty service provider.");
        }
    }
}
