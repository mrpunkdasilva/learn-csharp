# Constantes

Uma constante (`const`) é um campo cujo valor é definido em tempo de compilação e não pode ser alterado durante a execução do programa. Pense nela como um valor fixo e imutável.

<warning>

**Regra Fundamental:** Uma constante **deve obrigatoriamente** ser inicializada no momento em que é declarada. Tentar declarar uma constante sem um valor resultará em um erro de compilação.

</warning>

**Exemplo de Declaração Correta:**

```c#
const double PI = 3.14159;
const string NOME_EMPRESA = "MinhaApp";
```

**Convenção de Nomenclatura:** Por convenção, nomes de constantes em C# são escritos em `PascalCase` ou `ALL_CAPS_SNAKE_CASE` para distingui-los claramente de variáveis.

## Características das Constantes (`const`)

1.  **Valor em Tempo de Compilação:** O valor de uma `const` é gravado diretamente no assembly do programa. O compilador substitui o uso da constante pelo seu valor literal em todo o código (semelhante a um "localizar e substituir").
2.  **Tipos Permitidos:** Só podem ser dos tipos primitivos do C# (todos os tipos numéricos, `bool`, `char`, `string`) ou um tipo `enum`.
3.  **Implicitamente Estáticas:** Uma `const` é sempre estática (`static`), mesmo que a palavra-chave `static` não seja usada. Ela pertence ao tipo, não a uma instância do objeto.

## `const` vs. `readonly`: Qual a Diferença?

Este é um ponto crucial que diferencia desenvolvedores experientes. C# também possui a palavra-chave `readonly`, que parece similar, mas tem um propósito diferente.

-   **`readonly` (Constante de Tempo de Execução):** Um campo `readonly` também não pode ser alterado *após sua inicialização*. No entanto, sua inicialização pode ocorrer na declaração **ou** dentro do construtor da classe. Isso permite que cada instância de um objeto tenha um valor `readonly` diferente.

**Tabela Comparativa:**

| Característica | `const` | `readonly` |
| :--- | :--- | :--- |
| **Quando o valor é definido?** | Tempo de Compilação | Tempo de Execução (no construtor) |
| **Pode ser diferente por instância?** | Não (é estático) | Sim (pode ser de instância) |
| **Pode ser de qualquer tipo?** | Não (só primitivos/enum) | Sim (qualquer tipo, incluindo objetos) |
| **Pode ser `static`?** | Sim (implicitamente) | Sim (explicitamente, `static readonly`) |

**Exemplo Prático:**

```c#
public class Circulo
{
    // 'PI' é o mesmo para todos os círculos. É uma constante de compilação.
    public const double PI = 3.14159;

    // 'Raio' e 'DataCriacao' podem ser diferentes para cada objeto Circulo.
    // Seus valores são definidos quando o objeto é criado e não podem ser mudados depois.
    public readonly double Raio;
    public readonly DateTime DataCriacao;

    public Circulo(double raio)
    {
        this.Raio = raio; // Inicialização de campo readonly no construtor
        this.DataCriacao = DateTime.Now;
    }
}

// Uso
Circulo c1 = new Circulo(5.0);
Circulo c2 = new Circulo(10.0);

// c1.Raio é 5.0, c2.Raio é 10.0. Ambos são imutáveis após a criação.
// Tentar fazer 'c1.Raio = 7.0;' resultaria em um erro de compilação.
```

### Quando Usar Qual?

-   **Use `const`:** Para valores que são verdadeiramente universais e imutáveis, conhecidos antes mesmo do programa rodar (ex: `Math.PI`, número de meses no ano, uma string de conexão padrão para um ambiente de teste).
-   **Use `readonly`:** Para valores que são específicos de uma instância de um objeto e que não devem mudar após a sua criação (ex: um ID de usuário, a data de criação de um registro).
