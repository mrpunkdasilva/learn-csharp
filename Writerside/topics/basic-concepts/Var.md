# Var

Var é uma palavra reservada do C#, que permite declarar variáveis sem especificar o tipo de dado. O compilador infere automaticamente o tipo da variável com base no valor atribuído a ela.

Aqui está um exemplo simples:
```c#
var nome = "João";
int idade = 25;
double altura = 1.75;

Console.WriteLine($"Nome: {nome}, Idade: {idade}, Altura: {altura}");
```

Neste exemplo, não precisamos especificar explicitamente os tipos das variáveis `nome`, `idade` e `altura`. O compilador infere que `nome` é do tipo string, `idade` é do tipo int e `altura` é do tipo double.

MAS temos uma questão, o tipo que o compilador inferiu pela primeira vez sobre a variavel não pode ser alterado depois

Então se tivermos, a varivel `nome` como var e sendo inferido que ela é uma string, mas depois quisermos atribuir um inteiro para ela, teremos um erro: 

```c#
var nome = "João"; // Inferência de tipo: string
nome = 4; // Erro! Não é possível atribuir um inteiro a uma variável do tipo string.
```

![Erro de conversão implicita string para int](Erro de conversão implicita string para int)
