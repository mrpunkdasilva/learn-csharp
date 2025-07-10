# String

As strings são uma cadeia de caracters ou seja são mais de um caracter. Exemplo: "Hello World" é uma string.

Para criar uma variável do tipo string basta usar aspas duplas "" e colocar o texto dentro delas.
Exemplo:

```c#
string nome;
nome = "João";
```

```c#
string nome = "João";
Console.WriteLine(nome); // João
```

Você pode concatenar duas strings usando o operador +, exemplo:
```c#
string nome = "João";
string sobrenome = "Silva";
string nomeCompleto = nome + " " + sobrenome; // João Silva
Console.WriteLine(nomeCompleto);
```
<warning>

IMPORTANTE: Strings **SEMPRE** serão com aspas duplas ("") e não simples ('')

Mesmo que inicializarmos uma variavel com string e deixar com um caracter e aspas duplas, ela será ainda uma string:

```c#
string letra = "a"; // a
Console.WriteLine(letra.GetType()); // System.String
```

</warning>

