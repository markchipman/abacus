using System;

namespace Abacus.Core.ReferenceData
{
    public class MergedReferenceData : IReferenceData
    {
        private readonly IReferenceData _first;
        private readonly IReferenceData _second;

        public MergedReferenceData(IReferenceData first, IReferenceData second)
        {
            _first = first ?? EmptyReferenceData.Instance;
            _second = second ?? EmptyReferenceData.Instance;
        }

        public bool Contains<T>(IReferenceDataId<T> id) where T : class
        {
            return _first.Contains(id) || _second.Contains(id);
        }

        public T GetValue<T>(IReferenceDataId<T> id) where T : class
        {
            return _first.GetValueOrDefault(id) ?? _second.GetValueOrDefault(id) ?? throw new ReferenceDataNotFoundException<T>(id);
        }

        public T GetValueOrDefault<T>(IReferenceDataId<T> id, T defaultValue = default) where T : class
        {
            return _first.Contains(id) ? _first.GetValue(id) : _second.GetValueOrDefault(id);
        }
    }
}