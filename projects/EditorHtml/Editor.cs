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
        Console.WriteLine("Deseja salvar o arquivo? (S/N)");
        var response = Console.ReadLine()?.ToUpper();

        if (response == "S")
        {
            Save(file.ToString());
        }
        else
        {
            Console.WriteLine("Deseja visualizar o arquivo? (S/N)");
            var viewResponse = Console.ReadLine()?.ToUpper();
            if (viewResponse == "S")
            {
                Viewer.Show(file.ToString());
            }
        }
        
        Menu.Show();
    }

    private static void Save(string text)
    {
        Console.Clear();
        Console.WriteLine("Qual o caminho para salvar o arquivo?");
        var path = Console.ReadLine();

        if (string.IsNullOrEmpty(path))
        {
            Console.WriteLine("Caminho inválido. O arquivo não foi salvo.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            return;
        }
        
        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }

        Console.WriteLine($"Arquivo {path} salvo com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}