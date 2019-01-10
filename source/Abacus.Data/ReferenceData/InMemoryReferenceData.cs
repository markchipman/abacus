using Abacus.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Abacus.Data.ReferenceData {
    public class InMemoryReferenceData : IReferenceData {
        private readonly ImmutableHelper immutableHelper = new ImmutableHelper();
        private readonly IReadOnlyDictionary<object, object> data;

        public InMemoryReferenceData(IDictionary<object, object> data) {
            this.data = new ReadOnlyDictionary<object, object>(data);
        }

        public bool Contains<T>(IReferenceDataId<T> id) where T : class {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return data.ContainsKey(id);
        }

        public T GetValue<T>(IReferenceDataId<T> id) where T : class {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return (T)data[id];
        }

        public T GetValueOrDefault<T>(IReferenceDataId<T> id, T @default = default) where T : class {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return (T)(data.TryGetValue(id, out var value) ? value : @default);
        }
    }
}
