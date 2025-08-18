# Byte

O tipo byte é usado para representar de fato um byte.

Em diversos casos precisamos de uma cadeia de bytes num arquivo para ler ou escrever dados. O tipo byte pode ser usado para isso, pois ele representa um único byte

```c#
byte b = 10;
Console.WriteLine(b);
```

Temos também o `sbyte` que permite valores negativos

<note>

**Unsigned e signed:**

Valores com sinal como "-" por exemplo, são chamados de signed numbers (números com sinal) e sem sinal são chamados unsigned numbers (números sem sinal).

Ex: 

```c#
int signedNumber = -5; //signed number
uint unsignedNumber = 5; //unsigned number
```

</note>


## Definições 

- **byte (8-bit):**
  - escala: 0 a 255
- **sbyte (8-bit):**
  - escala: -127 a +127