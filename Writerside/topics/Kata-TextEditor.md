# Kata - Editor de Texto Simples de Console

Neste kata, construiremos uma aplicação de console fundamental: um editor de texto simples. Este projeto nos permitirá explorar a manipulação de arquivos em C#, uma habilidade essencial para qualquer desenvolvedor. A aplicação será capaz de criar, salvar e abrir arquivos de texto diretamente do terminal.

Vamos focar em conceitos como entrada e saída do console, leitura e escrita de arquivos com `StreamReader` and `StreamWriter`, e a importância do bloco `using` para gerenciar recursos de forma segura.

## O Código Completo

Este é o código do nosso `Program.cs`. Ele estrutura o editor de texto em um menu interativo.

```csharp
using System;
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
      Console.WriteLine("O que voce deseja fazer?");
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
          Menu();
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
```

## Análise do Código

### `Main` e `Menu`: Navegação Central

O ponto de entrada `Main` simplesmente chama o método `Menu`, que atua como o coração da nossa aplicação.

-   **`Console.Clear()`**: Limpa a tela do console para uma apresentação mais limpa.
-   **Loop de Menu**: O `Menu` exibe as opções, lê a entrada do usuário com `Console.ReadLine()` e usa uma instrução `switch` para direcionar o fluxo do programa. Note que, após cada ação (`Open`, `Edit`), o `Menu` é chamado novamente, criando um loop que mantém a aplicação em execução até que o usuário escolha sair.
-   **Saída Segura**: `System.Environment.Exit(0)` é usado para encerrar a aplicação de forma limpa quando o usuário digita '0'.

### `Open`: Lendo Arquivos

```csharp
private static void Open()
{
    // ...
    string path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }
    // ...
}
```

Esta função é responsável por abrir e exibir o conteúdo de um arquivo de texto.

-   **`StreamReader`**: Esta classe do `System.IO` é projetada para ler caracteres de um fluxo (neste caso, um arquivo).
-   **Bloco `using`**: Este é um dos conceitos mais importantes aqui. O `using` garante que o objeto `file` (que representa o arquivo no sistema operacional) seja "descartado" (`Dispose`) corretamente, mesmo que ocorram erros. Isso significa que o arquivo será fechado, liberando o recurso para outros programas. É a maneira padrão e segura de trabalhar com recursos como arquivos e conexões de rede.
-   **`ReadToEnd()`**: Lê todo o conteúdo do arquivo, do início ao fim, e o retorna como uma única `string`.

### `Edit` e `Save`: Criando e Escrevendo em Arquivos

O processo de criação é dividido em duas partes: `Edit` para capturar a entrada e `Save` para escrevê-la no disco.

```csharp
private static void Edit()
{
    // ...
    string text = "";
    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    } while (Console.ReadKey().Key != ConsoleKey.Escape);
    
    Save(text);
}
```

-   **Captura de Múltiplas Linhas**: O loop `do-while` é uma forma inteligente de capturar texto. Ele continua adicionando linhas à variável `text` até que a tecla `ESC` seja pressionada. `Console.ReadKey()` intercepta a próxima tecla pressionada sem exigir que o usuário pressione Enter.
-   **`Environment.NewLine`**: Garante que as quebras de linha sejam corretas para o sistema operacional em que o programa está sendo executado (seja `\n` no Linux/macOS ou `\r\n` no Windows).

```csharp
static void Save(string text) 
{
    // ...
    var path = Console.ReadLine();
    
    using (var file = new StreamWriter(path ?? string.Empty))
    {
        file.Write(text);
    }
    // ...
}
```

-   **`StreamWriter`**: O oposto do `StreamReader`, esta classe é usada para escrever strings em um fluxo/arquivo. Se o arquivo não existir no `path` especificado, ele será criado. Se já existir, seu conteúdo será **sobrescrito**.
-   **Segurança com `using`**: Assim como no `Open`, o `using` garante que o arquivo seja fechado e salvo corretamente após a escrita.

## Conceitos-Chave Aplicados

-   **Entrada e Saída do Console**: Uso intensivo de `Console.WriteLine`, `Console.ReadLine` e `Console.ReadKey` para criar uma interface de usuário interativa.
-   **Manipulação de Arquivos (`System.IO`)**: Utilização das classes `StreamReader` e `StreamWriter` para operações de leitura e escrita em arquivos.
-   **Gerenciamento de Recursos com `using`**: Aplicação da instrução `using` para garantir que os recursos do sistema (arquivos) sejam liberados de forma segura e automática.
-   **Estruturas de Controle**: Uso de `switch` para navegação no menu e `do-while` para captura de entrada de texto.
-   **Tratamento de Strings**: Concatenação de strings para construir o conteúdo do arquivo e uso de `Environment.NewLine` para compatibilidade entre sistemas operacionais.

## Como Executar

Para testar este programa, você precisa navegar até a pasta do projeto no seu terminal e usar o comando `dotnet run`:

```bash
# Navegue até o diretório do projeto
cd projects/TextEditor/TextEditor

# Execute a aplicação
dotnet run
```

A partir daí, o menu interativo irá guiá-lo para criar, abrir ou salvar seus arquivos de texto.
