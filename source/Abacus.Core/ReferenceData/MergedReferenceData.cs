using System;

namespace Abacus.Core.ReferenceData
{
    public class MergedReferenceData : IReferenceData
    {
        private readonly IReferenceData first;
        private readonly IReferenceData second;

        public MergedReferenceData(IReferenceData first, IReferenceData second)
        {
            this.first = first ?? EmptyReferenceData.Instance;
            this.second = second ?? EmptyReferenceData.Instance;
        }

        public bool Contains<T>(IReferenceDataId<T> id) where T : class
        {
            return first.Contains(id) || second.Contains(id);
        }

        public T GetValue<T>(IReferenceDataId<T> id) where T : class
        {
            return first.GetValueOrDefault(id) ?? second.GetValueOrDefault(id) ?? throw new ReferenceDataNotFoundException<T>(id);
        }

        public T GetValueOrDefault<T>(IReferenceDataId<T> id, T defaultValue = default) where T : class
        {
            return first.Contains(id) ? first.GetValue(id) : second.GetValueOrDefault(id);
        }
    }
}