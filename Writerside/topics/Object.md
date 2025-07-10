# Object

É um tipo de dado genérico que pode aceitar qualquer tipo de valor ou objeto

Usado para por exemplo quando não sabe o tipo da informação ou ela é de varios tipos diferentes

```c#
object obj = 10;
obj = "Hello World";
```

<note>

**OBS:** Não é recomendado usar pois a conversão entre os tipos deve ser feita manualmente e isso pode gerar erros em tempo de execução.

</note>


## Boxing and Unboxing

**Boxing:** Converte um tipo primitivo em object. 

- Exemplo:
```c#
int i = 5; // Tipo primitivo int
object obj = i; // Boxing, converte o tipo int em object
```

**Unboxing:** Converte um object em um tipo primitivo. 
- Exemplo:
```c#
object obj = 5; // Objeto do tipo object com valor inteiro
int i = (int)obj; // Unboxing, converte o objeto em um tipo primitivo int
```

<note>

Podemos pensar nesse boxing como um **ato de colocar algo** dentro de uma caixa, cujo o conteúdo pode ser qualquer coisa. 

E o unboxing seria o **ato de tirar algo** dessa caixa.

</note>

<note>

Uma diferença entre `var`e `object` é que no caso do object você não precisa iniciar um valor por exemplo:

```c#
object obj;
```

E quando fazer uma reatribuição de valor de um tipo diferente não dara problema, diferente do `var`:

```c#
var var = 10;
var = "Hello World"; // Erro: Cannot implicitly convert type 'string' to 'int'
```
No caso do `object`, podemos fazer assim sem problemas:
```c#
object obj = 10;
obj = "Hello World";
```

</note>