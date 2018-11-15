namespace Abacus.Core
{
    public interface IResolvableCalculationTarget : ICalculationTarget
    {
        ICalculationTarget resolveTarget(IReferenceData refData);
    }
}
