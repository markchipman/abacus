using System;
using Abacus.Core.Resolvable;
using Abacus.Pricing.Instrument;

namespace Abacus.CLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var bond = new FixedCouponBond();
            Console.WriteLine("Have bond: {0}", bond);

            var bondModel = Resolve(bond);
            Console.WriteLine("Have bond model: {0}", bondModel);

            Console.WriteLine();
            Console.WriteLine("Press RETURN to exit.");
            Console.ReadLine();
        }

        private static T Resolve<T>(IResolvable<T> resolvable)
        {
            return resolvable.Resolve(null);
        }
    }
}
