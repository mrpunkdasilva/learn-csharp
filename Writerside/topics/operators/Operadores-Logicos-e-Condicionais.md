# Operadores Lógicos e Condicionais

Em C#, operadores lógicos e condicionais são usados para trabalhar com valores booleanos (`true`/`false`) e para tomar decisões baseadas em condições. Eles são a cola que une as comparações para criar regras de negócio e fluxos de controle complexos.

## Operadores Lógicos Condicionais (Short-Circuiting)

Estes são os operadores lógicos mais comuns. Eles são chamados de "condicionais" ou "short-circuiting" porque **só avaliam o segundo operando se for estritamente necessário**.

| Operador | Nome | Exemplo | Descrição |
| :--- | :--- | :--- | :--- |
| `&&` | E (AND) | `expr1 && expr2` | Retorna `true` somente se **ambas** as expressões forem `true`. |
| `||` | OU (OR) | `expr1 || expr2` | Retorna `true` se **pelo menos uma** das expressões for `true`. |
| `!` | NÃO (NOT) | `!expr1` | Inverte o valor booleano da expressão (de `true` para `false` e vice-versa). |

### A Importância do Short-Circuiting

-   **`&&` (E):** Se a primeira expressão (`expr1`) for `false`, o resultado da operação será sempre `false`, independentemente da segunda expressão. Portanto, `expr2` **não é avaliada**. Isso é útil para evitar erros.

    ```c#
    string nome = null;
    // A segunda verificação (nome.Length > 0) nunca é executada, evitando uma NullReferenceException.
    if (nome != null && nome.Length > 0) 
    {
        Console.WriteLine("Nome válido.");
    }
    else
    {
        Console.WriteLine("Nome inválido ou nulo.");
    }
    ```

-   **`||` (OU):** Se a primeira expressão (`expr1`) for `true`, o resultado da operação será sempre `true`. Portanto, `expr2` **não é avaliada**. Isso pode ser usado para otimização.

    ```c#
    bool usuarioAdmin = true;
    // A função VerificarPermissao() nunca é chamada, economizando processamento.
    if (usuarioAdmin || VerificarPermissao())
    {
        Console.WriteLine("Acesso concedido.");
    }
    ```

## Operadores Condicionais

### Operador Ternário (`? :`)

O operador condicional ternário é um atalho conciso para uma instrução `if-else`. Ele avalia uma condição booleana e retorna um de dois valores.

**Sintaxe:** `condição ? valor_se_verdadeiro : valor_se_falso;`

```c#
int idade = 20;
string status = (idade >= 18) ? "Maior de idade" : "Menor de idade";

Console.WriteLine(status); // Saída: Maior de idade

// O código acima é um atalho para:
// string status;
// if (idade >= 18)
// {
//     status = "Maior de idade";
// }
// else
// {
//     status = "Menor de idade";
// }
```

### Operador de Coalescência Nula (`??`)

Este operador é usado para fornecer um valor padrão para tipos de referência ou tipos de valor anuláveis. Ele retorna o operando da esquerda se ele **não for nulo**; caso contrário, ele retorna o operando da direita.

```c#
string nomeDoBanco = null;

// Se nomeDoBanco for nulo, use "Convidado". Caso contrário, use o próprio valor.
string nomeUsuario = nomeDoBanco ?? "Convidado";

Console.WriteLine(nomeUsuario); // Saída: Convidado

string nomeValido = "Alice";
nomeUsuario = nomeValido ?? "Convidado";
Console.WriteLine(nomeUsuario); // Saída: Alice
```

---

## Tópico Avançado: Operadores Lógicos Booleanos e Bitwise

C# também possui operadores que parecem lógicos, mas têm um propósito diferente e mais específico. É crucial não confundi-los com os operadores condicionais `&&` e `||`.

### Operadores Lógicos Booleanos (`&` e `|`)

Estes operadores são similares a `&&` e `||`, mas com uma diferença fundamental: eles **sempre avaliam ambos os operandos**, ou seja, não fazem short-circuiting. Seu uso é raro em lógica condicional do dia a dia.

| Operador | Nome | Exemplo | Descrição |
| :--- | :--- | :--- | :--- |
| `&` | E (AND) Lógico | `expr1 & expr2` | Retorna `true` se ambas forem `true`. **Sempre avalia as duas expressões.** |
| `|` | OU (OR) Lógico | `expr1 | expr2` | Retorna `true` se uma delas for `true`. **Sempre avalia as duas expressões.** |
| `^` | OU Exclusivo (XOR) | `expr1 ^ expr2` | Retorna `true` se **apenas uma** das expressões for `true`. |

### Operadores Bitwise (`&`, `|`, `^`, `~`, `<<`, `>>`)

Quando usados com tipos de dados **inteiros** (`int`, `long`, `byte`, etc.), estes símbolos atuam como operadores *bitwise*. Eles manipulam a representação binária (os bits) dos números, sendo usados em cenários de baixo nível, como manipulação de flags, criptografia ou otimizações de performance.

-   `&` (AND): Compara os bits de dois números. Um bit de resultado é 1 somente se ambos os bits correspondentes forem 1.
-   `|` (OR): Compara os bits. Um bit de resultado é 1 se pelo menos um dos bits correspondentes for 1.
-   `^` (XOR): Compara os bits. Um bit de resultado é 1 se os bits correspondentes forem diferentes.
-   `~` (NOT): Inverte todos os bits de um número.
-   `<<` (Shift Left): Desloca os bits para a esquerda, preenchendo com zeros (multiplicação por 2).
-   `>>` (Shift Right): Desloca os bits para a direita (divisão por 2).

```c#
// Exemplo de Bitwise AND
//   5 = 0101 (binário)
//   3 = 0011 (binário)
// -------------------
// AND = 0001 (binário) = 1 (decimal)
int resultado = 5 & 3;
Console.WriteLine(resultado); // Saída: 1
```
