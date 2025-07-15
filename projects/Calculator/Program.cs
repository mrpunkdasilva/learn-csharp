using System;

namespace Calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      Subtraction();
    }

    static void Sum()
    {
      Console.Clear();

      Console.WriteLine("First value: ");
      double v1 = double.Parse(Console.ReadLine());

      Console.WriteLine("Second value: ");
      double v2 = double.Parse(Console.ReadLine());

      double result = v1 + v2;

      Console.Clear();

      Console.WriteLine(" ========= Result ========");
      Console.WriteLine($" {v1} + {v2}  =  {result}");
    }

    static void Subtraction()
    {
      Console.Clear();
      
      Console.WriteLine("First value: ");
      double v1 = double.Parse(Console.ReadLine());
      
      Console.WriteLine("Second value: ");
      double v2 = double.Parse(Console.ReadLine());
      
      double result = v1 - v2;
      
      Console.Clear();
      Console.WriteLine(" ========= Result ========");
      Console.WriteLine($" {v1} - {v2}  =  {result}");
    }
  }
}