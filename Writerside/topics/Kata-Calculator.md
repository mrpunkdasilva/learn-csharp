
# Kata - Calculadora em C#

Bem-vindo ao nosso primeiro kata prático! Neste exercício, vamos construir uma calculadora simples usando C#. O objetivo é aplicar os conceitos fundamentais que aprendemos, como variáveis, tipos de dados, operadores, condicionais e funções, em um projeto real e funcional.

Este tutorial é voltado para iniciantes e explicará cada parte do código detalhadamente.

## O Código Completo

Aqui está o código completo do nosso arquivo `Program.cs`. Vamos analisá-lo passo a passo.

```csharp
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
```

## Análise do Código

### Estrutura Básica

- **`using System;`**: Esta linha importa o namespace `System`, que contém classes fundamentais e tipos de dados que usamos em quase todos os programas C#, como `Console`, `String`, `Double`, etc.

- **`namespace Calculator`**: Um `namespace` é usado para organizar o código e evitar conflitos de nomes. Aqui, estamos criando um namespace chamado `Calculator` para o nosso projeto.

- **`class Program`**: Em C#, todo o código executável deve estar dentro de uma classe. A classe `Program` é o contêiner principal para o nosso código.

- **`static void Main(string[] args)`**: Este é o ponto de entrada do nosso programa. Quando o aplicativo é executado, o método `Main` é o primeiro a ser chamado.
    - `static`: Significa que o método pertence à classe `Program` e não a uma instância específica dela.
    - `void`: Indica que o método não retorna nenhum valor.
    - `string[] args`: É um array de strings que pode ser usado para passar argumentos de linha de comando para o programa (não estamos usando neste kata).

### O Menu Principal (`Menu` function)

O coração da nossa aplicação é a função `Menu`. Ela é responsável por interagir com o usuário.

```csharp
static void Menu()
{
  Console.Clear();
  
  Console.WriteLine("O QUE DESEJA FAZER?");
  // ... (outras opções)

  Console.WriteLine("SELECIONE UMA OPÇÃO > ");
  short res = short.Parse(Console.ReadLine());
  
  switch(res)
  {
    // ...
  }
}
```

1.  **`Console.Clear()`**: Limpa a tela do console, proporcionando uma interface mais limpa a cada vez que o menu é exibido.

2.  **`Console.WriteLine(...)`**: Exibe as opções disponíveis para o usuário.

3.  **`Console.ReadLine()`**: Lê a entrada do usuário a partir do console. O valor lido é sempre uma `string`.

4.  **`short.Parse(...)`**: Como `ReadLine` retorna uma `string`, precisamos convertê-la para um tipo numérico para podermos usá-la em nossa lógica. `short.Parse` converte a string de entrada em um `short` (um tipo de número inteiro).

5.  **`switch(res)`**: A estrutura `switch` é uma forma de controle de fluxo que permite executar diferentes blocos de código com base no valor de uma variável. É uma alternativa mais limpa a múltiplos `if-else if`.
    - **`case X:`**: Cada `case` corresponde a um valor possível da variável `res`. Se `res` for `1`, o código dentro de `case 1:` será executado.
    - **`break;`**: A palavra-chave `break` é usada para sair do `switch` após a execução de um `case`.
    - **`default:`**: Se o valor de `res` não corresponder a nenhum dos `case`, o bloco `default` será executado. Em nosso caso, ele simplesmente chama o `Menu()` novamente.
    - **`System.Environment.Exit(0);`**: No `case 5`, usamos este comando para encerrar a aplicação. O `0` indica que o programa terminou com sucesso.

### Funções de Operação (Sum, Subtraction, etc.)

Todas as funções de operação seguem um padrão semelhante. Vamos analisar a função `Sum()`:

```csharp
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
```

1.  **`Console.Clear()`**: Limpa a tela para a nova "página" da operação.

2.  **`double.Parse(Console.ReadLine())`**: Novamente, lemos a entrada do usuário e a convertemos. Desta vez, usamos `double.Parse` porque queremos trabalhar com números que podem ter casas decimais.

3.  **`double result = v1 + v2;`**: Aqui está a lógica principal da função. Realizamos a soma dos dois números e armazenamos o resultado na variável `result`.

4.  **`Console.WriteLine($" {v1} + {v2}  =  {result}");`**: Esta é uma *string interpolada*. O `$` no início da string nos permite incorporar variáveis diretamente no texto usando chaves `{}`. É uma forma moderna e legível de formatar strings.

5.  **`Console.ReadKey()`**: Pausa a execução do programa e espera que o usuário pressione qualquer tecla. Isso é útil para que o usuário possa ver o resultado antes que o programa limpe a tela e volte ao menu.

6.  **`Menu()`**: Após a operação ser concluída e o usuário pressionar uma tecla, chamamos a função `Menu()` novamente, criando um loop que permite ao usuário realizar outra operação ou sair.

## Conceitos-Chave Aplicados

- **Funções**: Organizamos nosso código em funções reutilizáveis (`Menu`, `Sum`, `Subtraction`, etc.), tornando o código mais limpo e fácil de manter.
- **Tipos de Dados**: Usamos `short` para a opção do menu e `double` para os valores dos cálculos, escolhendo os tipos apropriados para cada tarefa.
- **Conversão de Tipos (Parsing)**: Convertemos a entrada do usuário de `string` para tipos numéricos usando `short.Parse` and `double.Parse`.
- **Controle de Fluxo**: Usamos a estrutura `switch` para tomar decisões com base na entrada do usuário.
- **Entrada e Saída**: Utilizamos a classe `Console` para interagir com o usuário, exibindo informações (`WriteLine`) e lendo dados (`ReadLine`).
- **Recursão (Leve)**: A função `Menu` chama a si mesma no `default` do `switch`, e as funções de operação chamam `Menu` no final. Isso cria um ciclo de vida para a aplicação.

## Desafios para Expansão

Agora que você entende o código, aqui estão alguns desafios para você tentar:

1.  **Adicionar Potenciação**: Crie uma nova opção no menu e uma função `Power()` que calcula `v1` elevado a `v2`. (Dica: você pode usar `Math.Pow(v1, v2)`).
2.  **Tratamento de Erros**: O que acontece se o usuário digitar "abc" em vez de um número? O programa irá quebrar. Pesquise sobre `try-catch` em C# para lidar com essas exceções e exibir uma mensagem de erro amigável.
3.  **Raiz Quadrada**: Adicione uma opção para calcular a raiz quadrada de um número. (Dica: `Math.Sqrt(v1)`).
4.  **Histórico de Operações**: Como você poderia armazenar e exibir as últimas 5 operações que o usuário realizou?

Parabéns por concluir este kata! Você deu um passo importante na sua jornada de aprendizado de C#.
