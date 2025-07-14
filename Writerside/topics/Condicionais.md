# Estruturas Condicionais

Estruturas condicionais permitem que um programa execute diferentes blocos de código com base em condições booleanas (`true` ou `false`). Elas são a principal maneira de criar lógica e tomar decisões em C#.

## A Estrutura `if`

A instrução `if` é a estrutura condicional mais fundamental. Ela executa um bloco de código somente se a condição especificada for `true`.

**Sintaxe:**
```csharp
if (condição)
{
    // Bloco de código a ser executado se a condição for verdadeira.
}
```

**Exemplo:**
```c#
int idade = 20;
if (idade >= 18)
{
    Console.WriteLine("Você é maior de idade.");
}
```

## A Estrutura `if-else`

A instrução `else` pode ser adicionada a um `if` para executar um bloco de código alternativo quando a condição do `if` for `false`.

**Sintaxe:**
```csharp
if (condição)
{
    // Bloco de código se a condição for verdadeira.
}
else
{
    // Bloco de código se a condição for falsa.
}
```

**Exemplo:**

```c#
int temperatura = 15;
if (temperatura > 25)
{
    Console.WriteLine("Está calor.");
}
else
{
    Console.WriteLine("Não está calor.");
}
```

## A Estrutura `if-else if-else`

Para testar múltiplas condições em sequência, você pode usar a estrutura `else if`. O C# avaliará as condições na ordem em que aparecem e executará o primeiro bloco de código cuja condição seja `true`. O bloco `else` final é opcional e serve como uma condição "pega-tudo" se nenhuma das anteriores for satisfeita.

**Sintaxe:**

```csharp
if (condição1)
{
    // Bloco 1
}
else if (condição2)
{
    // Bloco 2
}
else
{
    // Bloco 3 (opcional)
}
```

**Exemplo:**

```c#
int numero = 0;

if (numero > 0)
{
    Console.WriteLine("O número é positivo.");
}
else if (numero < 0)
{
    Console.WriteLine("O número é negativo.");
}
else
{
    Console.WriteLine("O número é zero.");
}
```

## Variações de Sintaxe e Boas Práticas

### Omissão de Chaves (`{}`)

Em C#, se o bloco de código dentro de uma instrução `if`, `else if` ou `else` contém **apenas uma única linha de comando**, as chaves `{}` são opcionais.

**Exemplo:**

```c#
int temperatura = 30;

if (temperatura > 25)
    Console.WriteLine("Está calor.");
else
    Console.WriteLine("Não está calor.");
```

<warning>

**Cuidado com a omissão de chaves!** 

Embora a sintaxe seja permitida, ela é uma fonte comum de bugs. Se você adicionar uma segunda linha de código ao `if` ou `else` sem adicionar as chaves, apenas a primeira linha será condicional. A segunda linha será executada incondicionalmente, o que pode levar a um comportamento inesperado.

**Exemplo de Bug:**
```c#
bool usuarioLogado = false;

if (usuarioLogado)
    Console.WriteLine("Bem-vindo!");
    RenderizarPainelDeControle(); // Esta linha será executada SEMPRE, mesmo se o usuário não estiver logado!
```

**Boa Prática:** Para evitar erros e melhorar a legibilidade e a manutenção do código, é altamente recomendável **sempre usar chaves**, mesmo para blocos de uma única linha.

```c#
// Forma segura e recomendada
if (usuarioLogado)
{
    Console.WriteLine("Bem-vindo!");
}
```
</warning>

## A Instrução `switch`

A instrução `switch` é uma alternativa à estrutura `if-else if-else`, ideal para quando você precisa comparar uma única variável contra uma lista de valores constantes.

-   `case`: Define um valor a ser comparado com a variável do `switch`.
-   `break`: É **obrigatório** ao final de cada `case` para sair do `switch` e impedir a execução do próximo `case` (fall-through).
-   `default`: É opcional e funciona como o `else` final, sendo executado se nenhum `case` corresponder.

**Exemplo:**
```c#
int diaDaSemana = 3;
string nomeDoDia;

switch (diaDaSemana)
{
    case 1:
        nomeDoDia = "Domingo";
        break;
    case 2:
        nomeDoDia = "Segunda-feira";
        break;
    case 3:
        nomeDoDia = "Terça-feira";
        break;
    // ... outros casos
    default:
        nomeDoDia = "Dia inválido";
        break;
}

Console.WriteLine(nomeDoDia); // Saída: Terça-feira
```

## Expressões `switch` (C# 8.0 e superior)

Versões mais recentes do C# introduziram a expressão `switch`, uma forma mais moderna e concisa que é especialmente útil para atribuir um valor a uma variável com base em uma condição.

-   É uma expressão, o que significa que ela **retorna um valor**.
-   Usa a sintaxe `=>` (lambda).
-   Não precisa de `case` ou `break`.
-   Usa o descarte (`_`) para o caso `default`.
-   Suporta *pattern matching* avançado.

**Exemplo:**
```c#
int diaDaSemana = 3;

string nomeDoDia = diaDaSemana switch
{
    1 => "Domingo",
    2 => "Segunda-feira",
    3 => "Terça-feira",
    4 => "Quarta-feira",
    5 => "Quinta-feira",
    6 => "Sexta-feira",
    7 => "Sábado",
    _ => "Dia inválido" // Caso default
};

Console.WriteLine(nomeDoDia); // Saída: Terça-feira
```

### Quando Usar `if` vs. `switch`

-   **Use `if-else if`:** Para condições complexas, comparações de intervalos (ex: `idade > 18 && idade < 60`) ou quando múltiplas variáveis estão envolvidas.
-   **Use `switch`:** Para comparar uma única variável contra um conjunto de valores constantes e distintos. A expressão `switch` é a abordagem moderna e preferida quando disponível.