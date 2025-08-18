# Números Inteiros

## Definições 

Números inteiros são números que não possuem casas decimais. Exemplos de números inteiros: 1, -20, 356789.

## Classificação:

- short/unshort
- int/uint
- long/ulong

<note>

O `u` do `ushort`, `uint` e `ulong` significa **unsigned** (sem sinal)

Ou seja, esses tipos só armazenam valores que são possitivos ou zero

</note>

## Tabela de Tipos

| Tipo | Intervalo | Tamanho | Tipo .NET |
| --- | --- | --- | --- |
| `sbyte` | -128 a 127 | Inteiro de 8 bits com sinal | System.SByte |
| `byte` | 0 a 255 | Inteiro de 8 bits sem sinal | System.Byte |
| `short` | -32,768 a 32,767 | Inteiro de 16 bits com sinal | System.Int16 |
| `ushort` | 0 a 65,535 | Inteiro de 16 bits sem sinal | System.UInt16 |
| `int` | -2,147,483,648 a 2,147,483,647 | Inteiro de 32 bits com sinal | System.Int32 |
| `uint` | 0 a 4,294,967,295 | Inteiro de 32 bits sem sinal | System.UInt32 |
| `long` | -9,223,372,036,854,775,808 a 9,223,372,036,854,775,807 | Inteiro de 64 bits com sinal | System.Int64 |
| `ulong` | 0 a 18,446,744,073,709,551,615 | Inteiro de 64 bits sem sinal | System.UInt64 |

## Referência

[Tipos de números integrais (referência de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)

