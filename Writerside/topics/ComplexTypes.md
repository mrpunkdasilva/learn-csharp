# Tipos Complexos

Enquanto os [tipos primitivos](primitivetypes.md) (como `int`, `bool`, `double`) representam valores únicos e simples, a verdadeira força de uma linguagem orientada a objetos como o C# reside na capacidade de criar **Tipos Complexos**. Estes são tipos de dados que nós, desenvolvedores, definimos para modelar os conceitos do mundo real, como um `Cliente`, um `Pedido` ou um `Produto`.

Um tipo complexo é uma estrutura de dados que agrupa múltiplos valores (sejam eles primitivos ou outros tipos complexos) e, crucialmente, pode conter **comportamento** associado a esses dados (através de métodos).

> **Dissertação**: O salto dos tipos primitivos para os complexos é o que nos permite passar de simples cálculos para a criação de **modelos de domínio** ricos e expressivos. Em vez de trabalhar com um emaranhado de números e textos soltos, começamos a trabalhar com `Faturas` que sabem como se calcular, com `Usuários` que sabem como se validar e com `Veículos` que sabem como se mover. A criação de tipos complexos é a essência de traduzir um problema de negócio em código robusto, compreensível e de fácil manutenção.

No C#, os tipos complexos se dividem em duas categorias fundamentais, cuja compreensão é absolutamente crítica: **Tipos de Valor** (*Value Types*) e **Tipos de Referência** (*Reference Types*).

---

## A Divisão Fundamental: Valor vs. Referência

A diferença entre tipos de valor e de referência está em **onde e como** seus dados são armazenados na memória.

-   **Tipos de Valor (`struct`, `enum`)**: Uma variável de um tipo de valor contém **diretamente** seus dados. Quando você atribui uma variável de valor a outra, o valor é **copiado**. Elas geralmente vivem em uma área da memória chamada **Stack (Pilha)**, que é muito rápida e gerenciada de forma eficiente.

-   **Tipos de Referência (`class`, `record`, `string`, arrays)**: Uma variável de um tipo de referência **não** contém o objeto em si. Em vez disso, ela contém uma **referência** (um endereço, como um ponteiro) para o local na memória onde o objeto real está armazenado. O objeto em si vive em uma área da memória chamada **Heap (Monte)**. Quando você atribui uma variável de referência a outra, apenas a **referência é copiada**, não o objeto. Ambas as variáveis passam a apontar para o **mesmo objeto**.

### Diagrama de Memória: Stack vs. Heap

Este diagrama visualiza a diferença. `myPoint` (um `struct`) vive inteiramente na Stack. `myCustomer` (uma `class`) é apenas um ponteiro na Stack que aponta para o objeto real no Heap.

```plantuml
@startuml
skinparam monochrome true
skinparam shadowing false

rectangle "Stack (Memória Rápida)" as Stack {
  rectangle "myPoint (Point)" as PointVar {
    X = 10
    Y = 20
  }
  rectangle "myCustomer (Customer)" as CustomerVar {
    Endereço: 0xABC123
  }
}

rectangle "Heap (Memória Dinâmica)" as Heap {
  rectangle "Objeto Customer @ 0xABC123" as CustomerObj {
    Id = 99
    Name = "Alice"
  }
}

CustomerVar --|> CustomerObj : aponta para

@enduml
```

---

## Tipos de Valor em Detalhe

### `struct`: Criando Tipos de Valor Leves

Um `struct` é ideal para representar pequenos grupos de dados que têm semântica de valor, ou seja, onde a identidade do objeto não importa tanto quanto seus valores. Pense em um ponto, uma cor ou uma quantia monetária.

-   **Analogia**: Um `struct` é como uma nota autoadesiva (Post-it®). Se você tem uma nota com "Comprar pão" e a copia para outra nota, agora você tem duas notas independentes. Amassar ou rasgar uma não afeta a outra.

#### Exemplo Prático: Modelando Dinheiro

```c#
// A struct is a value type. When you copy it, you get a new independent instance.
public struct Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}

public void TestValueTypeCopy()
{
    var price1 = new Money(100, "USD");
    var price2 = price1; // The entire content of price1 is COPIED into price2.

    // Because they are independent copies, changing one does not affect the other.
    // (Note: Money is immutable here, but if it were mutable, this would be the behavior).
}
```

### `enum`: Para Constantes Nomeadas

Um `enum` (enumeração) é um tipo de valor especial que permite definir um conjunto de constantes nomeadas, melhorando a legibilidade do código.

-   **Analogia**: Os naipes de um baralho (Copas, Ouros, Paus, Espadas) ou os dias da semana. São um conjunto finito e bem conhecido de opções.

```c#
// Using an enum makes the code much more readable than using numbers (0, 1, 2, 3).
public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public class Order
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }

    public void Ship()
    {
        if (Status == OrderStatus.Processing)
        {
            Status = OrderStatus.Shipped;
            // ... logic to ship the order
        }
    }
}
```

---

## Tipos de Referência em Detalhe

### `class`: A Espinha Dorsal da OOP

Uma `class` é o bloco de construção mais comum para tipos de referência. É usada para modelar entidades complexas que têm identidade, estado (que pode mudar ao longo do tempo) e comportamento.

-   **Analogia**: Uma `class` é como um link para um documento no Google Docs. Se eu te enviar o link, nós dois estamos olhando e editando o **mesmo documento**. Se eu mudar algo, você verá a mudança instantaneamente, porque ambos temos uma referência para o mesmo objeto.

#### Exemplo Prático: Modelando um Cliente

```c#
// A class is a reference type.
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; private set; } = new List<Order>();

    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }
}

public void TestReferenceTypeCopy()
{
    var customer1 = new Customer { Id = 1, Name = "Bob" };
    var customer2 = customer1; // Only the REFERENCE (address) is copied.
                               // Both variables now point to the SAME object in the heap.

    // If we change the object using one variable...
    customer2.Name = "Robert";

    // The change is visible through the other variable, because it's the same object.
    Console.WriteLine(customer1.Name); // Outputs "Robert"
}
```

---

## O Problema da "Obsessão Primitiva" (Primitive Obsession)

Este é um *code smell* (um mau cheiro no código) muito comum, onde usamos tipos primitivos para representar conceitos de domínio que são, na verdade, mais complexos.

-   Usar `string` para um e-mail ou CPF.
-   Usar `decimal` para dinheiro sem a moeda.
-   Usar `int` para um ID de produto.

**Por que isso é ruim?**
1.  **Perda de Significado**: Um método `Process(string, string, decimal)` não diz nada. `Process(EmailAddress, PostalCode, Money)` é auto-documentado.
2.  **Ausência de Validação**: Qualquer `string` pode ser passada como um e-mail, mesmo que seja inválida. A lógica de validação fica espalhada por toda a aplicação.
3.  **Comportamento Desassociado**: Você não pode fazer `money.Add(otherMoney)` se `money` for apenas um `decimal`. A lógica de negócio não tem um lugar para morar.

### A Solução: Crie Pequenos Tipos Complexos (Value Objects)

A solução é criar pequenos `structs` ou `classes`/`records` que encapsulam o valor e o comportamento do conceito de domínio. Estes são frequentemente chamados de **Value Objects**.

#### Exemplo: De `string` para `EmailAddress`

**Antes (Ruim):**
```c#
public class UserRegistration
{
    public void Register(string email, string password)
    {
        if (!email.Contains("@")) // Validation is scattered
        {
            throw new ArgumentException("Invalid email format");
        }
        // ... register user
    }
}
```

**Depois (Bom):**
```c#
// A Value Object representing an email address.
public record EmailAddress
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        // Validation is centralized in the constructor. 
        // It's impossible to create an invalid EmailAddress.
        if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
        {
            throw new ArgumentException("Invalid email format");
        }
        Value = value;
    }
}

public class UserRegistration
{
    // The method signature is now clear and type-safe.
    public void Register(EmailAddress email, string password)
    {
        // No need for validation here. We KNOW the email is valid.
        // ... register user
    }
}
```

---

## `record`: Uma Alternativa Moderna para Imutabilidade

Introduzido em C# 9, um `record` é um tipo de referência (ou valor, com `record struct`) que o compilador otimiza para **imutabilidade** e **comparações baseadas em valor**. Ele gera automaticamente construtores, propriedades, métodos de igualdade (`Equals`, `GetHashCode`) e um `ToString()` legível.

É a escolha perfeita para DTOs e Value Objects.

```c#
// Verbose class definition
public class ProductDtoOld
{
    public int Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
}

// Concise and powerful record definition
// This one line generates code equivalent to the class above, plus value-based equality and more.
public record ProductDto(int Id, string Name, decimal Price);
```

---

## Tabela Resumo: `class` vs. `struct`

| Característica        | `class` (Tipo de Referência)                               | `struct` (Tipo de Valor)                                   |
| --------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| **Armazenamento**     | A referência fica na Stack, o objeto fica no **Heap**.     | Geralmente armazenado inteiramente na **Stack**.           |
| **Atribuição**        | Copia a **referência**. Ambas as variáveis apontam para o mesmo objeto. | Copia a **instância inteira**. Cria um objeto independente. |
| **Valor Padrão**      | `null` (nenhum objeto)                                     | `0`, `false`, etc., para cada membro (objeto "zerado").    |
| **Herança**           | Suporta herança de outras classes.                         | Não pode herdar de outra classe (mas pode implementar interfaces). |
| **Uso Ideal**         | Entidades com identidade, estado mutável e comportamento complexo (`Customer`, `Order`). | Objetos pequenos e imutáveis com semântica de valor (`Point`, `Money`, `Color`). |

---

## Referências Oficiais da Microsoft

-   [Classes, structs e records (Guia de Programação C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/types/classes-structs-records)
-   [Tipos de Valor (Referência de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/value-types)
-   [Tipos de Referência (Referência de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/reference-types)