namespace Abakus.Core
{
    public interface IReferenceData
    {
        bool Contains<T>(IReferenceDataId<T> id) where T : class;

        T GetValue<T>(IReferenceDataId<T> id) where T : class;

        T GetValueOrDefault<T>(IReferenceDataId<T> id, T defaultValue = default)  where T : class;
    }
}