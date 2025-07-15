using System;

namespace Calculator
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
      
      Console.WriteLine("O QUE DESEJA FAZER?");
      Console.WriteLine("---------------------");
      Console.WriteLine("1 - Soma");
      Console.WriteLine("2 - Subtração");
      Console.WriteLine("3 - Divisão");
      Console.WriteLine("4 - Multiplicação");
      Console.WriteLine("5 - Sair");

      Console.WriteLine("---------=-=-=-=-=--");
      Console.WriteLine("SELECIONE UMA OPÇÃO > ");
      short res = short.Parse(Console.ReadLine());
      
      switch(res)
      {
        case 1:
          Sum(); break;
        case 2:
          Subtraction(); break;
        case 3:
          Division(); break;
        case 4:
          Multiplication(); break;
        case 5:
          System.Environment.Exit(0);
          break;
        default:
          Menu();
          break;
      }
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
      Console.ReadKey();
      Menu();
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
      Console.ReadKey();
      Menu();
    }

    static void Division()
    {
      Console.Clear();

      Console.WriteLine("First value: ");
      double v1 = double.Parse(Console.ReadLine());

      Console.WriteLine("Second value: ");
      double v2 = double.Parse(Console.ReadLine());

      double result = v1 / v2;

      Console.Clear();
      Console.WriteLine(" ========= Result ========");
      Console.WriteLine($" {v1} / {v2}  =  {result}");
      Console.ReadKey();
      Menu();
    }

    static void Multiplication()
    {
      Console.Clear();
      Console.WriteLine("First value: ");
      double v1 = double.Parse(Console.ReadLine());

      Console.WriteLine("Second value: ");
      double v2 = double.Parse(Console.ReadLine());

      double result = v1 * v2;

      Console.Clear();
      Console.WriteLine(" ========= Result ========");
      Console.WriteLine($" {v1} x {v2}  =  {result}");
      Console.ReadKey();
      Menu();
    }
  }
}