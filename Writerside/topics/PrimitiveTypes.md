# Tipos Primitivos (Built-in Types)

São os tipos de dados mais básicos que o C# possui. São eles:
- int: Inteiro, pode ser positivo ou negativo.
- float: Ponto flutuante, números com casas decimais.
- double: Double precision floating point number. Números com casas decimais.
- char: Caracteres individuais. Exemplo 'a', 'b' etc...
- bool: Booleano, verdadeiro ou falso.

Os tipos primitivos são usados para armazenar valores simples e podem ser declarados da seguinte forma:
```c#
int myInt = 10;
float myFloat = 3.14f; // O sufixo "f" é usado para indicar que é um número de ponto flutuante.
double myDouble = 2.71828;
char myChar = 'A';
bool myBool = true;
```

<note>
Veja mais: [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types)
</note>

## Classificação 

Eles podem ser classificados em algumas categórias:
- Tipos Simples (Simple Types)
- Enumerados (Enum Types)
- Estruturas (Struct Types)
- Tipos Nulos (Nullable Types)

## Definições 
Cada tipo possui sua capacidade em bytes e seu alcance máximo. Por exemplo:
- int: 4 bytes, -2^31 a 2^31-1
- float: 4 bytes, ~±1.5 x 10^-45 to ±3.4 x 10^38
- double: 8 bytes, ~±5.0 x 10^-324 to ±1.7 x 10^308
- char: 2 bytes, '\u0000' to '\uffff'
- bool: 1 byte, false or true

<warning>
Caso o o valor atribuido exceda o limite do tipo, ocorrerá um erro de overflow
</warning>

<note>

Você também pode usar as palavras-chave `sizeof` e `typeof` para obter informações sobre esses tipos:
```c#
Console.WriteLine(sizeof(int)); // Output: 4
Console.WriteLine(typeof(float).Name); // Output: Single
```

</note>