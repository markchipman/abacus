using System;

namespace Abacus.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Write something:");
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(input);
            }
        }
    }
}
