# A Palavra-Chave using

A palavra-chave `using` em C# é multifacetada e possui três contextos de uso distintos, todos com o objetivo de simplificar o código e gerenciar recursos de forma eficaz.

## 1. Diretiva `using`: Importando Namespaces

Este é o uso mais comum. A diretiva `using` é colocada no topo de um arquivo de código e permite que você use os tipos de um namespace sem precisar especificar o nome completo do namespace toda vez.

Sem a diretiva `using`, você teria que escrever:
```c#
// Nome completo do tipo é necessário
System.Collections.Generic.List<string> nomes = new System.Collections.Generic.List<string>();
System.Console.WriteLine("Olá");
```

Com a diretiva `using`, o código se torna muito mais limpo e legível:
```c#
// Importamos os namespaces no topo do arquivo
using System;
using System.Collections.Generic;

// Agora podemos usar os tipos diretamente
List<string> nomes = new List<string>();
Console.WriteLine("Olá");
```

<note>
Por convenção, as diretivas `using` são sempre declaradas no início do arquivo.
</note>

## 2. Instrução `using`: Gerenciamento de Recursos (`IDisposable`)

A instrução `using` garante que objetos que implementam a interface `IDisposable` sejam descartados corretamente, liberando recursos não gerenciados (como conexões de banco de dados, arquivos, handles de sistema) assim que não forem mais necessários.

O compilador transforma o bloco `using` em um bloco `try...finally`, garantindo que o método `Dispose()` do objeto seja chamado, mesmo que ocorram exceções.

**Sintaxe Tradicional:**
```c#
// A classe 'StreamReader' implementa IDisposable
using (System.IO.StreamReader leitor = new System.IO.StreamReader("caminho/para/arquivo.txt"))
{
    string conteudo = leitor.ReadToEnd();
    Console.WriteLine(conteudo);
} // O método leitor.Dispose() é chamado automaticamente aqui, fechando o arquivo.
```

**Sintaxe Simplificada (C# 8.0 e superior):**

Se a variável declarada com `using` não for mais usada fora do escopo atual, você pode omitir as chaves.
```c#
using System.IO.StreamReader leitor = new System.IO.StreamReader("arquivo.txt");
string conteudo = leitor.ReadToEnd();
Console.WriteLine(conteudo);
// O método leitor.Dispose() será chamado automaticamente no final do escopo (ex: no final do método).
```

## 3. Diretiva `using static`: Importando Membros Estáticos

Esta diretiva permite que você acesse os membros estáticos (`métodos`, `propriedades`, `constantes`) de uma classe diretamente, sem precisar prefixá-los com o nome da classe.

Sem `using static`:
```c#
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Math.PI);
        Console.WriteLine(Math.Pow(2, 3));
    }
}
```

Com `using static`, o código fica mais conciso:
```c#
// Importamos todos os membros estáticos da classe System.Math e System.Console
using static System.Math;
using static System.Console;

class Program
{
    static void Main()
    {
        // Agora podemos chamar os métodos estáticos diretamente
        WriteLine(PI);       // Em vez de Math.PI
        WriteLine(Pow(2, 3)); // Em vez de Math.Pow(2, 3)
    }
}
```

<warning>

Use `using static` com moderação. Embora possa tornar o código mais curto, usá-lo excessivamente pode poluir o escopo e diminuir a legibilidade, tornando difícil saber de qual classe um método estático se origina.

</warning>
