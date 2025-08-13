using System.Text;

namespace EditorHtml;

public class Editor
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("MODO EDITOR");
        Console.WriteLine("-".PadRight(12, '-'));
        
        Start();
    }

    private static void Start()
    {
        var file = new StringBuilder();

        while (true)
        {
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
                break;

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                file.Append(Environment.NewLine);
                Console.WriteLine();
            }
            else
            {
                file.Append(keyInfo.KeyChar);
                Console.Write(keyInfo.KeyChar);
            }
        }
        
        Console.WriteLine();
        Console.WriteLine("-".PadRight(12, '-'));
        Console.WriteLine("Deseja salvar o arquivo? ");

        Viewer.Show(file.ToString());
    }
}