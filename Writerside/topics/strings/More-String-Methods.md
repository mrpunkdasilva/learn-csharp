# Mais Métodos e Conceitos

No desenvolvimento de software, a manipulação de texto é uma tarefa constante. À medida que os sistemas crescem em complexidade e performance se torna um fator crítico, é essencial ir além dos métodos básicos de string e explorar ferramentas mais poderosas e eficientes. Este documento apresenta uma seleção de métodos e conceitos avançados que permitem um controle mais granular e otimizado sobre as operações com strings no C#.

## 1. Otimização de Memória: String Pooling (`string.Intern()`, `string.IsInterned()`)

Imagine que você tem uma biblioteca com muitos livros, e vários deles têm o mesmo título. Em vez de ter várias cópias físicas do mesmo título, a biblioteca decide ter apenas uma cópia e várias referências a ela. No C#, o *string pooling* (ou interning) funciona de forma semelhante para otimizar o uso de memória, especialmente para strings literais e strings frequentemente repetidas.

Quando uma string é *interned*, o Common Language Runtime (CLR) a armazena em um pool interno. Se outra string com o mesmo valor for criada, em vez de alocar nova memória, o CLR retorna uma referência à instância existente no pool.

### `string.Intern(string str)`

Adiciona a string especificada ao pool de interning. Se a string já estiver no pool, retorna a referência à instância existente.

### `string.IsInterned(string str)`

Verifica se a string especificada já está no pool de interning. Retorna a referência à instância interned se estiver, caso contrário, retorna `null`.

```c#
string s1 = "Hello World";
string s2 = "Hello World";
string s3 = new StringBuilder().Append("Hello").Append(" World").ToString();

// s1 and s2 are string literals, they are automatically interned by the CLR
bool areSameReference1 = ReferenceEquals(s1, s2); // Result: true
Console.WriteLine($"s1 and s2 are same reference: {areSameReference1}");

// s3 is created at runtime, so it's a new object
bool areSameReference2 = ReferenceEquals(s1, s3); // Result: false
Console.WriteLine($"s1 and s3 are same reference (before intern): {areSameReference2}");

// Intern s3
string s3Interned = string.Intern(s3);

bool areSameReference3 = ReferenceEquals(s1, s3Interned); // Result: true
Console.WriteLine($"s1 and s3Interned are same reference (after intern): {areSameReference3}");

// Check if a string is interned
string internedCheck1 = string.IsInterned(s1); // Result: "Hello World"
string internedCheck2 = string.IsInterned(s3); // Result: "Hello World" (after s3 was interned)
string internedCheck3 = string.IsInterned("Another String"); // Result: null (if not interned yet)
Console.WriteLine($"Is s1 interned? {internedCheck1 != null}");
Console.WriteLine($"Is s3 interned? {internedCheck2 != null}");
Console.WriteLine($"Is 'Another String' interned? {internedCheck3 != null}");
```

**Termos Técnicos:**

*   **String Pooling (Interning):** Um mecanismo de otimização de memória onde strings com o mesmo valor são armazenadas como uma única instância na memória.
*   **CLR (Common Language Runtime):** O ambiente de execução do .NET que gerencia a execução de programas.
*   **`ReferenceEquals()`:** Um método estático que verifica se duas referências de objeto apontam para a mesma instância na memória.

## 2. Construção Eficiente de Strings: `StringBuilder`

Imagine que você está construindo uma parede tijolo por tijolo. Se você tivesse que demolir a parede inteira e reconstruí-la do zero a cada novo tijolo, seria muito ineficiente. Strings em C# são imutáveis, o que significa que cada operação que "modifica" uma string na verdade cria uma nova. Para cenários onde você precisa realizar muitas concatenações ou modificações em uma string, `StringBuilder` é a ferramenta ideal, pois ela permite a modificação eficiente de uma sequência de caracteres sem criar novas instâncias de string a cada operação.

```c#
using System.Text;

StringBuilder sb = new StringBuilder();

sb.Append("Hello");
sb.Append(" World");
sb.AppendLine(" from StringBuilder!"); // Appends text and a new line
sb.AppendFormat("The current time is {0:HH:mm:ss}", DateTime.Now); // Appends formatted text

Console.WriteLine($"StringBuilder content: {sb.ToString()}");

sb.Insert(6, "Big "); // Insert "Big " at index 6
Console.WriteLine($"After Insert: {sb.ToString()}");

sb.Replace("World", "Universe"); // Replace "World" with "Universe"
Console.WriteLine($"After Replace: {sb.ToString()}");

sb.Remove(0, 6); // Remove 6 characters from the beginning
Console.WriteLine($"After Remove: {sb.ToString()}");

// Get the final string
string finalString = sb.ToString();
Console.WriteLine($"Final String: {finalString}");
```

**Termos Técnicos:**

*   **Mutabilidade:** A capacidade de um objeto ter seu estado alterado após sua criação.
*   **`System.Text` Namespace:** O namespace que contém classes para manipulação de caracteres e codificações de texto, incluindo `StringBuilder`.

## 3. Comparação de Strings com Opções de Cultura (`string.Compare(string, string, bool, CultureInfo)`)

Embora `string.Compare` com `StringComparison` tenha sido abordado, a sobrecarga que aceita um `CultureInfo` permite especificar explicitamente as regras de comparação cultural, o que é vital para aplicações globalizadas.

```c#
using System.Globalization;

string strA = "Straße";
string strB = "strasse";

// Case-insensitive comparison using German culture
int resultGerman = string.Compare(strA, strB, true, new CultureInfo("de-DE"));
Console.WriteLine($"Compare '{strA}' and '{strB}' (German, ignore case): {resultGerman}");
// In German, 'ß' is often treated as 'ss' for case-insensitive comparisons, so result might be 0.

string strC = "file";
string strD = "File";

// Case-sensitive comparison using InvariantCulture
int resultInvariant = string.Compare(strC, strD, false, CultureInfo.InvariantCulture);
Console.WriteLine($"Compare '{strC}' and '{strD}' (Invariant, case-sensitive): {resultInvariant}");
```

**Termos Técnicos:**

*   **`CultureInfo`:** Uma classe que fornece informações sobre uma cultura específica, incluindo convenções de formatação de data, hora, números e regras de comparação de strings.
*   **`InvariantCulture`:** Uma cultura que é independente de qualquer cultura específica. É usada para operações que devem produzir resultados consistentes, independentemente das configurações de cultura do usuário.

## 4. Verificando o Tipo de Caractere (`char.IsDigit()`, `char.IsLetter()`, etc.)

Imagine que você está validando uma senha e precisa garantir que ela contenha pelo menos um número, uma letra e um símbolo. A classe `char` (que representa um único caractere) oferece métodos estáticos para verificar a categoria de um caractere, o que é muito útil para validação e análise de texto.

```c#
string password = "P@ssw0rd1!";

bool hasDigit = false;
bool hasLetter = false;
bool hasSymbol = false;

foreach (char c in password)
{
    if (char.IsDigit(c))
    {
        hasDigit = true;
    }
    else if (char.IsLetter(c))
    {
        hasLetter = true;
    }
    else if (char.IsSymbol(c) || char.IsPunctuation(c))
    {
        hasSymbol = true;
    }
}

Console.WriteLine($"Password '{password}' has digit: {hasDigit}");
Console.WriteLine($"Password '{password}' has letter: {hasLetter}");
Console.WriteLine($"Password '{password}' has symbol/punctuation: {hasSymbol}");

// Other useful char methods:
Console.WriteLine($"Is ' ' whitespace? {char.IsWhiteSpace(' ')}");
Console.WriteLine($"Is 'A' upper? {char.IsUpper('A')}");
Console.WriteLine($"Is 'a' lower? {char.IsLower('a')}");
```

**Termos Técnicos:**

*   **`char` (tipo):** Um tipo de dado que representa um único caractere Unicode.
*   **Métodos Estáticos da Classe `char`:** Funções que operam em caracteres e são chamadas diretamente na classe `char` (e.g., `char.IsDigit()`).

## 5. Removendo Caracteres Específicos com `TrimStart(char[])` e `TrimEnd(char[])`

Complementando o `Trim(char[])` já visto, estes métodos permitem remover um conjunto específico de caracteres apenas do início (`TrimStart`) ou apenas do final (`TrimEnd`) de uma string.

```c#
string rawInput = "###DATA###";
char[] trimChars = { '#' };

string startTrimmed = rawInput.TrimStart(trimChars); // Result: "DATA###"
Console.WriteLine($"Trimmed Start: '{startTrimmed}'");

string endTrimmed = rawInput.TrimEnd(trimChars); // Result: "###DATA"
Console.WriteLine($"Trimmed End: '{endTrimmed}'");
```

## 6. Verificando se a String é Numérica (`double.TryParse()`, `int.TryParse()`, etc.)

Em vez de apenas verificar se um caractere é um dígito, muitas vezes você precisa saber se uma string inteira pode ser convertida para um tipo numérico. Os métodos `TryParse()` são a maneira segura e eficiente de fazer isso, evitando exceções.

```c#
string priceText = "123.45";
string quantityText = "50";
string invalidText = "abc";

// Try parsing to double
if (double.TryParse(priceText, out double price))
{
    Console.WriteLine($"Price parsed: {price}");
}
else
{
    Console.WriteLine($"Could not parse price: {priceText}");
}

// Try parsing to int
if (int.TryParse(quantityText, out int quantity))
{
    Console.WriteLine($"Quantity parsed: {quantity}");
}
else
{
    Console.WriteLine($"Could not parse quantity: {quantityText}");
}

// Invalid parse attempt
if (!int.TryParse(invalidText, out int parsedInvalid))
{
    Console.WriteLine($"Successfully failed to parse: {invalidText}");
}
```

**Termos Técnicos:**

*   **`TryParse()`:** Um padrão de método em .NET que tenta converter uma string para um tipo específico e retorna um booleano indicando o sucesso, sem lançar uma exceção em caso de falha.
*   **`out` Keyword:** Uma palavra-chave em C# usada para passar argumentos para métodos por referência, permitindo que o método retorne valores através desses argumentos.

## 7. Comparação de Strings com RegEx (`Regex.IsMatch()`)

Para padrões de busca e validação mais complexos do que `Contains()` ou `StartsWith()`, Expressões Regulares (RegEx) são a ferramenta. `Regex.IsMatch()` verifica se uma string corresponde a um padrão RegEx.

```c#
using System.Text.RegularExpressions;

string emailAddress = "test@example.com";
string invalidEmail = "test@example";

// Regex pattern for a simple email validation
string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

bool isValidEmail1 = Regex.IsMatch(emailAddress, emailPattern);
Console.WriteLine($"'{emailAddress}' is valid email: {isValidEmail1}");

bool isValidEmail2 = Regex.IsMatch(invalidEmail, emailPattern);
Console.WriteLine($"'{invalidEmail}' is valid email: {isValidEmail2}");

// Check for a specific format, e.g., a product code like ABC-1234
string productCode = "XYZ-9876";
string productPattern = @"^[A-Z]{3}-\d{4}$";
bool isProductCodeValid = Regex.IsMatch(productCode, productPattern);
Console.WriteLine($"'{productCode}' matches product pattern: {isProductCodeValid}");
```

**Termos Técnicos:**

*   **Expressão Regular (RegEx):** Uma sequência de caracteres que define um padrão de busca. Usada para encontrar, substituir e validar texto que corresponde a esse padrão.
*   **`System.Text.RegularExpressions` Namespace:** O namespace que contém classes para trabalhar com expressões regulares.

## 8. Substituição com RegEx (`Regex.Replace()`)

Além de verificar, RegEx também pode ser usado para substituir partes de uma string que correspondem a um padrão.

```c#
string logLine = "User: JohnDoe, IP: 192.168.1.100, Status: Success";
// Replace IP addresses with [REDACTED]
string redactedLog = Regex.Replace(logLine, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", "[REDACTED]");
Console.WriteLine($"Redacted Log: {redactedLog}");

string phoneNumber = "(11) 98765-4321";
// Remove all non-digit characters
string cleanedPhoneNumber = Regex.Replace(phoneNumber, @"\D", ""); // \D matches any non-digit character
Console.WriteLine($"Cleaned Phone Number: {cleanedPhoneNumber}");
```

## 9. Extração com RegEx (`Regex.Match()`, `Regex.Matches()`)

Para extrair informações específicas de uma string que seguem um padrão, `Regex.Match()` (para a primeira ocorrência) e `Regex.Matches()` (para todas as ocorrências) são poderosos.

```c#
string textWithPrices = "Item A: $10.50, Item B: $25.00, Item C: $5.99";
string pricePattern = @"\$(\d+\.\d{2})"; // Pattern to capture prices like $XX.YY

// Find all matches
MatchCollection matches = Regex.Matches(textWithPrices, pricePattern);
Console.WriteLine("Extracted Prices:");
foreach (Match match in matches)
{
    // Group 1 contains the captured price without the dollar sign
    Console.WriteLine($"- {match.Groups[1].Value}");
}
```

## 10. Verificando se a String é Nula ou Vazia de Forma Concisa (`string.IsNullOrEmpty()` com operador `??`)

Embora `string.IsNullOrEmpty()` tenha sido abordado, a combinação com o operador de coalescência nula (`??`) é uma prática comum para fornecer um valor padrão quando uma string é nula ou vazia.

```c#
string userName = null;
string defaultName = "Guest";

string displayUserName = userName ?? defaultName; // If userName is null, use defaultName
Console.WriteLine($"Display User Name (null): {displayUserName}");

string email = "";
string defaultEmail = "no_email@example.com";

// This won't work directly with ?? for empty strings, as ?? only checks for null
string displayEmail = email ?? defaultEmail; // Result: "" (email is not null)
Console.WriteLine($"Display Email (empty, with ??): {displayEmail}");

// Correct way to handle null or empty
string finalEmail = string.IsNullOrEmpty(email) ? defaultEmail : email;
Console.WriteLine($"Display Email (empty, with IsNullOrEmpty): {finalEmail}");
```

**Termos Técnicos:**

*   **Operador de Coalescência Nula (`??`):** Um operador que retorna o operando esquerdo se ele não for nulo; caso contrário, retorna o operando direito.

## 11. Criando Strings a Partir de Caracteres Repetidos (`new string(char, int)`)

Um construtor de string útil para criar uma string composta por um caractere repetido um certo número de vezes.

```c#
string separator = new string('-', 20); // Result: "--------------------"
Console.WriteLine(separator);

string padding = new string(' ', 10); // Result: "          "
Console.WriteLine($"Padded text: {padding}Hello");
```

## 12. Comparando Strings para Igualdade de Conteúdo (`string.Equals(object)`)

Embora `string.Equals(string, StringComparison)` seja mais poderoso, a sobrecarga `string.Equals(object)` é a que é chamada quando você usa `myString.Equals(anotherObject)`. É importante entender que ela compara o *conteúdo* da string, não a referência, e é segura para usar com objetos que podem não ser strings.

```c#
string s1 = "Test";
object o1 = "Test";
object o2 = new StringBuilder("Test").ToString();

bool equalsObject1 = s1.Equals(o1); // Result: true
Console.WriteLine($"s1 equals o1: {equalsObject1}");

bool equalsObject2 = s1.Equals(o2); // Result: true
Console.WriteLine($"s1 equals o2: {equalsObject2}");

object o3 = 123; // Not a string
bool equalsObject3 = s1.Equals(o3); // Result: false
Console.WriteLine($"s1 equals o3: {equalsObject3}");
```

## 13. Obtendo um Substring de um Caractere (`string.Substring(int, int)` com `IndexOf`)

Uma aplicação prática de `Substring` e `IndexOf` é extrair texto entre dois delimitadores ou a partir de um delimitador até o final.

```c#
string logMessage = "[INFO] User logged in at 2025-07-26";

// Extract message content (after first ']')
int startIndex = logMessage.IndexOf("]") + 2; // +2 to skip ']' and space
string messageContent = logMessage.Substring(startIndex);
Console.WriteLine($"Log Content: {messageContent}");

string dataRecord = "ID:123;Name:Alice;Status:Active";
// Extract Name
int nameStartIndex = dataRecord.IndexOf("Name:") + "Name:".Length;
int nameEndIndex = dataRecord.IndexOf(";", nameStartIndex);
string name = dataRecord.Substring(nameStartIndex, nameEndIndex - nameStartIndex);
Console.WriteLine($"Extracted Name: {name}");
```

## 14. Verificando se a String é Vazia (`string.IsEmpty` - C# 11+)

Para versões mais recentes do C# (11 e superior), a propriedade `string.IsEmpty` foi introduzida para uma verificação mais clara e performática de strings vazias, sem a necessidade de verificar `null` separadamente.

```c#
string emptyString = "";
string nonEmptyString = "data";

// Requires C# 11 or later
// bool isEmpty1 = emptyString.IsEmpty; // Result: true
// bool isEmpty2 = nonEmptyString.IsEmpty; // Result: false
// Console.WriteLine($"Is empty string empty? {isEmpty1}");
// Console.WriteLine($"Is non-empty string empty? {isEmpty2}");

// For older C# versions, use Length == 0
bool isEmptyLegacy1 = emptyString.Length == 0; // Result: true
bool isEmptyLegacy2 = nonEmptyString.Length == 0; // Result: false
Console.WriteLine($"Is empty string empty (legacy)? {isEmptyLegacy1}");
Console.WriteLine($"Is non-empty string empty (legacy)? {isEmptyLegacy2}");
```

**Termos Técnicos:**

*   **C# 11+:** Indica que a funcionalidade está disponível a partir da versão 11 da linguagem C#.

## 15. Usando `ReadOnlySpan<char>` para Performance (C# 7.2+)

Para operações de string de alta performance que não envolvem alocação de memória (como leitura de substrings sem copiá-las), `ReadOnlySpan<char>` é uma ferramenta avançada. Ele permite trabalhar com uma "visão" de uma parte da memória sem criar uma nova string.

```c#
// This is an advanced topic for performance-critical scenarios.
// Requires .NET Core 2.1+ or .NET Standard 2.1+ and C# 7.2+

string largeLog = "[2025-07-26 10:30:00 INFO] User 'Alice' logged in from IP 192.168.1.10.";

// Get a span over the log message without allocating a new string
ReadOnlySpan<char> logSpan = largeLog.AsSpan();

// Find the start and end of the username
int userStartIndex = logSpan.IndexOf("User '") + "User '".Length;
int userEndIndex = logSpan.IndexOf("' logged");

if (userStartIndex != -1 && userEndIndex != -1)
{
    // Create a new span for the username (no allocation for the span itself)
    ReadOnlySpan<char> usernameSpan = logSpan.Slice(userStartIndex, userEndIndex - userStartIndex);
    Console.WriteLine($"Username (from Span): {usernameSpan.ToString()}"); // .ToString() allocates a string if needed
}

// Example: Parsing a date from a string without allocating substrings
string dateString = "2025-07-26";
ReadOnlySpan<char> dateSpan = dateString.AsSpan();

int year = int.Parse(dateSpan.Slice(0, 4));
int month = int.Parse(dateSpan.Slice(5, 2));
int day = int.Parse(dateSpan.Slice(8, 2));

Console.WriteLine($"Parsed Date (from Span): Year={year}, Month={month}, Day={day}");
```

**Termos Técnicos:**

*   **`ReadOnlySpan<T>`:** Um tipo de referência que pode apontar para uma região contígua de memória. É usado para operações de alta performance que evitam alocações de memória desnecessárias.
*   **Alocação de Memória:** O processo de reservar um espaço na memória do computador para armazenar dados.

## Conclusão

Este conjunto de métodos e conceitos avançados de string no C# equipa você com as ferramentas necessárias para lidar com cenários de manipulação de texto mais complexos e otimizados. Desde a gestão de memória com string pooling até a construção eficiente com `StringBuilder` e a performance de `ReadOnlySpan<char>`, dominar esses recursos é um passo significativo para se tornar um desenvolvedor C# proficiente e capaz de construir aplicações de alta qualidade.