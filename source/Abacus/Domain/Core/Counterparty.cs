using Abacus.Enums;

namespace Abacus.Domain
{
    public class Counterparty : Enumeration<int>
    {
        public static readonly Counterparty DummyCounterparty = new Counterparty(-1);

        public Counterparty(int id)
            : base(id)
        {
        }
    }
}
