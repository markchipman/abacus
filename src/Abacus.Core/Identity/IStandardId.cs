namespace Abacus.Core.Identity
{
    public interface IStandardId
    {
        string Scheme { get; }

        string Value { get; }
    }
}