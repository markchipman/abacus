using Abacus.Enums;

namespace Abacus.Domain
{
    public class Currency : Enumeration<string>
    {
        public Currency(string id)
        {
            if (id == null)
            {
                throw new System.ArgumentNullException(nameof(id));
            }

            Id = id;
        }

        public override string Id { get; }
    }
}
