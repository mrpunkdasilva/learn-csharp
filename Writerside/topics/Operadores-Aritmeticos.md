# Operadores Aritméticos

Operadores aritméticos são símbolos usados para realizar cálculos matemáticos em operandos numéricos. São a base da manipulação de números em C#.

## Tabela de Operadores Aritméticos

| Operador | Descrição | Exemplo | Resultado |
| :--- | :--- | :--- | :--- |
| `+` | Adição | `5 + 3` | `8` |
| `-` | Subtração | `5 - 3` | `2` |
| `*` | Multiplicação | `5 * 3` | `15` |
| `/` | Divisão | `5 / 3` | `1` |
| `%` | Módulo (Resto da Divisão) | `5 % 3` | `2` |

### A Armadilha da Divisão de Inteiros

Um ponto de atenção crucial em C# é a divisão entre dois números inteiros. O resultado será **sempre um inteiro**, com a parte decimal sendo **truncada** (removida), não arredondada.

```c#
int a = 5;
int b = 3;

// Como 'a' e 'b' são inteiros, o resultado é 1, não 1.66.
int resultadoInteiro = a / b; 
Console.WriteLine(resultadoInteiro); // Saída: 1
```

Para obter um resultado com precisão decimal, pelo menos um dos operandos deve ser um tipo de ponto flutuante (`double`, `float`, `decimal`).

```c#
// Convertendo (casting) um dos inteiros para double antes da divisão
double resultadoDouble = (double)a / b;
Console.WriteLine(resultadoDouble); // Saída: 1.66666...
```

## Operadores de Incremento e Decremento

Estes operadores unários modificam uma variável, adicionando ou subtraindo 1. A posição do operador (`++` ou `--`) em relação à variável muda o comportamento da expressão.

- **Pós-fixado (`variavel++` ou `variavel--`)**: O valor da variável é **primeiro retornado** para a expressão e **depois** modificado.
- **Pré-fixado (`++variavel` ou `--variavel`)**: O valor da variável é **primeiro modificado** e **depois** o novo valor é retornado para a expressão.

```c#
int a = 5;
int b = 5;

// Pós-fixado: 'c' recebe o valor original de 'a' (5), depois 'a' vira 6.
int c = a++; 

// Pré-fixado: 'b' primeiro vira 6, depois 'd' recebe o novo valor de 'b' (6).
int d = ++b;

Console.WriteLine($"a: {a}, c: {c}"); // Saída: a: 6, c: 5
Console.WriteLine($"b: {b}, d: {d}"); // Saída: b: 6, d: 6
```

## Precedência de Operadores

A precedência define a ordem em que as operações são executadas em uma expressão complexa. Operadores com maior precedência são avaliados primeiro.

| Ordem | Categoria | Operadores |
| :--- | :--- | :--- |
| 1 | Primário | `()` (Parênteses para forçar a ordem) |
| 2 | Unário | `++` (pré-fixado), `--` (pré-fixado), `+` (positivo), `-` (negativo) |
| 3 | Multiplicativo | `*`, `/`, `%` |
| 4 | Aditivo | `+`, `-` |
| 5 | Pós-fixado | `++` (pós-fixado), `--` (pós-fixado) |

<note>
O operador de exponenciação (`**`) não existe em C#. Para cálculos de potência, utilize o método `Math.Pow(base, expoente)`.
</note>

Você pode usar parênteses `()` para forçar uma ordem de avaliação diferente da padrão, o que também melhora a legibilidade do código.

```c#
// Sem parênteses: 2 * 3 = 6, depois 6 + 4 = 10
int resultado1 = 2 * 3 + 4; // resultado1 = 10

// Com parênteses: 3 + 4 = 7, depois 2 * 7 = 14
int resultado2 = 2 * (3 + 4); // resultado2 = 14
```
