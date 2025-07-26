using System;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto  => 1m  = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string data = Console.ReadLine().ToLower();
            int multiplier = 1;
            char type = char.Parse(data.Substring(data.Length - 1, 1).ToLower());
            int time = int.Parse(data.Substring(0, data.Length - 1));

            if (type == 'm')
                multiplier = 60;

            if (time == 0)
                System.Environment.Exit(0);

            PreStart(time * multiplier);
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(1500);
            Start(time);
        }

        static void Start(int time)
        {
            int currentTime = 0;

            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                System.Threading.Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalized");
            System.Threading.Thread.Sleep(2500);
            Menu();
        }
    }
}
