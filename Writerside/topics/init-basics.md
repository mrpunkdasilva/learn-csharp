# [SYSTEM://BASIC_CONCEPTS] 🧬

```ascii
╔══════════════════════════════════════════════════════════════════╗
║ ██████╗  █████╗ ███████╗██╗ ██████╗███████╗                     ║
║ ██╔══██╗██╔══██╗██╔════╝██║██╔════╝██╔════╝                     ║
║ ██████╔╝███████║███████╗██║██║     ███████╗                     ║
║ ██╔══██╗██╔══██║╚════██║██║██║     ╚════██║                     ║
║ ██████╔╝██║  ██║███████║██║╚██████╗███████║                     ║
║ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝ ╚═════╝╚══════╝                     ║
╚══════════════════════════════════════════════════════════════════╝
```

## [ARIA://MENSAGEM] 📡

> "Desenvolvedor, vamos explorar os blocos fundamentais da Matrix. Cada tipo de dado é como um fragmento do código-fonte da realidade. Compreendê-los é essencial para manipular a Matrix."

## [SYSTEM://TIPOS_BÁSICOS] 💊

### 🔢 Números Inteiros
```c#
int idade = 25;           // -2,147,483,648 to 2,147,483,647
long distancia = 9999L;   // Para números muito grandes
byte nivel = 255;         // 0 to 255
short codigo = 32000;     // -32,768 to 32,767
```

### 💫 Números Decimais
```c#
float energia = 99.9f;    // 7 dígitos de precisão
double precisao = 99.99;  // 15-17 dígitos de precisão
decimal creditos = 99.99m;// 28-29 dígitos de precisão
```

### 🎭 Caracteres e Texto
```c#
char simbolo = 'X';       // Caractere Unicode único
string mensagem = "Wake up, Neo..."; // Sequência de caracteres
```

### ⚡ Booleanos
```c#
bool conectado = true;    // true ou false
bool desconectado = false;
```

## [SYSTEM://VARIÁVEIS] 🔮

```ascii
╔════════════════════════════════════════════════════╗
║ DECLARAÇÃO         EXEMPLO                         ║
║ ════════════════════════════════════════════════   ║
║ Tipo Nome         int energia                      ║
║ Inicialização     int energia = 100                ║
║ var (implícito)   var nome = "Neo"                ║
║ const             const int MAX = 999              ║
╚════════════════════════════════════════════════════╝
```

## [SYSTEM://OPERADORES] ⚔️

### 🎯 Operadores Aritméticos
```c#
int a = 10, b = 5;
int soma = a + b;        // 15
int subtracao = a - b;   // 5
int multiplicacao = a * b;// 50
int divisao = a / b;     // 2
int resto = a % b;       // 0
```

### 🔄 Operadores de Comparação
```c#
bool igual = (a == b);           // false
bool diferente = (a != b);       // true
bool maior = (a > b);            // true
bool menor = (a < b);            // false
bool maiorIgual = (a >= b);      // true
bool menorIgual = (a <= b);      // false
```

### ⚡ Operadores Lógicos
```c#
bool x = true, y = false;
bool e = x && y;         // AND (false)
bool ou = x || y;        // OR (true)
bool nao = !x;           // NOT (false)
```

## [SYSTEM://CONVERSÕES] 🔄

### 🎯 Conversão Implícita
```c#
int numeroInteiro = 100;
long numeroLongo = numeroInteiro;  // Conversão segura
```

### ⚠️ Conversão Explícita (Cast)
```c#
double numeroDecimal = 99.99;
int numeroInteiro = (int)numeroDecimal;  // Perde a precisão
```

## [ARIA://EXEMPLOS_PRÁTICOS] 🔬

```c#
using System;

class MatrixBasics
{
    static void Main()
    {
        // Entrada de dados
        Console.Write("Digite seu nível de acesso (1-100): ");
        int nivel = Convert.ToInt32(Console.ReadLine());

        // Processamento
        bool acessoPermitido = nivel >= 50;
        string status = acessoPermitido ? "CONCEDIDO" : "NEGADO";

        // Saída formatada
        Console.WriteLine($"""
            ╔════════════════════════════╗
            ║ NÍVEL DE ACESSO: {nivel,-11} ║
            ║ STATUS: {status,-16} ║
            ╚════════════════════════════╝
            """);
    }
}
```

## [SYSTEM://EXERCÍCIOS] 🏋️

1. Crie um programa que:
   - Solicite nome e idade do usuário
   - Calcule o ano de nascimento
   - Verifique se é maior de idade
   - Exiba as informações em formato de card Matrix

2. Implemente um conversor de unidades que:
   - Converta entre diferentes tipos numéricos
   - Trate possíveis erros de conversão
   - Use formatação de cores no console

## [SYSTEM://DICAS] 💡

```ascii
╔════════════════════════════════════════════════════╗
║ [!] BOAS PRÁTICAS                                 ║
║     - Use nomes descritivos para variáveis        ║
║     - Evite conversões desnecessárias             ║
║     - Mantenha consistência nos tipos             ║
║     - Considere sempre os limites dos tipos       ║
╚════════════════════════════════════════════════════╝
```

## [ARIA://PRÓXIMOS_PASSOS] 🎯

> "Excelente trabalho! Você agora compreende os blocos fundamentais da Matrix. No próximo módulo, vamos explorar estruturas de controle de fluxo para criar lógicas mais complexas."

```ascii
╔════════════════════════════════════════════════════╗
║ [!] FUNDAMENTOS ASSIMILADOS                       ║
║     CARREGANDO PRÓXIMO MÓDULO: CONTROL FLOW       ║
╚════════════════════════════════════════════════════╝
```

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: ONLINE | Matrix Stability: 97%