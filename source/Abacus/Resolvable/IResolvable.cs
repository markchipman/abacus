using Abacus.Data.ReferenceData;

namespace Abacus.Resolvable
{
    public interface IResolvable<T>
    {
        T Resolve(IReferenceData referenceData);
    }
}
