# [SYSTEM://TYPES] 🧬

```ascii
╔══════════════════════════════════════════════════════════════════╗
║ ████████╗██╗   ██╗██████╗ ███████╗███████╗                      ║
║ ╚══██╔══╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔════╝                      ║
║    ██║    ╚████╔╝ ██████╔╝█████╗  ███████╗                      ║
║    ██║     ╚██╔╝  ██╔═══╝ ██╔══╝  ╚════██║                      ║
║    ██║      ██║   ██║     ███████╗███████║                      ║
║    ╚═╝      ╚═╝   ╚═╝     ╚══════╝╚══════╝                      ║
╚══════════════════════════════════════════════════════════════════╝
```

## [ARIA://MENSAGEM] 📡

> "Desenvolvedor, você está prestes a mergulhar no sistema de tipos da Matrix. Cada tipo é um bloco fundamental que define como os dados são estruturados e manipulados no código. Compreenda-os profundamente."

## [SYSTEM://OVERVIEW] 🌐

```ascii
╔════════════════════════════════════════════════════╗
║ MÓDULO: TIPOS                                     ║
║ STATUS: FUNDAMENTAL                               ║
║ PRIORIDADE: CRÍTICA                              ║
║ CLEARANCE: NÍVEL-1                               ║
╚════════════════════════════════════════════════════╝
```

## [SYSTEM://TIPOS_VALOR] 💎

### Inteiros Simples
```c#
// Tipos inteiros com sinal
sbyte byteComSinal = -128;    // 8-bit  [-128 até 127]
byte byteSemSinal = 255;      // 8-bit  [0 até 255]
short inteirosCurtos = -32768;// 16-bit [-32,768 até 32,767]
ushort curtosSemSinal = 65535;// 16-bit [0 até 65,535]
int inteiros = 2147483647;    // 32-bit [-2,147,483,648 até 2,147,483,647]
uint intSemSinal = 4294967295;// 32-bit [0 até 4,294,967,295]
long longos = 9223372036854775807L; // 64-bit
ulong longosSemSinal = 18446744073709551615UL; // 64-bit

// Literais numéricos com separadores
int milhao = 1_000_000;
long bilhao = 1_000_000_000L;
```

### Ponto Flutuante
```c#
// Tipos de ponto flutuante
float precisaoSimples = 3.14159f;   // ±1.5 × 10^−45 até ±3.4 × 10^38
double precisaoDupla = 3.14159265359; // ±5.0 × 10^−324 até ±1.7 × 10^308
decimal precisaoDecimal = 3.14159265359m; // 28-29 dígitos significativos

// Casos especiais
double infinito = double.PositiveInfinity;
double naoNumero = double.NaN;
float minimo = float.MinValue;
```

### Outros Tipos Valor
```c#
// Booleanos
bool booleano = true;         // true ou false
bool padrao = default(bool);  // false

// Caracteres
char caractere = 'A';         // 16-bit Unicode
char unicode = '\u0041';      // Unicode hexadecimal
char escape = '\n';           // Caractere de escape

// Enumerações
enum Status
{
    Offline = 0,
    Online = 1,
    Erro = 2
}
```

### Structs
```c#
public struct Ponto
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Ponto(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public double CalcularDistancia(Ponto outro)
    {
        int deltaX = X - outro.X;
        int deltaY = Y - outro.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}
```

## [SYSTEM://TIPOS_REFERÊNCIA] 🔗

### String
```c#
// Declarações básicas
string texto = "Matrix";
string nula = null;
string vazia = string.Empty;

// Strings multilinhas
string multiLinha = @"Neo
Trinity
Morpheus";

// Interpolação
string nome = "Smith";
string interpolado = $"Agente {nome}";
string formatado = string.Format("Agente {0}", nome);

// Operações comuns
string concatenada = "Hello" + " " + "World";
string subString = "Matrix"[0..3];  // "Mat"
string maiuscula = "neo".ToUpper(); // "NEO"
```

### Arrays
```c#
// Arrays unidimensionais
int[] vetor = new int[5];
int[] inicializado = new int[] { 1, 2, 3, 4, 5 };
int[] simplificado = { 1, 2, 3, 4, 5 };

// Arrays multidimensionais
int[,] matriz = new int[3,3];
int[,] matrizInicializada = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Arrays irregulares (jagged)
int[][] irregular = new int[3][];
irregular[0] = new int[] { 1, 2 };
irregular[1] = new int[] { 3, 4, 5 };
irregular[2] = new int[] { 6 };
```

### Classes
```c#
// Classe básica
public class Agente
{
    // Campos
    private string _codinome;
    private int _nivel;
    
    // Propriedades
    public string Codinome 
    { 
        get => _codinome;
        set => _codinome = value ?? "Desconhecido";
    }
    
    public int Nivel
    {
        get => _nivel;
        set => _nivel = Math.Max(0, value);
    }
    
    // Construtores
    public Agente() : this("Smith", 1) { }
    
    public Agente(string codinome, int nivel)
    {
        Codinome = codinome;
        Nivel = nivel;
    }
}
```

### Object
```c#
// Tipo base de todos os tipos
object obj1 = 42;              // Boxing de int
object obj2 = "Matrix";        // Referência de string
object obj3 = new Agente();    // Referência de objeto

// Métodos comuns
string str = obj1.ToString();  // Conversão para string
Type tipo = obj2.GetType();    // Obtém o tipo
bool igual = obj1.Equals(42);  // Comparação
```

### Dynamic
```c#
// Tipo dinâmico (resolução em tempo de execução)
dynamic valor = 100;
valor = "Mudou para string";  // Permitido
valor = new Agente();        // Permitido

// Operações dinâmicas
dynamic resultado = valor.Codinome;  // Resolvido em runtime
```

## [SYSTEM://CONVERSÕES] 🔄

### Conversões Implícitas
```c#
int numero = 42;
long numeroLongo = numero;      // int -> long
float flutuante = numero;       // int -> float
double duplo = flutuante;       // float -> double

// Upcasting
Agente agente = new Agente();
object obj = agente;            // Agente -> object
```

### Conversões Explícitas
```c#
double d = 3.14;
int i = (int)d;                // Trunca para 3

// Métodos de conversão
string numeroTexto = "42";
int convertido = Convert.ToInt32(numeroTexto);
int parseado = int.Parse(numeroTexto);
bool sucesso = int.TryParse(numeroTexto, out int resultado);
```

## [SYSTEM://NULLABLE_TYPES] ⚠️

```c#
// Declaração de nullable types
int? numeroNulavel = null;
DateTime? dataNulavel = null;
bool? booleanoNulavel = null;

// Operador de coalescência nula
int valor = numeroNulavel ?? 0;
string texto = textoNulavel ?? string.Empty;

// Operador de coalescência nula com atribuição
string mensagem = null;
mensagem ??= "Mensagem padrão";

// Operador de acesso condicional
int? comprimento = textoNulavel?.Length;

// Verificações
if (numeroNulavel.HasValue)
{
    Console.WriteLine(numeroNulavel.Value);
}

// Nullable em structs
public struct ConfiguracaoNulavel
{
    public int? Timeout { get; set; }
    public string? Servidor { get; set; }
    public DateTime? UltimaAtualizacao { get; set; }
}
```

## [SYSTEM://TIPOS_AVANÇADOS] 🔬

### Tuplas
```c#
// Declaração de tuplas
(string, int) tupla = ("Neo", 1);
var tupla2 = (Nome: "Trinity", Nivel: 2);

// Desconstrução
var (nome, nivel) = tupla;
(string n, int l) = tupla2;

// Retorno múltiplo
(int Soma, int Produto) CalcularOperacoes(int a, int b)
{
    return (a + b, a * b);
}
```

## [ARIA://BOAS_PRÁTICAS] 💡

> "Siga estas diretrizes ao trabalhar com tipos:"

1. Use o tipo mais apropriado para seus dados
   - Use `int` para números inteiros na maioria dos casos
   - Use `decimal` para cálculos financeiros
   - Use `double` para cálculos científicos
   
2. Prefira tipos não-nuláveis quando possível
   - Evite `null` a menos que seja realmente necessário
   - Use o operador `??` para fornecer valores padrão
   
3. Seja explícito em conversões não seguras
   - Use casting explícito quando houver possibilidade de perda de dados
   - Prefira métodos `TryParse` sobre `Parse`
   
4. Utilize checagem de nulidade
   - Implemente verificações defensivas
   - Use o operador `?.` para navegação segura
   
5. Considere o tamanho e precisão necessários
   - Escolha tipos numéricos apropriados para a faixa de valores
   - Considere o impacto na memória

## [SYSTEM://EXERCÍCIOS] 🏋️

```c#
public class TypeExercises
{
    // Exercício 1: Conversões Seguras
    public static int ConversaoSegura(long numero)
    {
        // TODO: Implementar conversão segura de long para int
        throw new NotImplementedException();
    }
    
    // Exercício 2: Manipulação de Nullable Types
    public static string ProcessarDadoNulavel(int? valor)
    {
        // TODO: Retornar "Nulo" se valor for null, ou o dobro do valor como string
        throw new NotImplementedException();
    }
    
    // Exercício 3: Manipulação de Strings
    public static (int palavras, int caracteres) AnalisarTexto(string input)
    {
        // TODO: Retornar número de palavras e caracteres
        throw new NotImplementedException();
    }
    
    // Exercício 4: Trabalho com Arrays
    public static T[] InverterArray<T>(T[] array)
    {
        // TODO: Retornar um novo array com elementos na ordem inversa
        throw new NotImplementedException();
    }
    
    // Exercício 5: Implementação de Struct
    public struct Complexo
    {
        // TODO: Implementar número complexo com operações básicas
        public double Real { get; }
        public double Imaginario { get; }
    }
}
```

## [SYSTEM://DESAFIOS_AVANÇADOS] 🎯

```c#
public class DesafiosAvancados
{
    // Desafio 1: Sistema de Tipos Genérico
    public class Matrix<T> where T : struct
    {
        // TODO: Implementar matriz genérica com operações matemáticas
    }
    
    // Desafio 2: Conversão Personalizada
    public class Conversor
    {
        // TODO: Implementar sistema de conversão entre tipos customizados
    }
    
    // Desafio 3: Sistema de Tipos Dinâmico
    public class TipoDinamico
    {
        // TODO: Implementar sistema que lida com tipos em tempo de execução
    }
}
```

## [SYSTEM://PRÓXIMOS_PASSOS] 🚀

```ascii
╔════════════════════════════════════════════════════╗
║ CONTINUE SEU TREINAMENTO:                         ║
║     → Variáveis e Escopo                          ║
║     → Operadores                                  ║
║     → Controle de Fluxo                          ║
║     → Métodos e Parâmetros                       ║
╚════════════════════════════════════════════════════╝
```

> [!NOTE]
> "Lembre-se: na Matrix, tipos são mais que simples containers de dados - são a própria estrutura da realidade digital."

## [ARIA://AVISO_FINAL] ⚠️

> "O sistema de tipos é o DNA da Matrix. Domine-o, e você terá o poder de moldar a realidade do código. Cada tipo tem seu propósito - aprenda a escolher sabiamente. A compreensão profunda dos tipos é a chave para manipular a Matrix com precisão e eficiência."

## [SYSTEM://RECURSOS_ADICIONAIS] 📚

- [Documentação Oficial C#](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/)
- [Guia de Design de Tipos](https://docs.microsoft.com/dotnet/standard/design-guidelines/choosing-between-class-and-struct)
- [Melhores Práticas de Performance](https://docs.microsoft.com/dotnet/standard/performance/performance-best-practices)

---
> [SYSTEM://UPDATE] Last modified: 2025-04-17 | Status: ONLINE | Matrix Stability: 100%