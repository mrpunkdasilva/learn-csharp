# Variables

Variavel é um espaço na mémoria que vai guardar um dado

No C# como toda linguagem de programação temos tipos primitivos, por exemplo:

- int - inteiro
- string - texto
- bool - booleano (true ou false)
- double e float - número decimal

<note>
Lembrando que: double e float não são o mesmo pois o double possui uma precisão maior do que o float, mas o float ocupa menos memória.
</note>

No c# podemos declarar variaveis assim:

```c#
int idade = 10;
string nome = "Joao";
bool estaAprovado = true;
double salario = 25.98;
float altura; 
altura = 1.76f; 
```

<warning>

Note que para declarar um float devemos colocar a letra f no final da declaração:

```c#
float altura = 1.76f; 
```

</warning>


## Declarações múltiplas
É possível declarar várias variáveis no mesmo comando separando-as por vírgula.
```c#
int a, b, c;
```


Lembre-se sempre que você precisa inicializar uma variável antes de usá-la. E de que C# é uma linguagem fortemente
tipada, logo, precisamos definir o tipo dela ou seja, você deve especificar o tipo de dados quando declarar uma
variável. Ou podemos usar a inferência de tipos. Exemplo:

```c#
var idade = 10;
var nome = "Joao";
var estaAprovado = true;
var salario = 25.98;
var altura = 1.76f; 
```

Assim o tipo de dado será inferido pelo compilador, deste modo não temos um controle real da tipagem

<note>

Para inferencia de tipos utilizamos a palavra reservada `var`. Mas não podemos utilizar desta forma na hora de criar uma
variavel:

```c#
var x; // isso está errado!
```

</note>