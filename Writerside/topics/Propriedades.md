# Propriedades

Em C#, uma **Propriedade** é um membro de uma classe que fornece um mecanismo flexível e poderoso para ler, escrever ou calcular o valor de um campo privado. Elas são a face pública do estado de um objeto e a principal ferramenta para implementar o pilar do **Encapsulamento**.

À primeira vista, uma propriedade pode parecer simplesmente uma forma mais verbosa de se declarar uma variável pública, mas essa impressão é enganosa. Na verdade, elas são os *guardiões* dos dados de um objeto, permitindo controle total sobre como o estado é acessado e modificado.

> **Dissertação**: Pense em um campo público (`public string Nome;`) como uma porta sem tranca para um cômodo da sua casa. Qualquer um pode entrar a qualquer momento e fazer o que quiser. Uma propriedade (`public string Nome { get; set; }`), por outro lado, é uma porta com um porteiro. Mesmo que, inicialmente, o porteiro deixe todo mundo entrar e sair sem questionar, ele *está lá*. Se, no futuro, você decidir que apenas pessoas autorizadas podem entrar, ou que ninguém pode sair com os móveis, você só precisa dar novas instruções ao porteiro. Você não precisa reconstruir todas as entradas da sua casa. Essa é a essência e o poder das propriedades.

---

## O Problema: Por que Não Usar Campos Públicos?

Uma pergunta comum para quem está começando é: "Se `public string Name { get; set; }` funciona de forma parecida com `public string Name;`, por que toda essa cerimônia?". A resposta está na quebra do encapsulamento.

Um campo público é um convite ao caos. Ele expõe a representação interna do estado do seu objeto sem nenhuma proteção. Qualquer parte do seu sistema pode modificar esse campo para qualquer valor, a qualquer momento, incluindo valores inválidos.

```c#
public class Product
{
    // BAD PRACTICE: Public field. No control, no validation.
    public decimal price;
}

// Some other part of the code...
var myProduct = new Product();
myProduct.price = -999.99m; // The object is now in an invalid state!
```

Se você usa um campo público e, meses depois, percebe que precisa adicionar uma validação (o preço não pode ser negativo), você terá um problema gigantesco. Você precisará encontrar **todos os lugares** no seu código que modificam `myProduct.price` e adicionar a lógica de validação ali. Isso é frágil, propenso a erros e insustentável. Com uma propriedade, a mudança é feita em **um único lugar**: dentro da classe `Product`.

---

## A Anatomia de uma Propriedade

Uma propriedade é, na verdade, "açúcar sintático" (uma forma mais bonita de escrever) para um par de métodos chamados **acessadores** (`accessors`).

-   **Campo de Apoio (Backing Field)**: Geralmente, uma propriedade envolve um campo `private` que armazena o dado real. A convenção é nomeá-lo com um underscore (`_`) no início (ex: `_name`).
-   **Acessador `get`**: Este bloco de código é executado quando o valor da propriedade é lido. Ele deve retornar um valor do tipo da propriedade.
-   **Acessador `set`**: Este bloco de código é executado quando um valor é atribuído à propriedade. Dentro do bloco `set`, você tem acesso a uma palavra-chave implícita chamada `value`, que contém o valor que está sendo atribuído. É aqui que a mágica da validação e do controle acontece.

### Diagrama Conceitual

Este diagrama ilustra como a propriedade atua como um intermediário ou guardião para o campo privado.

```plantuml
@startuml
skinparam classAttributeIconSize 0
skinparam monochrome true
skinparam shadowing false

class UserProfile {
    ' The private backing field holds the actual data.
    - _email : string

    ' The public property acts as a gateway.
    + Email : string
    .. Get/Set Accessors ..
    + {method} get()
    + {method} set(value)
}

rectangle "External Code" as Ext

note right of UserProfile::Email
  Provides controlled access
  to the internal _email field.
  Can contain validation logic.
end note

Ext .right.> UserProfile : "Accesses public property"
UserProfile::Email .down.> UserProfile::_email : "Manages private field"
@enduml
```

---

## Tipos de Propriedades em C#

C# oferece várias sintaxes para declarar propriedades, cada uma adequada a um cenário diferente.

### 1. Propriedades Automáticas (Auto-Implemented Properties)

Esta é a forma mais comum e concisa. Você a utiliza quando não precisa de nenhuma lógica customizada nos acessadores.

`public string Name { get; set; }`

Ao usar esta sintaxe, o compilador do C# cria um *backing field* anônimo e privado para você nos bastidores. Você obtém todos os benefícios de uma propriedade (flexibilidade futura) com a clareza de um campo.

### 2. Propriedades Completas (Fully-Implemented Properties)

Você usa esta forma quando precisa de um *backing field* explícito para implementar uma lógica customizada.

```c#
private int _age;

public int Age
{
    get
    {
        return _age;
    }
    set
    {
        // Validation logic inside the setter.
        if (value < 0 || value > 120)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 0 and 120.");
        }
        _age = value;
    }
}
```

### 3. Propriedades de Apenas Leitura (Read-Only Properties)

Frequentemente, você quer expor um dado que não pode ser modificado de fora da classe. Existem duas maneiras principais:

-   **Propriedade Computada**: Não tem um *backing field* e seu valor é calculado no `get`. Ela não possui um acessador `set`.

    `public string Description => $"{Name} is {Age} years old.";`

-   **Propriedade com `private set`**: O valor pode ser lido por todos, mas só pode ser modificado de *dentro* da própria classe (geralmente no construtor). Isso é perfeito para IDs ou datas de criação.

    `public Guid Id { get; private set; }`

### Exemplo Prático: `UserProfile`

Este exemplo combina os diferentes tipos de propriedades em uma classe do mundo real.

```c#
public class UserProfile
{
    // 1. Read-only property with a private setter.
    // The ID is set once in the constructor and can never be changed from outside.
    public Guid Id { get; private set; }

    // 2. Auto-implemented property for simple data.
    public string Username { get; set; }

    // 3. Full property with validation logic.
    private string _email;
    public string Email
    {
        get { return _email; }
        set
        {
            // Simple validation to ensure the value looks like an email.
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("A valid email is required.", nameof(value));
            }
            _email = value;
        }
    }

    // 4. Read-only computed property using expression-body syntax.
    public string DisplayName => $"@{Username}";

    public UserProfile(string username, string email)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email; // The setter for Email is called here, so validation runs.
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            var user = new UserProfile("mrpunkdasilva", "mr.punk@example.com");
            Console.WriteLine($"User created: {user.DisplayName} (ID: {user.Id})");

            // This works, the setter logic is executed.
            user.Email = "dasilva.punk@newdomain.com";
            Console.WriteLine($"Email updated to: {user.Email}");

            // This will throw an exception due to the validation in the setter.
            user.Email = "invalid-email";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
        }
    }
}
```

> **Nota sobre `init-only` setters (C# 9 e superior)**: Uma adição moderna são os `init` setters: `public string Name { get; init; }`. Eles agem como um `set`, mas só permitem que a propriedade seja atribuída durante a inicialização do objeto (no construtor ou em um inicializador de objeto: `new User { Name = "Test" }`). Após a criação, a propriedade se torna efetivamente de apenas leitura. Isso é extremamente útil para criar **objetos imutáveis**.

---

## Referências Oficiais da Microsoft

-   [Propriedades (Guia de Programação C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/properties)
-   [Usando Propriedades](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/using-properties)

```