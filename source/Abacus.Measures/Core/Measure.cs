﻿using Abacus.Common.Enums;
using System;

namespace Abacus.Measures
{
    public abstract class Measure<TSelf> : Measure where TSelf : Measure<TSelf>, new()
    {
        static Measure()
        {
        }

        public Measure()
        {
        }

        public static TSelf Instance = new TSelf();

        public override string Id { get; } = nameof(TSelf).ToCamelCase();
    }

    public abstract class Measure : Enumeration<string>
    {
        public Measure()
        {
        }
    }
}