using System.IO;

namespace TextEditor
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Menu();
    }

    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("1 - Abrir arquivo");
      Console.WriteLine("2 - Criar novo arquivo");
      Console.WriteLine("0 - Sair");
      short option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 0:
          System.Environment.Exit(0);
          break;
        case 1:
          Open();
          break;
        case 2:
          Edit();
          break;
        default:
          Console.WriteLine("Opção não encontrada");
          break;
      }
    }

    private static void Open()
    {
      Console.Clear();
      Console.WriteLine("Qual caminho do arquivo?");
      string path = Console.ReadLine();

      using (var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
      }
      
      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }

    private static void Edit()
    {
      Console.Clear();
      Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
      Console.WriteLine("--------------------------------");

      string text = "";

      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      } while (Console.ReadKey().Key != ConsoleKey.Escape);
      
      Save(text);
    }
    
    static void Save(string text) 
    {
      Console.Clear();
      Console.WriteLine("Qual caminho para salvar o arquivo? \n");
      var path = Console.ReadLine();
      
      
      // CRIA E JÁ FECHA O OBJETO - É BOM PARA HANDLER COM ARQUIVOS
      using (var file = new StreamWriter(path ?? string.Empty))
      {
        file.Write(text);
      }

      Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
      Console.ReadLine(); 
      Menu();
    }
  }
}