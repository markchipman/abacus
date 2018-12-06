namespace Abakus.Core
{
    public interface IResolvable<T>
    {
        T Resolve(IReferenceData refData);
    }
}