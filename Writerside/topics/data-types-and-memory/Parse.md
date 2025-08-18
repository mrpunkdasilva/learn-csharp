# Parse

O método `Parse` é uma funcionalidade estática presente na maioria dos tipos de valor do C# (como `int`, `double`, `bool`, `DateTime`, etc.). Sua função específica é converter a **representação em string** de um valor em uma instância real daquele tipo.

É a ferramenta ideal quando você tem um texto e precisa que ele se torne um tipo de dado funcional.

```c#
string textoNumero = "123";

// O método Parse converte a string "123" para o inteiro 123.
int numero = int.Parse(textoNumero);

Console.WriteLine(numero * 2); // Saída: 246
Console.WriteLine(numero.GetType().Name); // Saída: Int32
```

## O Risco do `Parse`: Exceções

O método `Parse` é otimista: ele assume que a conversão será bem-sucedida. Se a string de entrada não estiver em um formato válido ou for nula, ele lançará uma exceção, interrompendo o fluxo normal do programa.

- **`FormatException`**: A string não corresponde ao formato esperado.
- **`ArgumentNullException`**: A string fornecida é `null`.
- **`OverflowException`**: O número na string é grande ou pequeno demais para o tipo de destino.

Para usar `Parse` de forma segura, você deve envolvê-lo em um bloco `try-catch`:

```c#
string entradaUsuario = "não é um número";
try
{
    int resultado = int.Parse(entradaUsuario);
    Console.WriteLine($"Conversão bem-sucedida: {resultado}");
}
catch (FormatException)
{
    Console.WriteLine("Erro: O formato da entrada é inválido.");
}
catch (ArgumentNullException)
{
    Console.WriteLine("Erro: A entrada não pode ser nula.");
}
```

## A Alternativa Segura e Eficiente: `TryParse`

Lançar e capturar exceções é um processo computacionalmente caro. Para cenários de validação (como processar input de um usuário), onde uma falha de conversão é um evento esperado, o C# oferece uma alternativa muito mais eficiente: o padrão `TryParse`.

O método `TryParse` tenta realizar a conversão e, em vez de lançar uma exceção, ele **retorna um `bool`** que indica se a operação foi bem-sucedida. O valor convertido é retornado através de um parâmetro `out`.

```c#
string entradaDoUsuario = "42";

// Tenta converter a string. 
// Se conseguir, 'numeroConvertido' receberá o valor 42 e o método retornará 'true'.
// Se não conseguir, 'numeroConvertido' receberá 0 (valor padrão) e o método retornará 'false'.
if (int.TryParse(entradaDoUsuario, out int numeroConvertido))
{
    // Este bloco só executa se a conversão funcionar
    Console.WriteLine($"Sucesso! O número é {numeroConvertido}");
}
else
{
    // Este bloco só executa se a conversão falhar
    Console.WriteLine("Falha na conversão. Por favor, insira um número válido.");
}
```

### Por que `TryParse` é melhor?

1.  **Performance**: Evita o alto custo de criar e gerenciar exceções.
2.  **Clareza**: O código fica mais limpo e a intenção (validar e converter) é mais clara.
3.  **Simplicidade**: Permite a validação e a atribuição em uma única linha dentro de uma condição `if`.

## Tabela de Referência de Métodos `Parse` e `TryParse`

Abaixo está uma tabela de referência para os métodos `Parse` e `TryParse` nos tipos mais comuns.

| Tipo | Método `Parse` (Lança Exceção) | Método `TryParse` (Retorna `bool`) |
| :--- | :--- | :--- |
| `int` | `int.Parse(str)` | `int.TryParse(str, out int val)` |
| `long` | `long.Parse(str)` | `long.TryParse(str, out long val)` |
| `double` | `double.Parse(str)` | `double.TryParse(str, out double val)` |
| `decimal` | `decimal.Parse(str)` | `decimal.TryParse(str, out decimal val)` |
| `float` | `float.Parse(str)` | `float.TryParse(str, out float val)` |
| `bool` | `bool.Parse(str)` | `bool.TryParse(str, out bool val)` |
| `DateTime` | `DateTime.Parse(str)` | `DateTime.TryParse(str, out DateTime val)` |
| `Guid` | `Guid.Parse(str)` | `Guid.TryParse(str, out Guid val)` |


## Tópico Avançado: Sensibilidade à Cultura

Um detalhe crucial que diferencia um desenvolvedor sênior é o entendimento sobre **cultura** (`CultureInfo`). O método `Parse` por padrão utiliza as regras de formatação do sistema operacional onde o código está rodando.

Isso pode causar bugs difíceis de rastrear. Por exemplo, a string `"1,234.56"` representa mil duzentos e trinta e quatro em português, mas em inglês o `.` é o separador decimal.

```c#
using System.Globalization;

string numeroAlemao = "1.234,56"; // Ponto como separador de milhar, vírgula como decimal

// Usando a cultura alemã (de-DE) para interpretar a string corretamente
CultureInfo culturaAlema = new CultureInfo("de-DE");
double valor = double.Parse(numeroAlemao, culturaAlema);

Console.WriteLine(valor); // Saída: 1234.56 (convertido para o formato padrão do sistema)

// A linha abaixo lançaria uma FormatException em um sistema com cultura pt-BR ou en-US
// double valorIncorreto = double.Parse(numeroAlemao); 
```

O `TryParse` também possui sobrecargas que aceitam `CultureInfo` para uma conversão segura e culturalmente correta.

## Guia de Decisão: `Parse` vs. `TryParse`

-   **Use `Parse` quando:**
    -   Você tem **100% de certeza** que a string é válida (ex: vem de uma fonte interna confiável, como um valor fixo no código ou um banco de dados com dados já validados).
    -   Uma falha na conversão representa um **erro excepcional e inesperado** no seu sistema.

-   **Use `TryParse` quando:**
    -   A string vem de uma fonte externa e **não confiável** (input de usuário, arquivo de texto, resposta de API, etc.).
    -   A falha na conversão é um **cenário esperado** e faz parte da lógica de validação do seu programa.
