namespace Abacus.Common.Enums
{
    public abstract class Enumeration<TId>
    {
        protected Enumeration(TId id)
        {
            Id = id;
        }

        public TId Id { get; private set; }
    }
}
