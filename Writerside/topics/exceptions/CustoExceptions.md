# Exceções Personalizadas (Custom Exceptions)

No desenvolvimento de software, prever e gerenciar erros é tão crucial quanto escrever o código para o "caminho feliz". O .NET oferece uma vasta hierarquia de classes de exceção para erros comuns, como `FileNotFoundException` ou `ArgumentNullException`. No entanto, há momentos em que essas exceções genéricas não são suficientes para descrever um problema específico do domínio da sua aplicação. É aqui que entram as exceções personalizadas.

## Analogia: O Painel do Carro

Pense nas exceções do sistema como as luzes de advertência genéricas em um carro. Uma luz de "Verificar Motor" (`System.Exception`) informa que algo está errado, mas não diz o quê. Pode ser um problema no motor, na transmissão ou no sistema de emissões. É um sinal útil, mas vago.

Uma exceção personalizada, por outro lado, é como uma luz de advertência específica: "Pressão Baixa no Pneu" ou "Nível de Óleo Baixo". Ela não apenas informa que há um problema, mas também **qual é o problema**, permitindo que o motorista (ou o desenvolvedor) tome a ação correta e imediata. Melhor ainda, uma exceção personalizada pode carregar dados extras, como qual pneu está com a pressão baixa ou qual era o nível do óleo.

## Por Que Criar Exceções Personalizadas?

1.  **Clareza e Semântica**: Capturar uma `InsufficientBalanceException` é muito mais legível e explícito do que capturar uma `InvalidOperationException` e ter que inspecionar a mensagem de texto para entender o contexto. Isso torna o código de tratamento de erros mais limpo e auto-documentado.

2.  **Adicionar Contexto ao Erro**: Exceções personalizadas podem ter propriedades e métodos próprios. Isso permite anexar informações valiosas sobre o estado do sistema no momento em que o erro ocorreu. Por exemplo, em uma `InsufficientBalanceException`, você pode incluir o saldo atual e o valor da tentativa de saque.

3.  **Controle Granular do Fluxo**: Com exceções específicas, você pode criar blocos `catch` distintos para lidar com diferentes cenários de erro de maneiras diferentes. Um erro de "Usuário Não Encontrado" pode ser tratado de uma forma, enquanto um erro de "Conexão com o Banco de Dados Falhou" pode exigir uma lógica de nova tentativa.

## Como Implementar uma Exceção Personalizada

A criação de uma exceção personalizada segue um padrão bem definido. A regra fundamental é herdar da classe `System.Exception` (ou de outra exceção mais específica, se fizer sentido).

### Melhores Práticas de Implementação

-   **Nome**: O nome da classe deve terminar com o sufixo `Exception`.
-   **Herança**: Herde diretamente de `System.Exception`.
-   **Construtores**: Forneça os três construtores mais comuns para garantir que sua exceção se comporte como as exceções padrão do .NET.
-   **Serialização**: Marque a exceção com o atributo `[Serializable]` para permitir que ela seja transportada através de limites de domínio de aplicação (embora menos crítico em muitas arquiteturas modernas, ainda é uma boa prática).

### Exemplo Detalhado: `InsufficientBalanceException`

Vamos criar uma exceção para um sistema bancário.

```c#
using System;
using System.Runtime.Serialization;

[Serializable]
public class InsufficientBalanceException : Exception
{
    public decimal CurrentBalance { get; }
    public decimal WithdrawalAmount { get; }

    // 1. Default constructor
    public InsufficientBalanceException()
        : base("Insufficient balance to perform the operation.") { }

    // 2. Constructor that accepts a custom message
    public InsufficientBalanceException(string message)
        : base(message) { }

    // 3. Constructor that wraps an inner exception
    public InsufficientBalanceException(string message, Exception innerException)
        : base(message, innerException) { }

    // 4. Rich constructor with specific error data
    public InsufficientBalanceException(decimal currentBalance, decimal withdrawalAmount)
        : base($"Attempted to withdraw {withdrawalAmount:C} when the balance was only {currentBalance:C}.")
    {
        CurrentBalance = currentBalance;
        WithdrawalAmount = withdrawalAmount;
    }

    // Constructor for deserialization
    protected InsufficientBalanceException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
```

## Lançando e Capturando a Exceção

Uma vez definida, você pode lançá-la (`throw`) em seu código quando a condição de erro específica for atendida e capturá-la (`catch`) em um bloco de tratamento de erros.

```c#
public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "The withdrawal amount must be positive.");
        }

        if (amount > Balance)
        {
            // Throwing our custom exception with context!
            throw new InsufficientBalanceException(Balance, amount);
        }

        Balance -= amount;
        Console.WriteLine($"Withdrawal of {amount:C} successful. New balance: {Balance:C}");
    }
}

public class ATM
{
    public static void Main()
    {
        var account = new BankAccount(100.00m);

        try
        {
            Console.WriteLine("Attempting to withdraw 50.00...");
            account.Withdraw(50.00m); // Success

            Console.WriteLine("\nAttempting to withdraw 80.00...");
            account.Withdraw(80.00m); // Failure
        }
        catch (InsufficientBalanceException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n--- Operation Failed ---");
            Console.WriteLine($"Error Detail: {ex.Message}");
            Console.WriteLine($"Recommended Action: Try a smaller amount, up to {ex.CurrentBalance:C}.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.GetType().Name} - {ex.Message}");
        }
    }
}
```

### Saída do Console:

```
Attempting to withdraw 50.00...
Withdrawal of $50.00 successful. New balance: $50.00

Attempting to withdraw 80.00...

--- Operation Failed ---
Error Detail: Attempted to withdraw $80.00 when the balance was only $50.00.
Recommended Action: Try a smaller amount, up to $50.00.
```

## Referências Oficiais da Microsoft

Para um aprofundamento no tópico e para seguir as diretrizes oficiais, consulte a documentação da Microsoft:

-   [Criando e lançando exceções](https://learn.microsoft.com/pt-br/dotnet/standard/exceptions/creating-and-throwing-exceptions)
-   [Práticas recomendadas para exceções](https://learn.microsoft.com/pt-br/dotnet/standard/exceptions/best-practices-for-exceptions)