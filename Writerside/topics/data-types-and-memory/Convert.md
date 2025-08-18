
# Convert

A classe `System.Convert` é uma ferramenta essencial no C#, fornecendo um conjunto de métodos estáticos para realizar conversões entre os tipos de dados base (primitivos). Ela atua como uma solução robusta e explícita, oferecendo mais flexibilidade e segurança em comparação com o casting direto ou os métodos `Parse`.

Pense na classe `Convert` como um tradutor universal para os tipos de dados do .NET.

## `Convert` vs. Casting vs. `Parse`

É crucial para um desenvolvedor C# entender quando usar cada mecanismo de conversão.

| Mecanismo | Sintaxe | Uso Principal | Comportamento em Falha |
| :--- | :--- | :--- | :--- |
| **Casting** | `(novoTipo)valor;` | Entre tipos numéricos compatíveis ou em hierarquias de classes (upcasting/downcasting). | `InvalidCastException` em tempo de execução se a conversão for inválida. |
| **Parse** | `tipo.Parse(string);` | **Exclusivamente** para converter uma `string` em seu tipo correspondente. | `FormatException` se a string não estiver no formato correto; `ArgumentNullException` se for nula. |
| **Convert** | `Convert.ToNovoTipo(valor);` | Entre uma grande variedade de tipos (números, strings, booleanos, objetos, etc.). | `FormatException` para strings mal formatadas; `OverflowException` para estouro de capacidade. |

### A Grande Vantagem: Tratamento de `null`

A principal diferença e vantagem da classe `Convert` é a forma como ela lida com valores `null`. Ao contrário do casting ou do `Parse`, que lançam uma exceção, `Convert` retorna o **valor padrão** do tipo de destino.

```c#
string textoNulo = null;

// Lança ArgumentNullException
// int numeroComParse = int.Parse(textoNulo); 

// Retorna 0 (valor padrão de int)
int numeroComConvert = Convert.ToInt32(textoNulo); 

Console.WriteLine(numeroComConvert); // Saída: 0
```

Esse comportamento torna o `Convert` a escolha mais segura e previsível ao lidar com dados que podem ser nulos, como valores vindos de bancos de dados, APIs ou input do usuário.

## Comportamento de Arredondamento

Ao converter um número de ponto flutuante (como `double` ou `float`) para um inteiro, a classe `Convert` utiliza o **"Arredondamento do Banqueiro"** (`MidpointRounding.ToEven`). Neste método, números que estão exatamente no meio (como 2.5 ou 3.5) são arredondados para o número par mais próximo.

```c#
double valor1 = 2.5;
double valor2 = 3.5;
double valor3 = 4.6;

Console.WriteLine(Convert.ToInt32(valor1)); // Saída: 2 (arredonda para o par mais próximo)
Console.WriteLine(Convert.ToInt32(valor2)); // Saída: 4 (arredonda para o par mais próximo)
Console.WriteLine(Convert.ToInt32(valor3)); // Saída: 5 (arredondamento normal)
```

## Exemplos de Conversões Comuns

A classe `Convert` é extremamente versátil.

```c#
// De string para int
string strNumero = "123";
int numero = Convert.ToInt32(strNumero);

// De int para string
int valorInt = 456;
string strValor = Convert.ToString(valorInt);

// De double para int (com arredondamento)
double salario = 2589.72;
int salarioInt = Convert.ToInt32(salario); // Resultado: 2590

// De string para booleano (não diferencia maiúsculas/minúsculas)
string strBool = "True";
bool valorBool = Convert.ToBoolean(strBool); // Resultado: true

// De qualquer tipo para string
bool ativo = false;
string strAtivo = Convert.ToString(ativo); // Resultado: "False"

// De object para int (seguro contra nulos)
object objValor = null;
int valorObj = Convert.ToInt32(objValor); // Resultado: 0
```

## Tabela de Referência de Métodos `Convert`

Abaixo está uma tabela de referência rápida para os métodos de conversão mais utilizados da classe `Convert`.

| Método | Descrição | Exemplo de Uso |
| :--- | :--- | :--- |
| `Convert.ToBoolean(valor)` | Converte um valor (string, número, etc.) para `bool`. | `bool b = Convert.ToBoolean("true");` |
| `Convert.ToByte(valor)` | Converte um valor para `byte` (inteiro de 8 bits sem sinal). | `byte y = Convert.ToByte(12);` |
| `Convert.ToChar(valor)` | Converte uma string de um caractere ou número para `char`. | `char c = Convert.ToChar('A');` |
| `Convert.ToDateTime(valor)` | Converte uma string (em formato de data/hora válido) para `DateTime`. | `DateTime dt = Convert.ToDateTime("2025-07-14");` |
| `Convert.ToDecimal(valor)` | Converte um valor para `decimal` (alta precisão). | `decimal d = Convert.ToDecimal("123.45");` |
| `Convert.ToDouble(valor)` | Converte um valor para `double` (ponto flutuante de precisão dupla). | `double o = Convert.ToDouble("123.45");` |
| `Convert.ToInt16(valor)` | Converte um valor para `short` (inteiro de 16 bits). | `short s = Convert.ToInt16("123");` |
| `Convert.ToInt32(valor)` | Converte um valor para `int` (inteiro de 32 bits). | `int i = Convert.ToInt32("123");` |
| `Convert.ToInt64(valor)` | Converte um valor para `long` (inteiro de 64 bits). | `long l = Convert.ToInt64("123");` |
| `Convert.ToString(valor)` | Converte qualquer tipo base para sua representação em `string`. | `string str = Convert.ToString(123.45);` |


## Tópico Avançado: Conversão de Base Numérica

Um recurso poderoso e muitas vezes subutilizado da classe `Convert` é a capacidade de converter números entre diferentes bases (binário, octal, decimal, hexadecimal).

```c#
// Convertendo um inteiro para sua representação em string binária e hexadecimal
int numeroDecimal = 255;
string binario = Convert.ToString(numeroDecimal, 2);    // Base 2
string hexadecimal = Convert.ToString(numeroDecimal, 16); // Base 16

Console.WriteLine($"Decimal: {numeroDecimal}");   // Saída: Decimal: 255
Console.WriteLine($"Binário: {binario}");       // Saída: Binário: 11111111
Console.WriteLine($"Hexadecimal: {hexadecimal.ToUpper()}"); // Saída: Hexadecimal: FF

// Convertendo de volta para inteiro
int deBinario = Convert.ToInt32("11111111", 2);
int deHexadecimal = Convert.ToInt32("FF", 16);

Console.WriteLine($"De Binário: {deBinario}");       // Saída: De Binário: 255
Console.WriteLine($"De Hexadecimal: {deHexadecimal}"); // Saída: De Hexadecimal: 255
```

## Tratamento de Exceções

Apesar de sua flexibilidade, `Convert` ainda pode lançar exceções se a conversão for impossível.

- **`FormatException`**: Ocorre se uma string de entrada não estiver em um formato válido para o tipo de destino.
- **`OverflowException`**: Ocorre se o número de origem for muito grande (ou muito pequeno) para caber na capacidade do tipo de destino.

É uma boa prática envolver as chamadas de `Convert` em um bloco `try-catch` quando a entrada não for confiável.

```c#
string valorGigante = "9999999999999999999999999999";
try
{
    int resultado = Convert.ToInt32(valorGigante);
    Console.WriteLine(resultado);
}
catch (FormatException ex)
{
    Console.WriteLine("Erro de formato: A string não é um número válido.");
}
catch (OverflowException ex)
{
    Console.WriteLine("Erro de Overflow: O número é grande demais para um inteiro.");
}
```

> Para cenários onde você espera que a conversão de uma string possa falhar e não quer lidar com exceções, a abordagem `tipo.TryParse()` continua sendo a melhor prática.

