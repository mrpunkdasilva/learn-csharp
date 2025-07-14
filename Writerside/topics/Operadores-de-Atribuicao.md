# Operadores de Atribuição

Operadores de atribuição são usados para designar um valor a uma variável. O operador de atribuição fundamental é o sinal de igual (`=`), que atribui o valor do operando à direita para a variável à esquerda.

```c#
// A variável 'idade' recebe o valor 30.
int idade = 30;

// A variável 'nome' recebe o valor da string "Alice".
string nome = "Alice";
```

## Operadores de Atribuição Composta

C# oferece operadores de atribuição composta que combinam uma operação aritmética com a atribuição. Eles são atalhos úteis que tornam o código mais conciso e, em alguns casos, mais eficiente.

A expressão `x op= y` é, em geral, equivalente a `x = x op y`, onde `op` é um operador aritmético.

### Tabela de Operadores de Atribuição Composta

| Operador | Exemplo | Equivalente a | Descrição |
| :--- | :--- | :--- | :--- |
| `+=` | `x += y` | `x = x + y` | Adiciona `y` a `x` e atribui o resultado a `x`. |
| `-=` | `x -= y` | `x = x - y` | Subtrai `y` de `x` e atribui o resultado a `x`. |
| `*=` | `x *= y` | `x = x * y` | Multiplica `x` por `y` e atribui o resultado a `x`. |
| `/=` | `x /= y` | `x = x / y` | Divide `x` por `y` e atribui o resultado a `x`. |
| `%=` | `x %= y` | `x = x % y` | Calcula o resto da divisão de `x` por `y` e atribui a `x`. |

### Exemplos Práticos

```c#
int saldo = 100;

saldo += 50; // saldo agora é 150 (100 + 50)
Console.WriteLine($"Após depósito: {saldo}");

saldo -= 30; // saldo agora é 120 (150 - 30)
Console.WriteLine($"Após saque: {saldo}");

int multiplicador = 5;
multiplicador *= 2; // multiplicador agora é 10 (5 * 2)
Console.WriteLine($"Multiplicado: {multiplicador}");

int dividendo = 20;
dividendo /= 4; // dividendo agora é 5 (20 / 4)
Console.WriteLine($"Dividido: {dividendo}");

int resto = 10;
resto %= 3; // resto agora é 1 (10 % 3)
Console.WriteLine($"Resto: {resto}");
```

<note>
O uso de operadores de atribuição composta é considerado uma boa prática em C#, pois pode levar a um código mais limpo e fácil de ler, especialmente em operações de atualização de variáveis.
</note>