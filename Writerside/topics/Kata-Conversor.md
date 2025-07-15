
# Kata - Conversor de Tipos via Linha de Comando

Neste kata, vamos explorar um caso de uso um pouco mais avançado: a criação de uma ferramenta de linha de comando (CLI) em C#. Esta aplicação irá converter um valor de um tipo de dado para outro, com base nos argumentos fornecidos pelo usuário ao executar o programa.

Vamos abordar conceitos como manipulação de argumentos de linha de comando, dicionários para armazenar parâmetros, tratamento de erros robusto com `try-catch` e a diferença crucial entre `Parse` e `Convert`.

## O Código Completo

Este é o código do nosso `Program.cs`. Ele é projetado para ser executado via `dotnet run` com parâmetros específicos.

```csharp
using System;
using System.Collections.Generic;

namespace AtividadeSemana1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            var parameters = ParseArguments(args);

            if (!ValidateParameters(parameters))
            {
                Console.WriteLine("Erro: Parametros 'valor', 'tipoEntrada' e 'tipoSaida' sao obrigatorios.");
                Console.WriteLine("Uso: dotnet run valor=<valor> tipoEntrada=<tipo> tipoSaida=<tipo>");
                return;
            }

            string valorStr = parameters["valor"];
            string tipoEntrada = parameters["tipoentrada"].ToLower();
            string tipoSaida = parameters["tiposaida"].ToLower();

            try
            {
                object valorEntrada = ParseInputValue(valorStr, tipoEntrada);
                object valorSaida = ConvertValue(valorEntrada, tipoSaida, valorStr);
                PrintResult(valorStr, tipoEntrada, valorSaida, tipoSaida);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Erro de conversao: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("=== Conversor de Tipos ===");
            Console.WriteLine("Por favor, forneca os parametros no formato chave=valor.");
            Console.WriteLine("Uso: dotnet run valor=<valor> tipoEntrada=<tipo> tipoSaida=<tipo>");
            Console.WriteLine("Exemplo: dotnet run valor=123.45 tipoEntrada=double tipoSaida=int");
            Console.WriteLine("Tipos suportados: int, double, float, bool, string, short");
        }

        static Dictionary<string, string> ParseArguments(string[] args)
        {
            var parameters = new Dictionary<string, string>();
            foreach (var arg in args)
            {
                var parts = arg.Split('=', 2);
                if (parts.Length == 2)
                {
                    parameters[parts[0].ToLower()] = parts[1];
                }
            }
            return parameters;
        }

        static bool ValidateParameters(Dictionary<string, string> parameters)
        {
            return parameters.ContainsKey("valor") &&
                   parameters.ContainsKey("tipoentrada") &&
                   parameters.ContainsKey("tiposaida");
        }

        
        static object ParseInputValue(string valorStr, string tipoEntrada)
        {
            try
            {
                return tipoEntrada switch
                {
                    "int" => int.Parse(valorStr),
                    "double" => double.Parse(valorStr),
                    "float" => float.Parse(valorStr),
                    "bool" => bool.Parse(valorStr),
                    "string" => valorStr,
                    "short" => short.Parse(valorStr),
                    _ => throw new ArgumentException($"Tipo de entrada desconhecido: {tipoEntrada}")
                };
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ao processar o valor de entrada '{valorStr}': {ex.Message}", ex);
            }
        }

        static object ConvertValue(object valorEntrada, string tipoSaida, string valorStr)
        {
            try
            {
                return tipoSaida switch
                {
                    "int" => Convert.ToInt32(valorEntrada),
                    "double" => Convert.ToDouble(valorEntrada),
                    "float" => Convert.ToSingle(valorEntrada),
                    "bool" => Convert.ToBoolean(valorEntrada),
                    "string" => Convert.ToString(valorEntrada),
                    "short" => Convert.ToInt16(valorEntrada),
                    _ => throw new ArgumentException($"Tipo de saida desconhecido: {tipoSaida}")
                };
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"Nao foi possivel converter '{valorStr}' ({valorEntrada.GetType().Name}) para {tipoSaida}: {ex.Message}", ex);
            }
        }

        static void PrintResult(string valorStr, string tipoEntrada, object valorSaida, string tipoSaida)
        {
            Console.WriteLine("=== Resultado da Conversao ===" elytra.platform.documentation.core.content.format.MarkdownFile@527144b2);
            Console.WriteLine($"Entrada: [{valorStr}] ({tipoEntrada})");
            Console.WriteLine($"Saida:   [{valorSaida}] ({tipoSaida})");
        }
    }
}
```

## Análise do Código

### `Main`: O Ponto de Entrada e Orquestrador

O método `Main` agora tem mais responsabilidades:

1.  **Verificar Argumentos**: `if (args.Length == 0)` checa se o programa foi executado sem nenhum argumento. Se for o caso, exibe uma mensagem de ajuda (`ShowHelp()`) e encerra.
2.  **Analisar Argumentos**: `ParseArguments(args)` é chamado para processar os argumentos da linha de comando.
3.  **Validar Parâmetros**: `ValidateParameters(parameters)` garante que todos os parâmetros necessários (`valor`, `tipoEntrada`, `tipoSaida`) foram fornecidos.
4.  **Executar a Conversão**: O bloco `try-catch` é o núcleo da lógica. Ele tenta analisar o valor de entrada, convertê-lo para o tipo de saída e imprimir o resultado. Se qualquer etapa falhar, uma exceção é capturada e uma mensagem de erro é exibida.

### `ParseArguments`: Processando a Entrada do Usuário

```csharp
static Dictionary<string, string> ParseArguments(string[] args)
{
    var parameters = new Dictionary<string, string>();
    foreach (var arg in args)
    {
        var parts = arg.Split('=', 2);
        if (parts.Length == 2)
        {
            parameters[parts[0].ToLower()] = parts[1];
        }
    }
    return parameters;
}
```

Esta função transforma um array de strings como `["valor=123", "tipoEntrada=int"]` em um `Dictionary<string, string>`. Um dicionário é uma coleção de pares chave-valor.

-   `arg.Split('=', 2)`: Divide cada argumento no caractere `=`, no máximo em 2 partes. Isso garante que, se o valor contiver um `=`, ele não será dividido novamente (ex: `valor=chave=valor`).
-   `parameters[parts[0].ToLower()] = parts[1]`: Adiciona a chave (em minúsculas) e o valor ao dicionário.

### `ParseInputValue` vs. `ConvertValue`

O programa usa duas funções distintas para a conversão, e a diferença é fundamental:

1.  **`ParseInputValue`**: Usa métodos como `int.Parse(string)`. O objetivo do `Parse` é converter uma **representação em string** de um valor para o seu tipo de dado correspondente. Ele só funciona de `string` para outro tipo.

2.  **`ConvertValue`**: Usa a classe `Convert`, com métodos como `Convert.ToInt32(object)`. A classe `Convert` é mais flexível. Ela pode converter um valor de **qualquer tipo base** para outro tipo, desde que uma conversão válida exista. Por exemplo, pode converter um `double` para um `int`, um `bool` para uma `string`, etc.

Em nosso fluxo, primeiro usamos `Parse` para tirar o valor da `string` inicial e, em seguida, usamos `Convert` para realizar a conversão entre os tipos de dados reais (ex: de `double` para `int`).

Ambas as funções usam uma **expressão `switch`** (uma forma mais concisa do `switch` tradicional) para selecionar a operação correta com base no tipo de entrada/saída.

### Tratamento de Erros (`try-catch`)

Este programa é muito mais robusto que a calculadora porque ele antecipa falhas.

-   **`try { ... }`**: O código que pode gerar um erro é colocado dentro do bloco `try`.
-   **`catch (ArgumentException ex)`**: Captura erros relacionados a argumentos inválidos, como um tipo de entrada/saída desconhecido.
-   **`catch (InvalidCastException ex)`**: Captura erros que ocorrem quando a conversão entre dois tipos não é possível (por exemplo, converter a string `"abc"` para `int`).
-   **`catch (Exception ex)`**: Uma cláusula genérica que captura qualquer outro erro inesperado, evitando que o programa "quebre" abruptamente.

## Conceitos-Chave Aplicados

-   **Argumentos de Linha de Comando**: Leitura e processamento de `string[] args` no método `Main`.
-   **Dicionários (`Dictionary<TKey, TValue>`)**: Uma estrutura de dados poderosa para armazenar e acessar dados por meio de uma chave única.
-   **Tratamento de Exceções**: Uso de `try-catch` para criar um programa resiliente que lida com entradas inválidas e erros de conversão.
-   **Expressões `switch`**: Uma sintaxe moderna e concisa para controle de fluxo.
-   **Diferença entre `Parse` e `Convert`**: Compreensão de duas maneiras fundamentais de realizar conversões de tipo em C#.

## Como Executar

Para testar este programa, você o executaria a partir do seu terminal, na pasta do projeto, da seguinte forma:

```bash
# Exemplo 1: Convertendo um double para um int
dotnet run valor=123.45 tipoEntrada=double tipoSaida=int

# Exemplo 2: Convertendo uma string para um booleano
dotnet run valor=true tipoEntrada=string tipoSaida=bool

# Exemplo de erro
dotnet run valor=texto tipoEntrada=string tipoSaida=int
```

Este kata demonstra como construir aplicações de console interativas e robustas, um pilar fundamental da programação em muitas linguagens, incluindo C#.
