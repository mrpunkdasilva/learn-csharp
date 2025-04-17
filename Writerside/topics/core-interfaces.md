# [SYSTEM://INTERFACES] 🎭

```ascii
╔══════════════════════════════════════════════════════════════════╗
║ ██╗███╗   ██╗████████╗███████╗██████╗ ███████╗ █████╗  ██████╗███████╗
║ ██║████╗  ██║╚══██╔══╝██╔════╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝
║ ██║██╔██╗ ██║   ██║   █████╗  ██████╔╝█████╗  ███████║██║     █████╗  
║ ██║██║╚██╗██║   ██║   ██╔══╝  ██╔══██╗██╔══╝  ██╔══██║██║     ██╔══╝  
║ ██║██║ ╚████║   ██║   ███████╗██║  ██║██║     ██║  ██║╚██████╗███████╗
║ ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝  ╚═╝ ╚═════╝╚══════╝
╚══════════════════════════════════════════════════════════════════╝
```

## [SYSTEM://CONCEITO] 🧬

Uma interface é um contrato que define um conjunto de membros que uma classe deve implementar. É como um menu de restaurante: lista o que está disponível, mas não diz como é preparado.

```c#
public interface ILogger
{
    void Log(string message);
    void LogError(string error);
    bool IsEnabled { get; }
}

public class ConsoleLogger : ILogger
{
    public bool IsEnabled { get; set; } = true;
    
    public void Log(string message)
    {
        if (IsEnabled)
            Console.WriteLine($"LOG: {message}");
    }
    
    public void LogError(string error)
    {
        if (IsEnabled)
            Console.WriteLine($"ERROR: {error}");
    }
}
```

## [SYSTEM://CARACTERÍSTICAS] 🎯

### 1. Membros Implícitos
```c#
public interface IDataAccess
{
    // Implicitamente public e abstract
    void SaveData(string data);
    string LoadData();
    
    // Propriedades
    string ConnectionString { get; set; }
}
```

### 2. Implementação Default (C# 8.0+)
```c#
public interface IRepository
{
    void Save();
    
    // Implementação padrão
    void Delete() => Console.WriteLine("Implementação padrão de Delete");
    
    // Propriedade com implementação default
    bool IsConnected { get => true; }
}
```

### 3. Herança Múltipla
```c#
public interface IReadable
{
    string Read();
}

public interface IWritable
{
    void Write(string data);
}

public interface IFile : IReadable, IWritable
{
    string Path { get; set; }
}
```

## [SYSTEM://PADRÕES_COMUNS] 🎨

### 1. Repository Pattern
```c#
public interface IRepository<T>
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}

public class UserRepository : IRepository<User>
{
    private readonly List<User> _users = new();
    
    public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
    public IEnumerable<User> GetAll() => _users;
    public void Add(User entity) => _users.Add(entity);
    public void Update(User entity) 
    {
        var index = _users.FindIndex(u => u.Id == entity.Id);
        if (index != -1) _users[index] = entity;
    }
    public void Delete(int id) => _users.RemoveAll(u => u.Id == id);
}
```

### 2. Strategy Pattern
```c#
public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processando {amount:C} via cartão de crédito");
    }
}

public class PixPayment : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processando {amount:C} via PIX");
    }
}
```

## [SYSTEM://BOAS_PRÁTICAS] 💡

### 1. Interface Segregation Principle (ISP)
```c#
// Ruim: Interface muito grande
public interface IVeiculo
{
    void Ligar();
    void Desligar();
    void Acelerar();
    void Frear();
    void Decolar();
    void Pousar();
    void Submergir();
    void Emergir();
}

// Bom: Interfaces segregadas
public interface IVeiculoTerrestre
{
    void Ligar();
    void Desligar();
    void Acelerar();
    void Frear();
}

public interface IAeronave
{
    void Decolar();
    void Pousar();
}

public interface ISubmarino
{
    void Submergir();
    void Emergir();
}
```

### 2. Dependency Inversion Principle (DIP)
```c#
public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public class OrderProcessor
{
    private readonly IEmailService _emailService;
    
    public OrderProcessor(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    public void ProcessOrder(Order order)
    {
        // Processa pedido
        _emailService.SendEmail(order.CustomerEmail, "Pedido Confirmado", "Seu pedido foi processado");
    }
}
```

## [SYSTEM://TÉCNICAS_AVANÇADAS] 🚀

### 1. Implementação Explícita
```c#
public interface IA
{
    void Method();
}

public interface IB
{
    void Method();
}

public class MyClass : IA, IB
{
    // Implementação explícita
    void IA.Method()
    {
        Console.WriteLine("IA.Method()");
    }
    
    void IB.Method()
    {
        Console.WriteLine("IB.Method()");
    }
}
```

### 2. Interfaces Genéricas
```c#
public interface ICache<T>
{
    void Set(string key, T value);
    T Get(string key);
    bool TryGet(string key, out T value);
    void Remove(string key);
}

public class RedisCache<T> : ICache<T>
{
    // Implementação usando Redis
}

public class MemoryCache<T> : ICache<T>
{
    // Implementação em memória
}
```

## [SYSTEM://EXERCÍCIOS] 🏋️

1. Implemente um sistema de notificações com diferentes canais (email, SMS, push)
2. Crie um sistema de plugins usando interfaces
3. Desenvolva um padrão Strategy para diferentes métodos de ordenação
4. Implemente um cache com interface genérica

## [SYSTEM://DICAS] 💭

1. Mantenha interfaces pequenas e coesas
2. Use nomes começando com "I" por convenção
3. Prefira composição à herança
4. Implemente apenas os membros necessários
5. Use interfaces para inversão de dependência

## [SYSTEM://RECURSOS] 📚

- [Interface Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/interfaces)
- [C# Interface Best Practices](https://docs.microsoft.com/dotnet/csharp/programming-guide/interfaces/)
- [Design Patterns with Interfaces](https://refactoring.guru/design-patterns)

---
> [!WARNING]
> "Interfaces são contratos. Quebre-os e o compilador quebrará você."

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: ONLINE | Matrix Stability: 99.9%