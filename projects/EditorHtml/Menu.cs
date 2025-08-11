using System;
using System.Text;

namespace EditorHtml
{
  public static class Menu
  {
    public static void Show()
    {
      Console.Clear();
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.White;

      DrawScreen();
      WriteOptions();

      var option = short.Parse(Console.ReadLine());
    }

    public static void WriteOptions()
    {
      Console.SetCursorPosition(3, 2);
      
      System.Console.WriteLine("EDITOR HTML");
      Console.SetCursorPosition(3, 3);
      System.Console.WriteLine("=".PadRight(16, '='));
      Console.SetCursorPosition(3, 4);
      System.Console.WriteLine("Selecione uma das opções:");
      Console.SetCursorPosition(3, 6);
      System.Console.WriteLine("1 - Novo Arquivo");
      Console.SetCursorPosition(3, 7);
      System.Console.WriteLine("2 - Abrir arquivo");
      Console.SetCursorPosition(3, 9);
      System.Console.WriteLine("0 - Sair");
      Console.SetCursorPosition(3, 10);
      System.Console.Write("Opção >> ");
    }

    static void DrawScreen()
    {
      DrawBorderLine();
      
      for (int i = 0; i <= 10; i++)
      {
        Console.Write("|");
        for (int j = 0; j <= 30; j++)
        {
          Console.Write(" ");
        }

        Console.Write("|");
        Console.Write("\n");
      }

      DrawBorderLine();
    }
    private static void DrawBorderLine()
    {
      StringBuilder headerLine = new StringBuilder("+".PadRight(32, '-')).Append("+").Append("\n"); 
      System.Console.Write(headerLine);
    }
  }
}