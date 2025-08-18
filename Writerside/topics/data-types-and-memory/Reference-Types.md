# Tipos de Referência (Reference Types)

Tipos de referência são um dos dois pilares fundamentais do sistema de tipos do C#. Diferente dos tipos de valor, uma variável de tipo de referência **não armazena o dado diretamente**. Em vez disso, ela armazena um **endereço de memória** (uma referência ou ponteiro) que aponta para o local onde o objeto real está armazenado. Esse local é uma área da memória chamada **Heap**.

## Como Funciona a Memória?

A gestão da memória para tipos de referência envolve duas áreas:

1.  **Stack**: A variável em si é criada na Stack. Ela é leve e contém apenas o endereço de memória do objeto.
2.  **Heap**: O objeto real, com todos os seus dados, é alocado na Heap. A Heap é uma área de memória maior e mais flexível, gerenciada por um processo chamado **Garbage Collector (Coletor de Lixo)**.

### Diagrama: Variável e Objeto na Memória

Quando você cria um objeto, a variável na Stack aponta para o objeto na Heap.

```text
      STACK                         HEAP
+------------------+      +-------------------------+
|                  |      |                         |
|  minhaConta      |----->|  Objeto Conta           |
| (Endereço: 0x2A) |      |  (Endereço: 0x2A)       |
|                  |      |  - Saldo: 1000          |
+------------------+      |  - Titular: "Ana"       |
|                  |      |                         |
+------------------+      +-------------------------+
```

## Comportamento na Atribuição

Esta é a diferença mais crucial. Quando você atribui uma variável de referência a outra, você **não está copiando o objeto**, mas sim **copiando o endereço de memória**.

O resultado é que ambas as variáveis passam a apontar para o **mesmo objeto** na Heap. Qualquer modificação feita através de uma variável será visível através da outra.

### Exemplo de Código

```c#
// Vamos supor que temos uma classe simples
public class ContaBancaria
{
    public decimal Saldo { get; set; }
}

// 1. Criamos uma instância. 'contaA' aponta para um novo objeto.
var contaA = new ContaBancaria { Saldo = 1000 };

// 2. Copiamos a referência. Agora 'contaB' aponta para o MESMO objeto que 'contaA'.
var contaB = contaA;

Console.WriteLine($"Saldo (contaA): {contaA.Saldo}"); // Saída: 1000
Console.WriteLine($"Saldo (contaB): {contaB.Saldo}"); // Saída: 1000

// 3. Modificamos o objeto usando 'contaB'.
contaB.Saldo = 500;

// 4. A mudança é refletida em 'contaA', pois ambas apontam para o mesmo lugar.
Console.WriteLine($"Saldo (contaA) após mudança: {contaA.Saldo}"); // Saída: 500
Console.WriteLine($"Saldo (contaB) após mudança: {contaB.Saldo}"); // Saída: 500
```

### Diagrama: Cópia de Referência

Após `var contaB = contaA;`, a situação da memória é a seguinte:

```text
      STACK                         HEAP
+------------------+      +-------------------------+
|                  |      |                         |
|      contaA      |----->|  Objeto Conta           |
| (Endereço: 0x5B) |      |  (Endereço: 0x5B)       |
+------------------+      |  - Saldo: 1000          |
|                  |      |                         |
|      contaB      |----->|                         |
| (Endereço: 0x5B) |      +-------------------------+
|                  |
+------------------+
```

## O Garbage Collector (GC)

Como a Heap é gerenciada dinamicamente, precisamos de um mecanismo para limpar objetos que não são mais necessários. É aqui que entra o **Garbage Collector**.

O GC periodicamente verifica a Heap em busca de objetos que **não possuem mais nenhuma referência apontando para eles**. Quando encontra esses objetos "órfãos", ele os remove e libera a memória para que possa ser reutilizada.

Se no nosso exemplo fizermos `contaA = null;` e `contaB = null;`, o objeto `ContaBancaria` na Heap se tornaria elegível para a coleta de lixo.

## Exemplos de Tipos de Referência

- **`class`**: O exemplo mais comum. Todas as classes que você cria são tipos de referência.
- **`object`**: O tipo base para todos os outros tipos no .NET.
- **`string`**: Embora às vezes se comporte como um tipo de valor (devido à sua imutabilidade), `string` é um tipo de referência.
- **Arrays**: Vetores e matrizes (ex: `int[]`, `string[]`) são sempre tipos de referência.
- **Delegates** e **Interfaces**.