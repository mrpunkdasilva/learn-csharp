# Operadores de Comparação

Operadores de comparação (ou relacionais) são usados para comparar dois operandos. O resultado de uma operação de comparação é sempre um valor booleano: `true` ou `false`. Eles são a base para a tomada de decisões e o controle de fluxo em C#, sendo essenciais em estruturas como `if`, `while` e `for`.

## Tabela de Operadores de Comparação

| Operador | Descrição | Exemplo (com `a = 5`, `b = 10`) | Resultado |
| :--- | :--- | :--- | :--- |
| `==` | **Igual a** | `a == 5` | `true` |
| `!=` | **Diferente de** | `a != b` | `true` |
| `<` | **Menor que** | `a < b` | `true` |
| `>` | **Maior que** | `a > b` | `false` |
| `<=` | **Menor ou igual a** | `a <= 5` | `true` |
| `>=` | **Maior ou igual a** | `b >= 10` | `true` |

## Exemplos de Uso no Controle de Fluxo

O principal uso dos operadores de comparação é em declarações condicionais para direcionar o fluxo do programa.

```c#
int idade = 18;

// Usando '==' para verificar igualdade
if (idade == 18)
{
    Console.WriteLine("Tem exatamente 18 anos.");
}

// Usando '>=' para verificar maioridade
if (idade >= 18)
{
    Console.WriteLine("É maior de idade.");
}

// Usando '!=' para verificar diferença
string nome = "Alice";
if (nome != "Bob")
{
    Console.WriteLine("O nome não é Bob.");
}

// Usando em um loop 'while'
int contador = 0;
while (contador < 5)
{
    Console.WriteLine($"O contador é {contador}");
    contador++; // Essencial para evitar um loop infinito
}
```

## Comparando Tipos de Referência vs. Tipos de Valor

É crucial entender a diferença ao usar `==` com tipos de valor e tipos de referência.

-   **Tipos de Valor (`int`, `double`, `bool`, `struct`)**: O operador `==` compara os **valores reais** contidos nas variáveis.

    ```c#
    int a = 10;
    int b = 10;
    Console.WriteLine(a == b); // Saída: true (porque 10 é igual a 10)
    ```

-   **Tipos de Referência (`string`, `class`, `array`)**: Por padrão, o operador `==` compara as **referências de memória**, ou seja, ele verifica se as duas variáveis apontam para o **mesmo objeto** na memória, e não se seus conteúdos são iguais.

    ```c#
    public class Pessoa { public string Nome { get; set; } }

    Pessoa p1 = new Pessoa { Nome = "Alex" };
    Pessoa p2 = new Pessoa { Nome = "Alex" };
    Pessoa p3 = p1;

    Console.WriteLine(p1 == p2); // Saída: false (são dois objetos diferentes na memória)
    Console.WriteLine(p1 == p3); // Saída: true (ambos apontam para o mesmo objeto)
    ```

<note>
O tipo `string` é uma exceção especial. Embora seja um tipo de referência, o operador `==` foi sobrecarregado para comparar o **conteúdo** das strings, não suas referências. Portanto, `"hello" == "hello"` retorna `true`, que é o comportamento que a maioria dos desenvolvedores espera.
</note>
