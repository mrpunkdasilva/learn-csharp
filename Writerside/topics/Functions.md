# Funções (Métodos com Retorno)

Em programação, uma "função" é um bloco de código reutilizável que executa uma tarefa e **retorna um valor**. Em C#, o termo técnico é **método com tipo de retorno**. A principal finalidade de uma função é processar dados de entrada e produzir um resultado, sem (idealmente) causar efeitos colaterais em outras partes do programa.

## Declaração

A sintaxe para declarar um método com retorno é:

```c#
[modificador_de_acesso] static [tipo_de_retorno] [NomeDaFuncao]([parametros])
{
    // Corpo da função
    return [valor_a_retornar];
}
```

- **`[tipo_de_retorno]`**: O tipo de dado que a função irá retornar (`int`, `string`, `bool`, ou um tipo complexo). **Não pode ser `void`**.
- **`return`**: A palavra-chave que envia o resultado de volta e encerra a função. O valor retornado **deve ser compatível** com o `tipo_de_retorno`.

### Exemplo: Função Pura

Uma função "pura" é aquela cujo resultado depende exclusivamente de seus parâmetros de entrada, sem interagir com ou modificar estados externos. Elas são previsíveis e fáceis de testar.

```c#
// Função pura que calcula o preço com desconto
public static decimal CalcularPrecoFinal(decimal precoOriginal, decimal percentualDesconto)
{
    decimal valorDesconto = precoOriginal * (percentualDesconto / 100);
    return precoOriginal - valorDesconto;
}

// Uso
decimal preco = CalcularPrecoFinal(150.0m, 10.0m); // Retorna 135.0m
```

## Parâmetros Avançados

### Passagem por Referência: `ref` vs. `out`

Por padrão, os tipos de valor (como `int`, `double`, `bool`) são passados para métodos **por valor** (*pass-by-value*). Isso significa que o método recebe uma **cópia** da variável, e qualquer alteração dentro do método não afeta a variável original.

As palavras-chave `ref` e `out` mudam esse comportamento, permitindo passar a variável **por referência** (*pass-by-reference*). O método recebe uma referência à localização da variável na memória, permitindo que ele modifique o valor original. Embora pareçam semelhantes, eles têm propósitos e regras diferentes.

#### A Palavra-Chave `ref`

Usa-se `ref` quando você quer que um método **leia e potencialmente modifique** uma variável existente.

**Contrato do `ref`:**
1.  A variável **deve** ser inicializada pelo código que chama o método antes de ser passada.
2.  O método pode ler o valor do parâmetro antes de modificá-lo.

**Caso de Uso:** Ideal para quando uma função precisa alterar o estado de uma variável de entrada. Pense em um fluxo de dados **bidirecional**: o valor entra no método e pode sair modificado.

```c#
// Função que adiciona juros a um saldo existente
public static void AdicionarJuros(ref decimal saldo, decimal taxaDeJuros)
{
    decimal juros = saldo * taxaDeJuros;
    saldo += juros; // Modifica a variável original
}

// Uso
decimal minhaPoupanca = 1000m;
AdicionarJuros(ref minhaPoupanca, 0.05m);
Console.WriteLine(minhaPoupanca); // Saída: 1050
```

#### A Palavra-Chave `out`

Usa-se `out` quando o propósito principal de um método é **retornar múltiplos valores** ou quando uma operação de "tentativa" (como `TryParse`) precisa retornar um status de sucesso (`bool`) e o resultado da operação.

**Contrato do `out`:**
1.  A variável passada como `out` **não precisa** ser inicializada antes da chamada.
2.  O método **é obrigado** a atribuir um valor ao parâmetro `out` antes de retornar.
3.  O método não pode ler o valor do parâmetro `out` antes de atribuir um valor a ele.

**Caso de Uso:** Perfeito para quando uma função precisa "produzir" um valor sem ter um valor de entrada. O fluxo de dados é **unidirecional**: o valor apenas **sai** do método.

```c#
// Função que tenta dividir e retorna o quociente e o resto
public static bool TentarDividir(int dividendo, int divisor, out int quociente, out int resto)
{
    quociente = 0;
    resto = 0;
    if (divisor == 0)
    {
        return false; // Falha na operação
    }

    quociente = dividendo / divisor;
    resto = dividendo % divisor;
    return true; // Sucesso
}

// Uso
if (TentarDividir(10, 3, out int q, out int r))
{
    Console.WriteLine($"Quociente: {q}, Resto: {r}"); // Saída: Quociente: 3, Resto: 1
}
```

### Tabela Comparativa: `ref` vs. `out`

| Característica | `ref` | `out` |
| :--- | :--- | :--- |
| **Propósito** | Modificar uma variável existente. | Retornar um ou mais valores. |
| **Inicialização** | **Obrigatória** antes da chamada. | **Não necessária** antes da chamada. |
| **Atribuição no Método** | Opcional. | **Obrigatória** antes do retorno. |
| **Fluxo de Dados** | Bidirecional (Entrada e Saída). | Unidirecional (Apenas Saída). |

### Parâmetros Opcionais e Argumentos Nomeados

Você pode atribuir valores padrão aos parâmetros, tornando-os opcionais. Para evitar ambiguidade, você pode usar argumentos nomeados na chamada da função.

```c#
// 'logCompleto' é um parâmetro opcional
public static void RegistrarLog(string mensagem, bool logCompleto = false)
{
    string timestamp = DateTime.Now.ToString();
    if (logCompleto)
    {
        Console.WriteLine($"[LOG COMPLETO - {timestamp}] {mensagem}");
    }
    else
    {
        Console.WriteLine($"[LOG - {timestamp}] {mensagem}");
    }
}

// Uso
RegistrarLog("Iniciando processo..."); // Usa o valor padrão (false)
RegistrarLog("Erro crítico!", true); // Passa o valor explicitamente
RegistrarLog(logCompleto: true, mensagem: "Ordem invertida com argumentos nomeados.");
```

## Funções Recursivas

Uma função recursiva é aquela que chama a si mesma. É uma técnica poderosa para resolver problemas que podem ser divididos em subproblemas menores e idênticos. É crucial ter uma **condição de parada** para evitar um loop infinito (*stack overflow*).

```c#
// Calcula o fatorial de um número usando recursão
public static int Fatorial(int n)
{
    // Condição de parada
    if (n == 0)
    {
        return 1;
    }
    
    // Chamada recursiva
    return n * Fatorial(n - 1);
}

// Uso
int resultado = Fatorial(5); // 5 * 4 * 3 * 2 * 1 = 120
```

## Expression-Bodied Members (`=>`)

Para funções que contêm apenas uma única instrução `return`, você pode usar uma sintaxe mais concisa com `=>`.

```c#
// Função de soma reescrita
public static int Somar(int a, int b) => a + b;

// Função Fatorial reescrita com expressão condicional ternária
public static int Fatorial(int n) => n == 0 ? 1 : n * Fatorial(n - 1);
```