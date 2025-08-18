# Bool

Bool é o tipo de dado **booleano** (no c# ele se chama _bool_) e pode receber apenas dois valores: `true` ou `false`. 

## Exemplo

```c#
using System;
class Program {
    static void Main(string[] args) {
        bool isTrue = true; // Variável do tipo booleana que recebe valor verdadeiro.
        Console.WriteLine(isTrue); // Imprime no console a variável criada.
    }
}
```

Quando fazemos a inferencia com `var` seguimos a mesma lógica que os outros tipos:

```c#
using System;

class Program {
    static void Main(string[] args) {
        var isFalse = false; // Inferência da variável do tipo booleana que recebe valor falso.
        Console.WriteLine(isFalse);
    }
}
```