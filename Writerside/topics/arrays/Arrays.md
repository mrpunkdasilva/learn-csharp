# Arrays

Imagine uma fila de sete anões mineradores, prontos para o trabalho. Essa fila organizada é a nossa analogia para um **Array**.

Um array é uma estrutura de dados fundamental que armazena uma coleção de elementos. Para entender completamente, vamos observar as três regras de ouro da fila dos anões:

1.  **Todos são do Mesmo Tipo:** Na fila, só há anões. Você não pode colocar um elfo ou um dragão no meio. Em C#, isso significa que um array declarado para `int` só pode conter números inteiros. Um array de `string` só pode conter textos. Essa homogeneidade é uma regra estrita.
2.  **A Fila Tem Tamanho Fixo:** Se a fila foi formada com 7 anões, ela tem 7 posições. Você não pode simplesmente adicionar um oitavo anão ou remover um do meio e esperar que a fila encolha. O tamanho de um array é definido em sua criação e não pode ser alterado. Para isso, usamos outras estruturas como `List<T>`.
3.  **Posições Começam do Zero (Índice Baseado em Zero):** Esta é a regra mais importante! Para chamar um anão, você usa sua posição na fila, que **sempre começa em 0**. O primeiro anão está na posição `0`, o segundo na posição `1`, e o último anão (o sétimo) está na posição `6`. O endereço do último elemento é sempre `tamanho - 1`.

## Por Dentro da Memória: Por que Arrays são Rápidos?

Quando você cria um array, o computador aloca um **bloco contínuo de memória** para ele. Pense nisso como reservar um trecho de uma prateleira, onde cada espaço tem exatamente o mesmo tamanho e todos estão um ao lado do outro. 

Como todos os elementos são do mesmo tipo (e, portanto, têm o mesmo tamanho em bytes) e estão em sequência, o computador pode calcular a localização exata de qualquer elemento instantaneamente. Ele pega o endereço de memória do início do array e soma `(índice * tamanho_do_elemento)`. É por isso que acessar `meuArray[500]` é tão rápido quanto acessar `meuArray[0]`.

## Declarando e Inicializando Arrays

Existem algumas maneiras de formar a "fila de anões".

### 1. Declarar e Definir o Tamanho (Valores Padrão)

Você pode primeiro declarar que terá uma fila de anões e definir seu tamanho. Cada anão na fila começará com um valor padrão, pois o espaço na memória é alocado e "zerado".

```csharp
// Declare an array of integers that will have 5 positions.
// Each position is initialized with the default value for its type.
int[] numbers = new int[5]; // Creates [0, 0, 0, 0, 0]
```

**Valores Padrão Comuns:**
*   **Tipos numéricos (`int`, `double`, `decimal`):** `0`
*   **`bool`:** `false`
*   **`char`:** `'\0'` (caractere nulo)
*   **Tipos de referência (`string`, objetos):** `null`

### 2. Declarar e Inicializar com Valores

Você pode formar a fila e já definir quem estará em cada posição, tudo de uma vez.

```csharp
// Declare an array and provide the initial values immediately.
// The size of the array is automatically determined by the number of elements.
string[] dwarves = new string[] { "Dopey", "Grumpy", "Doc", "Happy" };

// A syntax shorter is also common
int[] scores = { 95, 80, 100, 75 };
```

## Acessando e Modificando Elementos

Para falar com um anão ou trocar sua ferramenta, usamos sua posição (índice) entre colchetes `[]`.

```csharp
string[] dwarves = { "Dopey", "Grumpy", "Doc", "Happy" };

// Accessing the dwarf at index 0 (the first one)
string firstDwarf = dwarves[0]; // firstDwarf will be "Dopey"

// Modifying the dwarf at index 1 (the second one)
dwarves[1] = "Sneezy"; // The array is now { "Dopey", "Sneezy", "Doc", "Happy" }
```

> **Alerta de Perigo: `IndexOutOfRangeException`**
> Se você tentar chamar um anão em uma posição que não existe (por exemplo, `dwarves[4]` em nossa fila de 4 anões), o programa irá parar e gritar um erro em tempo de execução: `IndexOutOfRangeException`. É o erro mais comum ao trabalhar com arrays.

## Percorrendo um Array (Iteração)

Para dar uma ordem a todos os anões na fila, usamos laços de repetição.

### O Laço `for` (Controle Total)

O laço `for` é o capataz que anda pela fila, sabendo a posição de cada anão. Ele lhe dá acesso ao índice, o que é útil se você precisar saber a posição do elemento.

```csharp
// We use the Length property to know the size of the line.
for (int i = 0; i < dwarves.Length; i++)
{
    // We use the index 'i' to access each dwarf.
    Console.WriteLine($"The dwarf at position {i} is {dwarves[i]}");
}
```

### O Laço `foreach` (Simples e Seguro)

O `foreach` é mais como um anúncio geral. Ele passa por cada anão da fila, um de cada vez, sem que você precise se preocupar com a posição. É mais simples e evita o risco de um `IndexOutOfRangeException`.

```csharp
// The loop iterates through each element in the array automatically.
foreach (string dwarf in dwarves)
{
    Console.WriteLine($"{dwarf} is going to the mine!");
}
```

## Indo Além: Arrays Multidimensionais

E se os anões se organizassem não em uma fila, mas em um pátio, formando um retângulo? Para isso, temos os arrays multidimensionais. O mais comum é o 2D, que se parece com um tabuleiro de xadrez ou uma planilha.

```csharp
// A 2D array, like a 2x3 grid.
int[,] gameBoard = new int[2, 3]; // 2 rows, 3 columns

// You can initialize it directly too
int[,] matrix = 
{
    { 1, 2, 3 },
    { 4, 5, 6 }
};

// To access an element, you need two indices: [row, column]
int element = matrix[1, 2]; // Accesses the element at row 1, column 2, which is 6.
```

## Referências

Para se aprofundar, a documentação oficial da Microsoft é o melhor recurso:

*   **[Guia de Programação de Arrays (C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/arrays/)**: O ponto de partida para tudo sobre arrays.
*   **[Arrays Multidimensionais](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/arrays/multidimensional-arrays)**: Guia específico para arrays com mais de uma dimensão.
*   **[Classe `System.Array`](https://learn.microsoft.com/pt-br/dotnet/api/system.array)**: Documentação da classe base para todos os arrays, mostrando métodos úteis que você pode usar (como `Sort`, `Reverse`, etc.).
