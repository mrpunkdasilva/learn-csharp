# Caracter

É o tipo de caracter que utilizamos para armazenar um  único caracter

<note>
Caracter é um tipo de dado primitivo e representa um único caracter no formato unicode (formato universal para a representação dos caracteres)
</note>

<warning>
OBS:
Para declarar uma variável do tipo char, devemos utilizar aspas simples
</warning>

## Exemplos:

```c#
char letra = 'a';
Console.WriteLine(letra); // imprime: a

char numero = '1';
Console.WriteLine(numero); // imprime: 1

char simbolo = '@';
Console.WriteLine(simbolo); // imprime: @

char espaco = ' ';
Console.WriteLine(espaco); // imprime: espaço em branco

char tabulacao = '\t'; // \t é uma sequência de escape que representa uma tabulação horizontal
Console.WriteLine(tabulacao); // imprime: tabulação horizontal

char novaLinha = '\n'; // \n é uma sequência de escape que representa uma nova linha
Console.WriteLine(novaLinha); // imprime: nova linha

char backspace = '\b'; // \b é uma sequência de escape que representa um caractere de retrocesso
Console.WriteLine(backspace); // imprime: caractere de retrocesso

// unicode
char unicode = '\u0041'; // \u seguido de quatro dígitos hexadecimais representa um caractere Unicode
Console.WriteLine(unicode); // imprime: A
```
