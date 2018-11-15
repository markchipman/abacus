namespace Abacus.Core
{
    public interface IResolvableCalculationTarget : ICalculationTarget
    {
        ICalculationTarget ResolveForCalculation(IReferenceData refData);
    }
}
