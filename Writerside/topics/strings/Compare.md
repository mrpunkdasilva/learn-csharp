# Comparar Strings

Imagine que você tem duas caixas de brinquedos e quer saber se elas são iguais ou se uma contém um tipo específico de brinquedo. No mundo da programação, comparar strings é muito parecido: você quer verificar se dois textos são idênticos, ou se um texto contém uma parte específica de outro texto. Em C#, temos métodos dedicados para isso.

## `CompareTo()`: Comparação "Dicionário"

O método `CompareTo()` é como organizar palavras em um dicionário. Ele compara a string atual com outra string que você fornece, caractere por caractere, para determinar a ordem lexicográfica (a ordem em que as palavras apareceriam em um dicionário).

**Como funciona:**

*   Ele é um método que você chama a partir de uma string (por exemplo, `minhaString.CompareTo(outraString)`).
*   Ele é **case-sensitive** (sensível a maiúsculas e minúsculas). Isso significa que "Maçã" é diferente de "maçã".
*   Ele retorna um número inteiro:
    *   `0`: Se as strings são exatamente iguais.
    *   Um número **menor que 0**: Se a string atual vem antes da string comparada na ordem do dicionário.
    *   Um número **maior que 0**: Se a string atual vem depois da string comparada na ordem do dicionário.

**Exemplo de Código:**

```csharp
string palavra1 = "Banana";
string palavra2 = "banana";
string palavra3 = "Abacaxi";
string palavra4 = "Banana";

// Comparação case-sensitive
int resultado1 = palavra1.CompareTo(palavra2); // "Banana" vs "banana"
Console.WriteLine($"'Banana'.CompareTo('banana') retorna: {resultado1}");
// Saída: Um número diferente de 0 (porque 'B' é diferente de 'b')

int resultado2 = palavra1.CompareTo(palavra4); // "Banana" vs "Banana"
Console.WriteLine($"'Banana'.CompareTo('Banana') retorna: {resultado2}");
// Saída: 0 (porque são idênticas)

int resultado3 = palavra1.CompareTo(palavra3); // "Banana" vs "Abacaxi"
Console.WriteLine($"'Banana'.CompareTo('Abacaxi') retorna: {resultado3}");
// Saída: Um número maior que 0 (porque 'Banana' vem depois de 'Abacaxi')
```

**Termos Técnicos:**

*   **Lexicográfico:** Refere-se à ordem alfabética ou de dicionário.
*   **Case-sensitive (sensível a maiúsculas e minúsculas):** Significa que a comparação diferencia letras maiúsculas de minúsculas.

## `Contains()`: Verificando a Presença

O método `Contains()` é como verificar se uma caixa de brinquedos contém um brinquedo específico. Ele verifica se uma determinada sequência de caracteres (uma "substring") está presente dentro da string atual.

**Como funciona:**

*   Ele é um método que você chama a partir de uma string (por exemplo, `minhaFrase.Contains(palavraChave)`).
*   Ele também é **case-sensitive**.
*   Ele retorna um valor booleano:
    *   `true`: Se a substring for encontrada.
    *   `false`: Se a substring não for encontrada.

**Exemplo de Código:**

```csharp
string frase = "O rato roeu a roupa do rei de Roma.";
string palavraChave1 = "rato";
string palavraChave2 = "Rei"; // Com 'R' maiúsculo
string palavraChave3 = "gato";

bool contem1 = frase.Contains(palavraChave1);
Console.WriteLine($"A frase contém '{palavraChave1}'? {contem1}");
// Saída: True

bool contem2 = frase.Contains(palavraChave2);
Console.WriteLine($"A frase contém '{palavraChave2}'? {contem2}");
// Saída: False (porque 'Rei' com 'R' maiúsculo não está na frase, apenas 'rei' com 'r' minúsculo)

bool contem3 = frase.Contains(palavraChave3);
Console.WriteLine($"A frase contém '{palavraChave3}'? {contem3}");
// Saída: False
```

**Termos Técnicos:**

*   **Substring:** Uma parte de uma string. Por exemplo, "rato" é uma substring de "O rato roeu...".
*   **Booleano:** Um tipo de dado que pode ter apenas dois valores: `true` (verdadeiro) ou `false` (falso).

## Equals 

> Serve não somente para strings

text.Equals(text2)



## Comparação Ignorando Maiúsculas/Minúsculas (Case-Insensitive)

Muitas vezes, você não quer que a comparação seja sensível a maiúsculas e minúsculas. Para isso, você pode converter ambas as strings para o mesmo caso (tudo maiúsculo ou tudo minúsculo) antes de comparar.

**Exemplo para `CompareTo()` e `Contains()`:**

```csharp
string textoOriginal = "Olá Mundo";
string textoComparar = "olá mundo";

// Para CompareTo()
// Converte ambas para minúsculas antes de comparar
bool saoIguaisIgnorandoCase = (textoOriginal.ToLower().CompareTo(textoComparar.ToLower()) == 0);
Console.WriteLine($"'Olá Mundo' e 'olá mundo' são iguais (ignorando case)? {saoIguaisIgnorandoCase}");
// Saída: True

// Para Contains()
// Converte ambas para minúsculas antes de verificar
bool contemIgnorandoCase = textoOriginal.ToLower().Contains(textoComparar.ToLower());
Console.WriteLine($"'Olá Mundo' contém 'olá mundo' (ignorando case)? {contemIgnorandoCase}");
// Saída: True
```

**Termos Técnicos:**

*   **`ToLower()` (método):** Um método de string que retorna uma nova string com todos os caracteres convertidos para minúsculas.
*   **`ToUpper()` (método):** Um método de string que retorna uma nova string com todos os caracteres convertidos para maiúsculas.

Compreender como e quando usar `CompareTo()` e `Contains()` (e como lidar com a sensibilidade a maiúsculas e minúsculas) é fundamental para manipular textos de forma eficaz em seus programas C#.
