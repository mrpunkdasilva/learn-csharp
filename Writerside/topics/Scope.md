# Escopo de um Programa

O escopo do programa se entende como o espaço onde as variáveis podem ser acessadas. Em C#, todo código é dividido em namespaces, classes e métodos.

Os namespaces são usados para organizar os programas, sendo o mais externo, o escopo mais global.

Depois disso temos as classes que contém os métodos e variáveis. O escopo das variáveis dentro da classe é chamado de escopo local. 

Agora vamos ver um exemplo:

```c#
using System;

// Namespace is a logic division
namespace MeuApp
{
    // Main class
    class Program
    {
        // Main entry point
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

O escopo ficaria assim:

```
|-----------------|
|  Namespace                 
| 
|  -------------------
|  |   
|  |   Class
|  |                
|  |   ---------------
|  |  |     
|  |  |     Method     
|  |  |    
|  |  |     ---------
|  |  |    |  Local Funcions
|  |  |    -----------
|  |  |
|  |   -----------------
|  |
|  |------------------
|
|-------------------|
```