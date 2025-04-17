# [SYSTEM://SYNTAX_RULES] ⚡

```ascii
╔══════════════════════════════════════════════════════════════════╗
║ ███████╗██╗   ██╗███╗   ██╗████████╗ █████╗ ██╗  ██╗           ║
║ ██╔════╝╚██╗ ██╔╝████╗  ██║╚══██╔══╝██╔══██╗╚██╗██╔╝           ║
║ ███████╗ ╚████╔╝ ██╔██╗ ██║   ██║   ███████║ ╚███╔╝            ║
║ ╚════██║  ╚██╔╝  ██║╚██╗██║   ██║   ██╔══██║ ██╔██╗            ║
║ ███████║   ██║   ██║ ╚████║   ██║   ██║  ██║██╔╝ ██╗           ║
║ ╚══════╝   ╚═╝   ╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝           ║
╚══════════════════════════════════════════════════════════════════╝
```

## [ARIA://MENSAGEM] 📡

> "Desenvolvedor, a sintaxe é o DNA do código. Cada caractere, cada espaço, cada ponto-e-vírgula tem um propósito. Vamos explorar as regras fundamentais que governam a Matrix do C#."

## [SYSTEM://ESTRUTURA_BÁSICA] 🏗️

### 📝 Anatomia de um Programa

```csharp
// 1. Importações (using directives)
using System;
using System.Collections.Generic;
using System.Linq;

// 2. Namespace (organização lógica do código)
namespace MatrixSyntax
{
    // 3. Classe (blueprint para objetos)
    public class Program
    {
        // 4. Método Principal (ponto de entrada)
        static void Main(string[] args)
        {
            // 5. Instruções (comandos executáveis)
            Console.WriteLine("Hello, Matrix!");
        }
    }
}
```

## [SYSTEM://TIPOS_DADOS] 💾

### 🔢 Tipos Numéricos

```csharp
// Inteiros
byte smallNumber = 255;        // 0 a 255
short mediumNumber = 32767;    // -32,768 a 32,767
int standardNumber = 2147483647; // -2.1B a 2.1B
long bigNumber = 9223372036854775807L; // -9.2Q a 9.2Q

// Ponto Flutuante
float precisionNumber = 3.14f;  // 7 dígitos de precisão
double highPrecision = 3.14159265359; // 15-17 dígitos
decimal moneyValue = 1234.56m;  // 28-29 dígitos
```

### 📝 Tipos de Texto

```csharp
// Caracteres
char singleLetter = 'A';       // Um único caractere Unicode
string text = "Matrix";        // Sequência de caracteres
string multiLine = @"
    Este é um texto
    com múltiplas linhas
    usando @ (verbatim string)
";
string interpolated = $"O valor é {standardNumber}"; // String interpolation
```

### ⚡ Tipos Lógicos

```csharp
bool isConnected = true;
bool hasAccess = false;
```

## [SYSTEM://OPERADORES] 🔧

### 📊 Operadores Aritméticos

```csharp
int a = 10, b = 3;

int soma = a + b;        // 13
int subtracao = a - b;   // 7
int multiplicacao = a * b; // 30
int divisao = a / b;     // 3
int modulo = a % b;      // 1

// Incremento/Decremento
int i = 0;
i++;    // Pós-incremento
++i;    // Pré-incremento
i--;    // Pós-decremento
--i;    // Pré-decremento
```

### 🔍 Operadores de Comparação

```csharp
bool igual = (a == b);           // false
bool diferente = (a != b);       // true
bool maior = (a > b);            // true
bool menor = (a < b);            // false
bool maiorOuIgual = (a >= b);    // true
bool menorOuIgual = (a <= b);    // false
```

### 🔄 Operadores Lógicos

```csharp
bool x = true, y = false;

bool and = x && y;    // false (E lógico)
bool or = x || y;     // true (OU lógico)
bool not = !x;        // false (NÃO lógico)
```

## [SYSTEM://ESTRUTURAS_CONTROLE] 🎮

### 🔀 Condicionais

```csharp
// If-Else tradicional
if (isConnected)
{
    Console.WriteLine("Conectado à Matrix");
}
else if (hasAccess)
{
    Console.WriteLine("Tentando conectar...");
}
else
{
    Console.WriteLine("Acesso negado");
}

// Operador Ternário
string status = isConnected ? "Online" : "Offline";

// Switch Expression (C# 8.0+)
string message = status switch
{
    "Online" => "Conexão estabelecida",
    "Offline" => "Conexão perdida",
    _ => "Status desconhecido"
};
```

### 🔁 Loops

```csharp
// For tradicional
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Iteração {i}");
}

// Foreach (para coleções)
string[] codes = { "Alpha", "Beta", "Gamma" };
foreach (string code in codes)
{
    Console.WriteLine(code);
}

// While (pré-condição)
int count = 0;
while (count < 5)
{
    Console.WriteLine($"Contagem: {count}");
    count++;
}

// Do-While (pós-condição)
do
{
    Console.WriteLine("Executado pelo menos uma vez");
} while (false);
```

## [SYSTEM://MÉTODOS] 🛠️

### 📋 Declaração e Uso

```csharp
public class MatrixOperations
{
    // Método simples
    public void ShowMessage()
    {
        Console.WriteLine("Mensagem da Matrix");
    }

    // Método com parâmetros
    public int Add(int x, int y)
    {
        return x + y;
    }

    // Método com parâmetros opcionais
    public string FormatCode(string code, string prefix = "MTX")
    {
        return $"{prefix}-{code}";
    }

    // Método com parâmetros de saída
    public void DivideNumbers(int x, int y, out int result, out int remainder)
    {
        result = x / y;
        remainder = x % y;
    }

    // Método com params
    public double Calculate(params double[] numbers)
    {
        return numbers.Sum();
    }
}
```

## [SYSTEM://BOAS_PRÁTICAS] 💡

### 📌 Convenções de Código

```ascii
╔════════════════════════════════════════════════════╗
║ ELEMENTO          CONVENÇÃO         EXEMPLO        ║
║ ═══════════════════════════════════════════════    ║
║ Interfaces        Prefixo I        IMatrix        ║
║ Classes           PascalCase       MatrixHandler  ║
║ Métodos           PascalCase       ProcessData    ║
║ Variáveis        camelCase        matrixCode     ║
║ Constantes       MAIÚSCULAS       MAX_VALUE      ║
║ Parâmetros       camelCase        inputData      ║
╚════════════════════════════════════════════════════╝
```

### 🎯 Práticas Recomendadas

```csharp
// ✅ BOM: Nomes descritivos
public class UserAuthentication
{
    private readonly string _username;
    
    public bool ValidateCredentials(string password)
    {
        // Implementação
    }
}

// ❌ RUIM: Nomes pouco descritivos
public class UA
{
    private readonly string u;
    
    public bool vc(string p)
    {
        // Implementação
    }
}
```

## [SYSTEM://EXERCÍCIOS_AVANÇADOS] 🏋️

### 🎯 Desafio 1: Refatoração

```csharp
// Refatore este código aplicando as convenções corretas
class data_processor
{
    private int MAX;
    public string CurrentStatus;
    
    public void Process_data(string Data)
    {
        // Implementação
    }
}
```

### 🎯 Desafio 2: Estruturas de Controle

```csharp
// Implemente diferentes maneiras de resolver este problema
public class MatrixChallenge
{
    public string ClassifyNumber(int number)
    {
        // Retorne "Positivo", "Negativo" ou "Zero"
        // Use: if-else, switch e operador ternário
    }
}
```

### 🎯 Desafio 3: Métodos

```csharp
// Crie uma classe com diferentes tipos de métodos
public class MatrixCalculator
{
    // TODO: Implemente métodos com:
    // 1. Parâmetros opcionais
    // 2. Parâmetros de saída (out)
    // 3. Sobrecarga de métodos
    // 4. Params
}
```

## [ARIA://PRÓXIMOS_PASSOS] 🎯

```ascii
╔════════════════════════════════════════════════════╗
║ [!] MÓDULOS RECOMENDADOS                          ║
║     → Tipos Avançados                             ║
║     → Programação Orientada a Objetos             ║
║     → Manipulação de Exceções                     ║
║     → LINQ e Coleções                             ║
╚════════════════════════════════════════════════════╝
```

## [SYSTEM://RECURSOS_ADICIONAIS] 📚

```ascii
╔════════════════════════════════════════════════════╗
║ [!] LINKS ÚTEIS                                   ║
║     → Documentação Oficial C#                     ║
║     → Guia de Estilo Microsoft                    ║
║     → Exercícios Práticos                         ║
║     → Fórum da Comunidade                         ║
╚════════════════════════════════════════════════════╝
```

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: ONLINE | Matrix Stability: 99%