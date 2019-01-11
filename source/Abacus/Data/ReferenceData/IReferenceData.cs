namespace Abacus.Data.ReferenceData
{
    public interface IReferenceData
    {
        bool Contains<T>(IReferenceDataId<T> id);

        T GetValue<T>(IReferenceDataId<T> id);

        T GetValueOrDefault<T>(IReferenceDataId<T> id, T @default = default);
    }
}
