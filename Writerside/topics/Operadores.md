# Operadores Aritméticos

São operadores que realizam cálculos matemáticos. Exemplos:

```c#
int soma = 10 + 5;
double divisao = 2 / 3; // retorna um número inteiro, pois ambos são inteiros.
```

## Tabela de Operadores Aritméticos

| Operador | Descrição |
| --- | --- |
| `+` | Adição |
| `-` | Subtração |
| `*` | Multiplicação |
| `/` | Divisão |
| `%` | Módulo (resto da divisão) |
| `++` | Incremento |
| `--` | Decremento |

### Incremento e Decremento

O incremento (`++`) aumenta o valor em 1, enquanto o decremento (`--`) diminui o valor em 1.

```c#
int numero = 5;
numero++; // agora numero é igual a 6
numero--; // agora numero é igual a 5 novamente
```

## Precedência dos Operadores Aritiméticos

A precedência determina a ordem em que os operadores serão avaliados na expressão. Em geral, a multiplicação e a divisão têm maior precedência do que a adição e subtração. Por exemplo:

```c#
int resultado = 2 * 3 + 4; // primeiro realiza a multiplicação, depois a adição: resultado será igual a 10
```
### Tabela da Drdem Precedência de Operadores Aritméticos:

| Operador | Descrição |
| --- | --- |
| `()` | Parênteses |
| `**` | Exponenciação |
| `*`, `/`, `%` | Multiplicação, Divisão e Módulo |
| `+`, `-` | Adição e Subtração |
| `++`, `--` | Incremento e Decremento |