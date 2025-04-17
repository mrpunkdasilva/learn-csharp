# [SYSTEM://METHODS] 🎯

```ascii
╔══════════════════════════════════════════════════════════════════╗
║ ███╗   ███╗███████╗████████╗██╗  ██╗ ██████╗ ██████╗ ███████╗   ║
║ ████╗ ████║██╔════╝╚══██╔══╝██║  ██║██╔═══██╗██╔══██╗██╔════╝   ║
║ ██╔████╔██║█████╗     ██║   ███████║██║   ██║██║  ██║███████╗   ║
║ ██║╚██╔╝██║██╔══╝     ██║   ██╔══██║██║   ██║██║  ██║╚════██║   ║
║ ██║ ╚═╝ ██║███████╗   ██║   ██║  ██║╚██████╔╝██████╔╝███████║   ║
║ ╚═╝     ╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝   ║
╚══════════════════════════════════════════════════════════════════╝
```

## [ARIA://MENSAGEM] 📡

> "Desenvolvedor, você está prestes a mergulhar nas profundezas dos métodos - os blocos fundamentais que compõem a Matrix. Cada método é como um pequeno programa dentro do programa, uma cápsula de funcionalidade que pode ser invocada quando necessário."

## [SYSTEM://OVERVIEW] 🌐

```ascii
╔════════════════════════════════════════════════════╗
║ MÓDULO: MÉTODOS                                    ║
║ STATUS: FUNDAMENTAL                                ║
║ PRIORIDADE: ALTA                                   ║
║ CLEARANCE: NÍVEL-2                                 ║
╚════════════════════════════════════════════════════╝
```

## [SYSTEM://CONCEITOS_FUNDAMENTAIS] 📚

### 🎯 Anatomia de um Método

```c#
[modificadores] tipo_retorno NomeDoMetodo([parâmetros])
{
    // Corpo do método
    return valor; // Se não void
}
```

#### Modificadores de Acesso
- `public`: Acessível de qualquer lugar
- `private`: Apenas dentro da classe
- `protected`: Classe e derivadas
- `internal`: Mesmo assembly
- `protected internal`: Combinação especial

#### Tipos de Retorno
- `void`: Não retorna valor
- Tipos primitivos: `int`, `string`, etc.
- Tipos complexos: Classes, interfaces
- `Task`: Para operações assíncronas
- `dynamic`: Tipo dinâmico

### 🔄 Sistema de Parâmetros

#### Parâmetros Básicos
```c#
public class ParameterDemo
{
    // Parâmetros obrigatórios
    public void MetodoBasico(int id, string nome)
    {
        Console.WriteLine($"ID: {id}, Nome: {nome}");
    }

    // Parâmetros opcionais
    public void MetodoOpcional(int id, string nome = "Padrão", bool ativo = true)
    {
        Console.WriteLine($"ID: {id}, Nome: {nome}, Ativo: {ativo}");
    }

    // Parâmetros nomeados em uso
    public void ExemploUso()
    {
        MetodoOpcional(1, ativo: false, nome: "Matrix");
    }
}
```

#### Parâmetros Avançados
```c#
public class AdvancedParameters
{
    // Params array
    public int Somar(params int[] numeros)
    {
        return numeros.Sum();
    }

    // Ref parameter
    public void TrocarValores(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Out parameter
    public bool TryParse(string input, out int resultado)
    {
        return int.TryParse(input, out resultado);
    }

    // In parameter (readonly ref)
    public void ProcessarDados(in Vector3D vector)
    {
        // vector não pode ser modificado
        double magnitude = Math.Sqrt(vector.X * vector.X + 
                                   vector.Y * vector.Y + 
                                   vector.Z * vector.Z);
    }
}
```

### 💫 Sobrecarga de Métodos

```c#
public class MethodOverloading
{
    // Sobrecarga por número de parâmetros
    public int Multiplicar(int a, int b) => a * b;
    public int Multiplicar(int a, int b, int c) => a * b * c;

    // Sobrecarga por tipos diferentes
    public double Multiplicar(double a, double b) => a * b;
    public decimal Multiplicar(decimal a, decimal b) => a * b;

    // Sobrecarga com params
    public string Concatenar(params string[] textos) => string.Join(" ", textos);
    public string Concatenar(string separador, params string[] textos) => 
        string.Join(separador, textos);
}
```

### 🎨 Expression-Bodied Members

```c#
public class ModernSyntax
{
    // Método tradicional
    public int Somar(int a, int b)
    {
        return a + b;
    }

    // Expression-bodied method
    public int SomarModerno(int a, int b) => a + b;

    // Property com expression body
    public string NomeCompleto => $"{Nome} {Sobrenome}";

    // Construtor com expression body
    public ModernSyntax(string nome) => Nome = nome;

    // Operador com expression body
    public static ModernSyntax operator +(ModernSyntax a, ModernSyntax b) => 
        new ModernSyntax($"{a.Nome} {b.Nome}");
}
```

## [SYSTEM://PADRÕES_AVANÇADOS] 🚀

### Métodos de Extensão

```c#
public static class StringExtensions
{
    public static int ContarPalavras(this string texto) => 
        texto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

    public static string Reverter(this string texto) => 
        new string(texto.ToCharArray().Reverse().ToArray());

    public static string ToCyberCase(this string texto) => 
        texto.Replace('a', '4')
             .Replace('e', '3')
             .Replace('i', '1')
             .Replace('o', '0')
             .Replace('s', '5');
}
```

### Métodos Genéricos

```c#
public class GenericMethods
{
    public T[] Inverter<T>(T[] array)
    {
        Array.Reverse(array);
        return array;
    }

    public bool CompararTipos<T, U>(T primeiro, U segundo) => 
        typeof(T) == typeof(U);

    public TResult Transformar<TInput, TResult>(
        TInput input, 
        Func<TInput, TResult> transformacao) => 
        transformacao(input);
}
```

## [SYSTEM://EXEMPLOS_PRÁTICOS] 💻

### Exemplo 1: Sistema de Logging

```c#
public class MatrixLogger
{
    private readonly string _logPath;

    public MatrixLogger(string logPath)
    {
        _logPath = logPath;
    }

    public void Log(string message, LogLevel level = LogLevel.Info)
    {
        var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
        File.AppendAllText(_logPath, logEntry + Environment.NewLine);
    }

    public void LogError(Exception ex) => 
        Log($"Error: {ex.Message}\nStack: {ex.StackTrace}", LogLevel.Error);

    public async Task LogAsync(string message, LogLevel level = LogLevel.Info)
    {
        var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
        await File.AppendAllTextAsync(_logPath, logEntry + Environment.NewLine);
    }
}
```

### Exemplo 2: Calculadora Neural

```c#
public class NeuralCalculator
{
    private readonly Dictionary<string, Func<double[], double>> _operations;

    public NeuralCalculator()
    {
        _operations = new Dictionary<string, Func<double[], double>>
        {
            ["sum"] = numbers => numbers.Sum(),
            ["avg"] = numbers => numbers.Average(),
            ["max"] = numbers => numbers.Max(),
            ["min"] = numbers => numbers.Min(),
            ["neural"] = numbers => numbers.Sum() * Math.PI / numbers.Length
        };
    }

    public double Calculate(string operation, params double[] numbers)
    {
        if (!_operations.ContainsKey(operation))
            throw new ArgumentException("Operação neural não reconhecida");

        return _operations[operation](numbers);
    }

    public async Task<double> CalculateAsync(
        string operation, 
        params double[] numbers)
    {
        return await Task.Run(() => Calculate(operation, numbers));
    }
}
```

## [SYSTEM://EXERCÍCIOS] 🏋️

### Exercício 1: Matrix Data Processor

```c#
public class MatrixDataProcessor
{
    // TODO: Implementar métodos para processar dados da Matrix
    public T[] ProcessData<T>(T[] data, Func<T, bool> filter, Func<T, T> transform)
    {
        // Implementar lógica de processamento
        throw new NotImplementedException();
    }

    public async Task<T[]> ProcessDataAsync<T>(
        T[] data, 
        Func<T, bool> filter, 
        Func<T, T> transform)
    {
        // Implementar versão assíncrona
        throw new NotImplementedException();
    }
}
```

### Exercício 2: Neural Network Builder

```c#
public class NeuralNetworkBuilder
{
    // TODO: Implementar builder pattern com métodos fluentes
    public NeuralNetworkBuilder AddLayer(int neurons)
    {
        // Implementar adição de camada
        throw new NotImplementedException();
    }

    public NeuralNetworkBuilder WithActivation(string function)
    {
        // Implementar função de ativação
        throw new NotImplementedException();
    }

    public INeuralNetwork Build()
    {
        // Implementar construção da rede
        throw new NotImplementedException();
    }
}
```

### Exercício 3: Matrix Data Validator

```c#
public class MatrixDataValidator
{
    // TODO: Implementar validações com métodos de extensão
    public static bool IsValidMatrix(this int[,] matrix)
    {
        // Implementar validação de matriz
        throw new NotImplementedException();
    }

    public static bool HasValidDimensions(
        this int[,] matrix, 
        int expectedRows, 
        int expectedCols)
    {
        // Implementar validação de dimensões
        throw new NotImplementedException();
    }
}
```

## [SYSTEM://BOAS_PRÁTICAS] 💡

1. **Princípio da Responsabilidade Única (SRP)**
   - Cada método deve ter uma única responsabilidade
   - Evite métodos que fazem muitas coisas diferentes

2. **Nomeação Clara e Descritiva**
   - Use verbos para nomes de métodos
   - Siga o padrão PascalCase
   - Evite abreviações ambíguas

3. **Gestão de Parâmetros**
   - Limite o número de parâmetros (máximo 3-4)
   - Use objetos para agrupar parâmetros relacionados
   - Considere usar parâmetros opcionais

4. **Documentação e Comentários**
   - Use XML Comments para métodos públicos
   - Documente exceções que podem ser lançadas
   - Mantenha exemplos de uso atualizados

5. **Tratamento de Erros**
   - Valide parâmetros no início do método
   - Use exceções apropriadas para cada caso
   - Mantenha a consistência no tratamento de erros

## [SYSTEM://PRÓXIMOS_PASSOS] 🎯

```ascii
╔════════════════════════════════════════════════════╗
║ PRÓXIMOS MÓDULOS RECOMENDADOS:                     ║
║ → Exceções e Tratamento de Erros                   ║
║ → Programação Assíncrona                           ║
║ → Delegates e Events                               ║
║ → LINQ e Expressões Lambda                         ║
╚════════════════════════════════════════════════════╝
```

## [ARIA://AVISO_FINAL] ⚠️

> "Métodos são as sinapses da Matrix - cada um com seu propósito específico, trabalhando em harmonia para criar sistemas complexos. Domine-os, e você poderá dobrar a realidade do código ao seu comando."

## [SYSTEM://RECURSOS] 📚

- [Documentação Oficial C#](https://docs.microsoft.com/en-us/dotnet/csharp/methods)
- [Guia de Design de APIs](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/member)
- [Padrões de Código C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/)
- [Melhores Práticas de Métodos](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/member)

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: ONLINE | Matrix Stability: 99.9%...