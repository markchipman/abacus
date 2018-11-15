using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Abacus.Core
{
    public class ImmutableReferenceData : IReferenceData
    {
        private readonly ImmutableHelper _immutableHelper = new ImmutableHelper();
        private readonly IReadOnlyDictionary<object, object> _data;

        public ImmutableReferenceData(IDictionary<object, object> data)
        {
            _data = new ReadOnlyDictionary<object, object>(data);
        }

        public bool Contains<T>(IReferenceDataId<T> id) where T : class
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return _data.ContainsKey(id);
        }

        public T GetValue<T>(IReferenceDataId<T> id) where T : class
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return (T)_data[id];
        }

        public T GetValueOrDefault<T>(IReferenceDataId<T> id, T defaultValue = default) where T : class
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return (T)(_data.TryGetValue(id, out object value) ? value : defaultValue);
        }
    }
}