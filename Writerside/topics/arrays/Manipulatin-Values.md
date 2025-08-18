# Manipulando Valores em Arrays

Nossa fila de anões (nosso array) não é estática. Uma vez formada, muitas vezes precisamos alterar seus elementos. Podemos precisar trocar a ferramenta de um anão, atualizar o status de todos ou mudar o nome de um deles. Esse processo de alterar os dados dentro de um array é uma das operações mais fundamentais na programação.

Vamos ver as principais maneiras de manipular os valores em um array.

## 1. Alteração Direta por Índice

A forma mais simples e rápida de alterar um valor é quando você sabe exatamente a **posição (o índice)** do elemento que deseja modificar. É como chamar o anão pelo número de sua posição na fila e lhe dar uma nova ferramenta diretamente.

```csharp
// Our line of dwarves
string[] dwarves = { "Dopey", "Grumpy", "Doc", "Happy" };

// We know that Grumpy is at index 1. Let's change his name.
Console.WriteLine($"Before change: {dwarves[1]}");

dwarves[1] = "Cheerful"; // Direct assignment to the element at index 1

Console.WriteLine($"After change: {dwarves[1]}");

// The array is now: { "Dopey", "Cheerful", "Doc", "Happy" }
```

## 2. Encontrar e Alterar um Valor

Mais comumente, você não saberá a posição exata do elemento, mas saberá seu valor atual. O padrão, nesse caso, é:
1.  **Percorrer** o array para encontrar o elemento.
2.  **Verificar** se o elemento atual é o que você procura.
3.  Se for, **usar seu índice para alterá-lo**.

Para isso, o laço `for` é a ferramenta ideal, pois ele nos dá o índice (`i`) de que precisamos para a modificação.

```csharp
int[] scores = { 50, 88, 42, 95, 70 };

// Task: Find the score 42 and replace it with 60.
for (int i = 0; i < scores.Length; i++)
{
    // Check if the current element is the one we're looking for
    if (scores[i] == 42)
    {
        // Use the index 'i' to modify the value
        scores[i] = 60;
        Console.WriteLine("Found and updated the score.");
        break; // Exit the loop since we found what we were looking for
    }
}

// The array is now: { 50, 88, 60, 95, 70 }
```

## 3. Alterando Múltiplos Valores com um Laço

E se precisarmos aplicar uma mesma mudança a todos os elementos? Por exemplo, dar um bônus de 5 pontos para todos os anões ou converter todos os nomes para letras maiúsculas. Novamente, um laço `for` é a escolha perfeita.

```csharp
int[] scores = { 50, 88, 42, 95, 70 };

// Task: Give a 5-point bonus to every score.
for (int i = 0; i < scores.Length; i++)
{
    scores[i] = scores[i] + 5; // Or using the shorthand: scores[i] += 5;
}

// The array is now: { 55, 93, 47, 100, 75 }
Console.WriteLine(string.Join(", ", scores));
```

## Cuidado: Tipos de Valor vs. Tipos de Referência

Como vimos nos outros tópicos, é crucial lembrar dessa diferença ao manipular dados.

*   **Tipos de Valor (`int`, `bool`):** A alteração com `for` funciona perfeitamente, pois estamos acessando a posição de memória do array diretamente e colocando um novo valor lá.

*   **Tipos de Referência (Objetos):** Ao acessar um elemento de um array de objetos, estamos obtendo uma referência para o objeto. Podemos usar essa referência para alterar as **propriedades** do objeto.

```csharp
public class Dwarf { public string Name { get; set; } public bool IsHappy { get; set; } }

Dwarf[] dwarves = { 
    new Dwarf { Name = "Grumpy", IsHappy = false },
    new Dwarf { Name = "Doc", IsHappy = false }
};

// Task: Make all dwarves happy.
for (int i = 0; i < dwarves.Length; i++)
{
    // dwarves[i] gives us the reference to the Dwarf object.
    // We use that reference to change a property of that object.
    dwarves[i].IsHappy = true;
}

// Now, if we check the first dwarf...
Console.WriteLine($"Is Grumpy happy? {dwarves[0].IsHappy}"); // Outputs: True
```

## Conclusão

Manipular valores em arrays se resume a duas técnicas principais:
1.  **Acesso Direto:** Use `array[indice] = novoValor;` quando souber a posição.
2.  **Iteração com `for`:** Use um laço `for` para encontrar elementos ou aplicar uma modificação em massa, pois ele fornece o índice necessário para a alteração.

Dominar essas técnicas é essencial para fazer seus programas realizarem tarefas úteis e dinâmicas.

## Referências

Os conceitos neste tópico são uma aplicação prática do que foi visto nos documentos anteriores. É recomendado revisá-los:

*   **[Introdução Detalhada aos Arrays](Arrays.md)**
*   **[Percorrendo Arrays (Iteração)](Iteration.md)**