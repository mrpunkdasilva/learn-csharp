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
    var words = text.Split(' ');

    for (int i = 0; i < words.Length; i++)
    {
      if (strong.IsMatch(words[i]))
      {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(
            words[i].Substring(
                words[i].IndexOf('>') + 1,
                (words[i].LastIndexOf('<') - 1) - words[i].LastIndexOf('>')
              )
          );
        Console.Write(" ");
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(words[i]);
        Console.Write(" ");
      }
    }
  }
}