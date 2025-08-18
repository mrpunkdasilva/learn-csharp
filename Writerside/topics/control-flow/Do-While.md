# Laço de Repetição do-while

O laço `do-while` é uma variação do laço `while`. A principal e mais importante diferença é que o `do-while` **garante que o bloco de código seja executado pelo menos uma vez**.

Isso ocorre porque a condição booleana é verificada **ao final** de cada iteração, e não no início.

## Sintaxe

A sintaxe do `do-while` reflete essa característica: o bloco `do` vem antes da verificação `while`.

```c#
do
{
    // Bloco de código a ser executado
} while (condição);
```

*   **`do { ... }`**: O bloco de código que será executado.
*   **`while (condição)`**: A expressão booleana que é avaliada no final de cada iteração. Se for `true`, o laço continua; se for `false`, ele termina. Note o ponto e vírgula obrigatório no final.

### Exemplo Prático

O `do-while` é especialmente útil para menus de opções ou para validar a entrada do usuário, onde você precisa executar a ação (mostrar o menu, pedir a entrada) pelo menos uma vez.

Neste exemplo, o programa pede ao usuário para inserir um número entre 1 e 10. O laço continuará até que uma entrada válida seja fornecida.

```c#
int numero;
do
{
    Console.Write("Digite um número entre 1 e 10: ");
    string entrada = Console.ReadLine();
    // Tenta converter a entrada para um inteiro.
    // int.TryParse retorna true se a conversão for bem-sucedida.
    int.TryParse(entrada, out numero);

    if (numero < 1 || numero > 10)
    {
        Console.WriteLine("Entrada inválida. Tente novamente.");
    }

} while (numero < 1 || numero > 10);

Console.WriteLine($"Ótimo! Você digitou o número válido: {numero}");
```

**Análise do Exemplo:**

1.  O bloco `do` é executado imediatamente. O programa solicita um número sem qualquer verificação prévia.
2.  A entrada do usuário é lida e o programa tenta convertê-la para um inteiro.
3.  Ao final do bloco, a condição `while (numero < 1 || numero > 10)` é verificada.
4.  Se o número estiver fora do intervalo desejado (ou se `TryParse` falhar, deixando `numero` como `0`), a condição será `true`, e o laço se repetirá.
5.  O laço só termina quando o usuário digita um número válido entre 1 e 10.

## `while` vs. `do-while`: Qual Usar?

*   Use **`while`** quando você não tem certeza se o laço precisa ser executado. A execução depende inteiramente da condição inicial.
    *   *Exemplo: Processar itens em uma lista. Se a lista estiver vazia, o laço não executa.*
*   Use **`do-while`** quando você precisa que o corpo do laço seja executado **pelo menos uma vez**, independentemente da condição.
    *   *Exemplo: Apresentar um menu de opções ao usuário. O menu deve ser exibido antes que o usuário possa fazer uma escolha.*
