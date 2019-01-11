using Abacus.Data.ReferenceData;

namespace Abacus.Core.Resolvable
{
    public interface IResolvable<T>
    {
        T Resolve(IReferenceData referenceData);
    }
}
