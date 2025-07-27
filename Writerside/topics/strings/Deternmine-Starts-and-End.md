# Início e Fim de Strings

Imagine que você tem uma lista de nomes de arquivos e quer encontrar todos os arquivos que começam com "relatorio" ou que terminam com ".pdf". Em programação, para fazer esse tipo de verificação em textos (strings), usamos métodos específicos que nos dizem se uma string começa ou termina com uma determinada sequência de caracteres.

## `StartsWith()`: Verificando o Início

O método `StartsWith()` é como perguntar: "Esta frase começa com esta palavra?". Ele verifica se a string atual começa com a substring especificada.

**Como funciona:**

*   Você chama `StartsWith()` a partir de uma string, passando a substring que você quer verificar como argumento.
*   Ele é **case-sensitive** (sensível a maiúsculas e minúsculas). Isso significa que "Relatorio" é diferente de "relatorio".
*   Ele retorna um valor booleano:
    *   `true`: Se a string começa com a substring.
    *   `false`: Se a string não começa com a substring.

**Exemplo de Código:**

```csharp
string nomeArquivo = "relatorio_vendas_2024.xlsx";

bool comecaComRelatorio = nomeArquivo.StartsWith("relatorio");
Console.WriteLine($"'{nomeArquivo}' começa com 'relatorio'? {comecaComRelatorio}");
// Saída: True

bool comecaComRelatorioMaiusculo = nomeArquivo.StartsWith("Relatorio");
Console.WriteLine($"'{nomeArquivo}' começa com 'Relatorio'? {comecaComRelatorioMaiusculo}");
// Saída: False (por causa do 'R' maiúsculo)

string url = "https://www.exemplo.com";
bool comecaComHttps = url.StartsWith("https://");
Console.WriteLine($"'{url}' começa com 'https://'? {comecaComHttps}");
// Saída: True
```

**Termos Técnicos:**

*   **Substring:** Uma parte de uma string. Por exemplo, "relatorio" é uma substring de "relatorio_vendas_2024.xlsx".
*   **Booleano:** Um tipo de dado que pode ter apenas dois valores: `true` (verdadeiro) ou `false` (falso).
*   **Case-sensitive (sensível a maiúsculas e minúsculas):** Significa que a comparação diferencia letras maiúsculas de minúsculas.

## `EndsWith()`: Verificando o Fim

O método `EndsWith()` é o oposto de `StartsWith()`. Ele é como perguntar: "Esta frase termina com esta palavra?". Ele verifica se a string atual termina com a substring especificada.

**Como funciona:**

*   Você chama `EndsWith()` a partir de uma string, passando a substring que você quer verificar como argumento.
*   Ele também é **case-sensitive**.
*   Ele retorna um valor booleano:
    *   `true`: Se a string termina com a substring.
    *   `false`: Se a string não termina com a substring.

**Exemplo de Código:**

```csharp
string nomeArquivo = "documento_final.pdf";

bool terminaComPdf = nomeArquivo.EndsWith(".pdf");
Console.WriteLine($"'{nomeArquivo}' termina com '.pdf'? {terminaComPdf}");
// Saída: True

bool terminaComDoc = nomeArquivo.EndsWith(".doc");
Console.WriteLine($"'{nomeArquivo}' termina com '.doc'? {terminaComDoc}");
// Saída: False

string email = "usuario@dominio.com.br";
bool terminaComBr = email.EndsWith(".br");
Console.WriteLine($"'{email}' termina com '.br'? {terminaComBr}");
// Saída: True
```

## Comparação Ignorando Maiúsculas/Minúsculas (Case-Insensitive)

Assim como em outras comparações de strings, muitas vezes você pode querer verificar o início ou o fim de uma string sem se preocupar com a diferença entre letras maiúsculas e minúsculas. Para isso, você pode converter tanto a string original quanto a substring para o mesmo caso (tudo minúsculo ou tudo maiúsculo) antes de usar `StartsWith()` ou `EndsWith()`.

**Exemplo:**

```csharp
string titulo = "A Grande Aventura";
string prefixo = "a grande"; // Minúsculo

// Verificação case-sensitive (retorna False)
bool comecaCaseSensitive = titulo.StartsWith(prefixo);
Console.WriteLine($"'{titulo}' começa com '{prefixo}' (case-sensitive)? {comecaCaseSensitive}");
// Saída: False

// Verificação case-insensitive (retorna True)
bool comecaCaseInsensitive = titulo.ToLower().StartsWith(prefixo.ToLower());
Console.WriteLine($"'{titulo}' começa com '{prefixo}' (case-insensitive)? {comecaCaseInsensitive}");
// Saída: True

string caminho = "/home/usuario/documentos/relatorio.PDF";
string extensao = ".pdf"; // Minúsculo

// Verificação case-sensitive (retorna False)
bool terminaCaseSensitive = caminho.EndsWith(extensao);
Console.WriteLine($"'{caminho}' termina com '{extensao}' (case-sensitive)? {terminaCaseSensitive}");
// Saída: False

// Verificação case-insensitive (retorna True)
bool terminaCaseInsensitive = caminho.ToLower().EndsWith(extensao.ToLower());
Console.WriteLine($"'{caminho}' termina com '{extensao}' (case-insensitive)? {terminaCaseInsensitive}");
// Saída: True
```

**Termos Técnicos:**

*   **`ToLower()` (método):** Um método de string que retorna uma nova string com todos os caracteres convertidos para minúsculas.
*   **`ToUpper()` (método):** Um método de string que retorna uma nova string com todos os caracteres convertidos para maiúsculas.

Dominar `StartsWith()` e `EndsWith()` é essencial para tarefas comuns de manipulação de strings, como validação de entrada de usuário, análise de nomes de arquivos e URLs, e filtragem de dados.