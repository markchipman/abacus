﻿namespace Abacus.Context
{
    public interface IAcceptContext<in TBase>
    {
        void AcceptContext<T>(T context) where T : TBase;
    }
}
