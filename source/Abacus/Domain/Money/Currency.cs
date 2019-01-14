using Abacus.Enums;

namespace Abacus.Domain
{
    public class Currency : Enumeration<string>
    {
        public Currency(string id)
            : base(id)
        {
        }
    }
}
