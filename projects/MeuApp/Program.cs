using System;

namespace MeuApp
{
    // Main class
    class Program
    {
        static void Main(string[] args)
        {
            var id = Guid.NewGuid();
            System.Console.WriteLine("" + id);
        }
    }
}
