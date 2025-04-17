# [SYSTEM://CONTROL_FLOW] 🔄

```ascii
╔══════════════════════════════════════════════════════════════════╗
║  ██████╗ ██████╗ ███╗   ██╗████████╗██████╗  ██████╗ ██╗       ║
║ ██╔════╝██╔═══██╗████╗  ██║╚══██╔══╝██╔══██╗██╔═══██╗██║       ║
║ ██║     ██║   ██║██╔██╗ ██║   ██║   ██████╔╝██║   ██║██║       ║
║ ██║     ██║   ██║██║╚██╗██║   ██║   ██╔══██╗██║   ██║██║       ║
║ ╚██████╗╚██████╔╝██║ ╚████║   ██║   ██║  ██║╚██████╔╝███████╗   ║
║  ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚══════╝   ║
╚══════════════════════════════════════════════════════════════════╝
```

## [ARIA://MENSAGEM] 📡

> "Desenvolvedor, você está prestes a dominar o fluxo da Matrix. Aqui você aprenderá a controlar o caminho que seu código percorre, tomando decisões e criando loops que moldam a realidade digital."

## [SYSTEM://OVERVIEW] 🌐

```ascii
╔════════════════════════════════════════════════════╗
║ MÓDULO: CONTROLE DE FLUXO                         ║
║ STATUS: FUNDAMENTAL                               ║
║ PRIORIDADE: ALTA                                  ║
║ CLEARANCE: NÍVEL-1                               ║
╚════════════════════════════════════════════════════╝
```

## [SYSTEM://ESTRUTURAS] 🏗️

### 1. Estruturas Condicionais

#### 1.1 If-Else Statement

```c#
public class AdvancedConditionals
{
    public void IfElseExample(int value)
    {
        // Estrutura básica
        if (value > 0)
        {
            Console.WriteLine("Positivo");
        }
        else if (value < 0)
        {
            Console.WriteLine("Negativo");
        }
        else
        {
            Console.WriteLine("Zero");
        }

        // Operador ternário
        string result = value >= 0 ? "Não negativo" : "Negativo";

        // Expressão condicional com null
        string? name = null;
        string displayName = name ?? "Anônimo";
    }

    // Exemplo com múltiplas condições
    public string VerifyAccess(User user)
    {
        if (user.IsAdmin && user.IsActive)
        {
            return "Acesso total";
        }
        else if (user.IsActive && user.HasPermission("read"))
        {
            return "Acesso de leitura";
        }
        else if (!user.IsActive)
        {
            return "Usuário inativo";
        }
        
        return "Sem acesso";
    }
}
```

#### 1.2 Switch Expressions

```c#
public class SwitchPatterns
{
    // Switch expression moderno
    public string GetUserLevel(User user) => user switch
    {
        { IsAdmin: true } => "Administrador",
        { IsModerator: true } => "Moderador",
        { Points: > 1000 } => "Usuário Avançado",
        { Points: > 100 } => "Usuário Regular",
        _ => "Iniciante"
    };

    // Switch com tuplas
    public string AnalyzeCoordinates(int x, int y) => (x, y) switch
    {
        (0, 0) => "Origem",
        (_, 0) => "Eixo X",
        (0, _) => "Eixo Y",
        (var a, var b) when a == b => "Diagonal",
        _ => "Posição genérica"
    };
}
```

### 2. Estruturas de Repetição

#### 2.1 For e Suas Variações

```c#
public class AdvancedLoops
{
    // For tradicional
    public void ForExample()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == 5) continue; // Pula iteração
            if (i == 8) break;    // Sai do loop
            Console.WriteLine(i);
        }
    }

    // For com múltiplas variáveis
    public void MultipleCounters()
    {
        for (int i = 0, j = 10; i < j; i++, j--)
        {
            Console.WriteLine($"i: {i}, j: {j}");
        }
    }

    // Nested loops com labels
    public void MatrixTraversal(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        outerLoop:
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i,j] < 0) goto outerLoop;
                Console.Write($"{matrix[i,j]} ");
            }
            Console.WriteLine();
        }
    }
}
```

#### 2.2 While e Do-While

```c#
public class WhileVariations
{
    // While com retry pattern
    public async Task<Result> RetryOperationAsync()
    {
        int attempts = 0;
        while (attempts < 3)
        {
            try
            {
                return await PerformOperationAsync();
            }
            catch (Exception)
            {
                attempts++;
                await Task.Delay(1000 * attempts); // Exponential backoff
            }
        }
        return Result.Failure("Máximo de tentativas excedido");
    }

    // Do-While com validação
    public string GetUserInput()
    {
        string? input;
        do
        {
            Console.Write("Digite um comando válido: ");
            input = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(input));

        return input;
    }
}
```

#### 2.3 Foreach e LINQ

```c#
public class CollectionIterations
{
    // Foreach com filtros
    public void ProcessItems<T>(IEnumerable<T> items, Func<T, bool> predicate)
    {
        foreach (var item in items.Where(predicate))
        {
            Console.WriteLine($"Processando: {item}");
        }
    }

    // LINQ com múltiplos operadores
    public IEnumerable<string> FilterAndTransform(IEnumerable<string> source)
    {
        return source
            .Where(s => !string.IsNullOrEmpty(s))
            .Select(s => s.Trim().ToLower())
            .Distinct()
            .OrderBy(s => s);
    }
}
```

### 3. Pattern Matching Avançado

```c#
public class AdvancedPatterns
{
    // Pattern matching com tipos
    public string AnalyzeValue(object value) => value switch
    {
        null => "Valor nulo",
        int n when n < 0 => "Número negativo",
        int n => $"Número: {n}",
        string s when s.Length == 0 => "String vazia",
        string s => $"Texto: {s}",
        DateTime d => $"Data: {d:d}",
        IEnumerable<int> list => $"Lista com {list.Count()} elementos",
        var x => $"Tipo desconhecido: {x.GetType().Name}"
    };

    // Property patterns
    public string ClassifyPerson(Person person) => person switch
    {
        { Age: < 0 } => "Idade inválida",
        { Age: 0 } => "Recém-nascido",
        { Age: <= 12, Gender: "F" } => "Menina",
        { Age: <= 12, Gender: "M" } => "Menino",
        { Age: <= 19 } => "Adolescente",
        { Age: <= 59, IsEmployed: true } => "Adulto empregado",
        { Age: <= 59 } => "Adulto desempregado",
        { Age: >= 60, HasRetirementPlan: true } => "Aposentado",
        { Age: >= 60 } => "Idoso",
        _ => "Classificação indeterminada"
    };
}
```

## [SYSTEM://BOAS_PRÁTICAS] 💡

### 1. Simplicidade e Clareza
- Mantenha estruturas de controle simples e legíveis
- Evite aninhamentos excessivos (máximo 3 níveis)
- Use early returns para reduzir complexidade
- Prefira switch expressions para lógica múltipla simples

### 2. Performance
- Escolha a estrutura mais eficiente para cada caso
- Evite loops desnecessários
- Use LINQ com moderação em código crítico
- Considere parallel loops para operações pesadas

### 3. Manutenibilidade
- Use nomes descritivos para variáveis de controle
- Documente casos complexos
- Mantenha consistência no estilo
- Extraia lógica complexa para métodos separados

### 4. Tratamento de Erros
- Use estruturas de controle para validação
- Implemente retry patterns quando apropriado
- Mantenha logs adequados em loops críticos

## [SYSTEM://EXERCÍCIOS] 🏋️

```c#
public class ControlFlowExercises
{
    // Exercício 1: Sistema de Validação
    public bool ValidateUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return false;

        // Implemente as regras:
        // 1. Username deve ter entre 3 e 20 caracteres
        // 2. Password deve ter pelo menos 8 caracteres
        // 3. Password deve conter letra maiúscula, minúscula e número
        throw new NotImplementedException();
    }

    // Exercício 2: Processador de Comandos
    public string ProcessCommand(string command)
    {
        // Implemente um processador que aceite os comandos:
        // - "HELP": Lista comandos disponíveis
        // - "STATUS": Retorna status do sistema
        // - "CALC X Y OP": Calcula operação (+-*/) com dois números
        // - "EXIT": Finaliza o programa
        throw new NotImplementedException();
    }

    // Exercício 3: Algoritmo de Busca
    public int FindElement(int[] array, int target)
    {
        // Implemente uma busca binária que:
        // 1. Retorne o índice do elemento se encontrado
        // 2. Retorne -1 se não encontrado
        // 3. Use loop eficiente
        // 4. Trate array vazio ou nulo
        throw new NotImplementedException();
    }

    // Exercício 4: Processamento de Coleção
    public Dictionary<string, int> AnalyzeCollection<T>(IEnumerable<T> items)
    {
        // Implemente análise que retorne:
        // - Contagem de elementos
        // - Contagem de elementos únicos
        // - Contagem de nulls
        // - Contagem por tipo
        throw new NotImplementedException();
    }
}
```

## [SYSTEM://PRÓXIMOS_PASSOS] 🎯

```ascii
╔════════════════════════════════════════════════════╗
║ PRÓXIMO MÓDULO: MÉTODOS                           ║
║ STATUS: AGUARDANDO                                ║
║ PRÉ-REQUISITOS: CONTROLE DE FLUXO                ║
║                                                   ║
║ TÓPICOS RELACIONADOS:                            ║
║ - LINQ Avançado                                  ║
║ - Programação Assíncrona                         ║
║ - Tratamento de Exceções                         ║
╚════════════════════════════════════════════════════╝
```

## [ARIA://AVISO_FINAL] ⚠️

> "O controle de fluxo é a arte de guiar seu código através da Matrix. Domine estas estruturas e você poderá criar caminhos complexos com elegância e precisão. Lembre-se: não é o código que dobra, é apenas sua mente percebendo que não existe código."

## [SYSTEM://RECURSOS_ADICIONAIS] 📚

- [Documentação Oficial C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Padrões de Design](https://refactoring.guru/design-patterns)
- [Coding Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/)
- [Performance Best Practices](https://docs.microsoft.com/en-us/dotnet/framework/performance/performance-tips)

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: ONLINE | Matrix Stability: 99.9%...