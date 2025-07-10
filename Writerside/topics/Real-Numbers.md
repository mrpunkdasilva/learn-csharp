# Números Reais

Números com casas decimais ou _ponto flutuante_ são chamados de números reais. Em C#, o tipo `double` é usado para representar um número real. O exemplo a seguir mostra como declarar e inicializar uma variável do tipo `double`.

```c#
double x = 3.14; // Declaração e inicialização
```
O valor da variável `x` é `3,14`. A declaração acima pode ser escrita em duas linhas.

```c#
double x; // Declaração
x = 3.14; // Inicialização
```

Além do `double` também existem outros que são diferentes por causa da precisão e tamanho dos dados armazenados. Os outros são:
* `float`: tem menos precisão e menor tamanho.
* `decimal`: tem maior precisão e maior tamanho.


## Exemplos:

```c#
using System;
class Program {
    static void Main(string[] args) {
        double x = 3.14;
        Console.WriteLine(x); // Imprime: 3.14
        
        float y = 2.71f;
        Console.WriteLine(y); // Imprime: 2.71
        
        decimal z = 1.618m;
        Console.WriteLine(z); // Imprime: 1.618
    }
}
```

## Inferencia de Tipos

Quando usamos o `var` sem declarar o tipo explicitamente, ele atribui automaticamente o tipo `double` porque ele estaria no meio entre `float` e `decimal`, mas se fosse muito próximo de `int` ele seria inferido como `int`.

```c#
var x = 3.14; // Inferência de tipo: double
Console.WriteLine(x.GetType()); // Imprime: Double
```

Agora se quisermos dizer que vai ser _float_ ou _decimal_ devemos usar os sufixos `f` ou `m` respectivamente. 

```c#
var x = 3.14f; // Inferência de tipo: float
Console.WriteLine(x.GetType()); // Imprime: Single

var y = 3.14m; // Inferência de tipo: decimal
Console.WriteLine(y.GetType()); // Imprime: Decimal
```


## Tabela de Tipos

| Tipo | Intervalo Aproximado | Precisão | Tamanho | Tipo .NET |
| --- | --- | --- | --- | --- |
| `float` | ±1.5 x 10⁻⁴⁵ a ±3.4 x 10³⁸ | 6-9 dígitos | 4 bytes | System.Single |
| `double` | ±5.0 x 10⁻³²⁴ a ±1.7 x 10³⁰⁸ | 15-17 dígitos | 8 bytes | System.Double |
| `decimal` | ±1.0 x 10⁻²⁸ a ±7.9 x 10²⁸ | 28-29 dígitos | 16 bytes | System.Decimal |



<note>

Os três tipos não usam unsigned ou signed, pois possuem tanto assimilação negativa e positiva por padrão

</note>


## Referência

[Tipos de ponto flutuante (referência de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types)
