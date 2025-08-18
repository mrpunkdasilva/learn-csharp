# Percorrendo Arrays (Iteração)

## O que é Iteração?

Antes de vermos as ferramentas, vamos entender o conceito. **Iteração** (do latim *iterare*, que significa "repetir, fazer de novo") é simplesmente o ato de repetir um processo para cada item de uma coleção, um de cada vez e em sequência.

Usando nossa analogia, a iteração é o próprio ato de o capataz andar pela fila, do primeiro ao último anão, para inspecionar a picareta de cada um. O processo de ir de anão em anão é a **iteração**. As diferentes maneiras como ele pode fazer isso (usando uma prancheta, um alto-falante, etc.) são os diferentes **laços de iteração** (`for`, `foreach`, etc.) que usamos no código.

Agora, vamos ver as ferramentas que o C# nos dá para realizar a iteração em arrays.

## O Laço `for`: O Capataz com a Prancheta

O laço `for` é como um capataz que anda pela fila dos anões com uma prancheta. Ele é metódico e tem controle total sobre o processo.

Ele controla três coisas:
1.  **Inicialização (`int i = 0`):** Ele começa na posição 0, o primeiro anão.
2.  **Condição (`i < anoes.Length`):** Ele continua enquanto sua posição atual for menor que o tamanho total da fila.
3.  **Incremento (`i++`):** Após falar com um anão, ele passa para o próximo.

O capataz sempre sabe a posição exata (`i`) do anão com quem está falando. Isso é extremamente útil.

**Vantagens:**
*   Você tem acesso ao **índice** do elemento.
*   Você pode **modificar** o array diretamente.
*   Você pode controlar a iteração: pular elementos, ir de trás para frente, etc.

```csharp
string[] dwarves = { "Dopey", "Grumpy", "Doc", "Happy", "Sneezy" };

// The 'for' loop gives us access to the index 'i'
for (int i = 0; i < dwarves.Length; i++)
{
    // We can use the index to get the element and do something with it
    Console.WriteLine($"The dwarf at position {i} is {dwarves[i]}. Give him a pickaxe!");
    
    // We can also modify the array
    if (dwarves[i] == "Grumpy")
    {
        dwarves[i] = "Cheerful"; // Grumpy is now Cheerful
    }
}
```

## O Laço `foreach`: O Anúncio Geral

O laço `foreach` é como fazer um anúncio geral pelo alto-falante para todos os anões. Cada anão, um por um, escuta a mensagem e faz o que foi pedido. É mais simples e direto, mas menos pessoal.

Você não sabe a posição exata de cada anão, apenas que todos eles receberão a instrução.

**Vantagens:**
*   **Mais simples e legível:** Menos código para escrever.
*   **Mais seguro:** É impossível causar um erro de `IndexOutOfRangeException` com um `foreach`.

**Limitações:**
*   Você não tem acesso ao índice do elemento.
*   Você não pode modificar o array diretamente (para tipos de valor como `int`, a variável de iteração é uma cópia).

```csharp
int[] numbers = { 10, 20, 30, 40, 50 };

// The 'foreach' loop handles getting each element automatically
foreach (int number in numbers)
{
    // 'number' holds the value of the current element
    Console.WriteLine($"The current number is {number}");
    
    // Trying to change the value like this will NOT change the array itself,
    // because 'number' is a copy of the element, not a reference to it.
    // number = 100; // This line would not affect the 'numbers' array.
}
```

## O Laço `while`: O Guarda Manual

O laço `while` é como um guarda que controla a fila manualmente. Ele verifica uma condição e, se for verdadeira, deixa um anão passar e depois decide o que fazer a seguir. Ele é o mais flexível, mas também exige mais cuidado.

Você precisa controlar manualmente o avanço na fila. Se esquecer de incrementar o contador, o guarda ficará preso no mesmo anão para sempre (um **laço infinito**).

É menos comum para percorrer um array inteiro, mas útil se você precisar parar a iteração com base em uma condição que não seja apenas o tamanho do array.

```csharp
string[] dwarves = { "Dopey", "Grumpy", "Doc", "Happy", "Sneezy" };
int i = 0; // Manual counter

// The loop will continue as long as we haven't reached the end
// AND we haven't found the dwarf named "Doc".
while (i < dwarves.Length && dwarves[i] != "Doc")
{
    Console.WriteLine($"{dwarves[i]} is not Doc. Next!");
    i++; // Manually move to the next position. CRITICAL!
}

if (i < dwarves.Length)
{
    Console.WriteLine($"Found Doc at position {i}!");
}
```

## Qual Laço Usar? A Regra de Bolso

*   **Precisa do índice? Precisa modificar o array? Precisa de controle total (ir para trás, pular)?**
    *   Use o laço `for`.

*   **Só precisa ler os valores de cada elemento, de forma simples e segura?**
    *   Use o laço `foreach`. (Esta é a escolha mais comum para leitura).

*   **A condição para parar é complexa e não depende apenas de percorrer o array inteiro?**
    *   Use o laço `while`.

## Referências

*   **[O laço `for` (Guia de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/statements/for)**
*   **[O laço `foreach` (Guia de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/statements/iteration-statements#the-foreach-statement)**
*   **[O laço `while` (Guia de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement)**
