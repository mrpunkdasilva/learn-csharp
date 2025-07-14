# Implicit Casting

A conversão implicita é quando  podemos executar essa transformação apenas com a passagem de dados

E os tipos são compatíveis entre si, como por exemplo:
- int -> long
- float -> double
- short -> int
- char -> int

## Exemplos:

```c#
float value = 25.8f;
int newValue = (int)value; // Conversão implícita
```

<note>

Nesse caso, estamos atribuindo um valor do tipo float à uma variável do tipo int. O compilador **irá realizar a conversão automaticamente**, pois o tipo float pode ser convertido em um inteiro sem perda de precisão.

</note>

