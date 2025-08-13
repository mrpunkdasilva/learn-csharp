using System.Text.RegularExpressions;

namespace EditorHtml;

public class Viewer
{
  public static void Show(String text)
  {
    Console.Clear();
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.WriteLine("MODO DE VISUALIZAÇÃO");
    Console.WriteLine("-".PadRight(12, '-'));
    Replace(text);
    Console.WriteLine("-".PadRight(12, '-'));
    Console.ReadKey();
    Menu.Show();
  }

  private static void Replace(string text)
  {
    var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");

    Console.WriteLine(strong.IsMatch(text));
  }
}