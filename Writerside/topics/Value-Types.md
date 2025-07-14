# Tipos de Valor (Value Types)

No C#, todo tipo é classificado como um **tipo de valor** ou um **tipo de referência**. Entender a diferença é fundamental para prever o comportamento do seu código e gerenciar a memória de forma eficiente.

Tipos de valor são aqueles cujas variáveis **contêm diretamente o seu dado**. A variável e o valor são uma coisa só.

## Como Funciona a Memória?

Tipos de valor são, na maioria das vezes, armazenados em uma área da memória chamada **Stack (Pilha)**. A Stack é uma estrutura de dados altamente eficiente, do tipo LIFO (Last-In, First-Out), que gerencia a memória de forma muito rápida. Quando uma variável de tipo de valor é declarada dentro de um método, um espaço é alocado na Stack para armazenar seu valor.

### Diagrama: Variável na Stack

Imagine a Stack como uma pilha de caixas. Cada vez que você declara uma variável, uma nova caixa é colocada no topo, contendo o valor.

```text
      STACK
+------------------+
|                  |  <-- Topo da Stack
+------------------+
|   idade = 30     |
+------------------+
|   saldo = 150.75 |
+------------------+
| ...outras vars...|
+------------------+
```

## Comportamento na Atribuição

Esta é a característica mais importante dos tipos de valor. Quando você atribui uma variável de tipo de valor a outra, o valor é **copiado**. O resultado são duas variáveis completamente **independentes**, cada uma com sua própria cópia do dado.

### Exemplo de Código

```c#
// 1. 'a' é criado na Stack com o valor 10.
int a = 10;

// 2. O valor de 'a' é COPIADO para a nova variável 'b'.
int b = a;

Console.WriteLine($"a: {a}, b: {b}"); // Saída: a: 10, b: 10

// 3. Modificamos apenas 'b'.
b = 20;

// 4. A variável 'a' permanece inalterada, pois elas são independentes.
Console.WriteLine($"Após a mudança, a: {a}, b: {b}"); // Saída: a: 10, b: 20
```

### Diagrama: Cópia de Valor

Após a atribuição `int b = a;`, a Stack fica assim:

```text
      STACK
+------------------+
|                  |  <-- Topo da Stack
+------------------+
|      b = 10      |  (Cópia independente)
+------------------+
|      a = 10      |
+------------------+
| ...outras vars...|
+------------------+
```

Quando `b` é alterado para `20`, apenas a sua "caixa" na Stack é afetada.

## O Garbage Collector e a Stack

O **Garbage Collector (Coletor de Lixo)** do .NET é responsável por limpar a memória na Heap, mas ele **não gerencia a Stack**. A memória da Stack é liberada automaticamente quando uma variável sai de escopo (por exemplo, quando o método onde ela foi declarada termina sua execução). Esse gerenciamento automático é o que torna a alocação e desalocação na Stack extremamente rápidas.

## Exemplos de Tipos de Valor

- **Tipos numéricos primitivos**: `int`, `double`, `float`, `decimal`, `long`, `byte`, etc.
- **`bool`**: O tipo booleano `true`/`false`.
- **`char`**: Um único caractere Unicode.
- **`struct`**: Estruturas definidas pelo usuário. São a forma de criar seus próprios tipos de valor complexos.
- **`enum`**: Enumerações, que representam um conjunto de constantes nomeadas.