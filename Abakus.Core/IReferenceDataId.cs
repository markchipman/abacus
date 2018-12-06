namespace Abakus.Core
{
    public interface IReferenceDataId<T>
    {
        T GetValueOrDefault(IReferenceData refData, T defaultValue = default);
    }
}