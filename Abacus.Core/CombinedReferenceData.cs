using System;

namespace Abacus.Core
{
    public class CombinedReferenceData : IReferenceData
    {
        private readonly IReferenceData _refData1;
        private readonly IReferenceData _refData2;

        public CombinedReferenceData(IReferenceData refData1, IReferenceData refData2)
        {
            _refData1 = refData1 ?? throw new ArgumentNullException(nameof(refData1));
            _refData2 = refData2 ?? throw new ArgumentNullException(nameof(refData2));
        }

        public bool Contains<T>(IReferenceDataId<T> id) where T : class
        {
            return _refData1.Contains(id) || _refData2.Contains(id);
        }

        public T GetValue<T>(IReferenceDataId<T> id) where T : class
        {
            return _refData1.GetValueOrDefault(id) ?? _refData2.GetValueOrDefault(id) ?? throw new ReferenceDataNotFoundException<T>(id);
        }

        public T GetValueOrDefault<T>(IReferenceDataId<T> id, T defaultValue = default) where T : class
        {
            return _refData1.Contains(id) ? _refData1.GetValue(id) : _refData2.GetValueOrDefault(id);
        }
    }
}