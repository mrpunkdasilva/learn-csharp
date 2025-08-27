# Lançando Exceções (Throwing Exceptions)

Lançar uma exceção é o ato de sinalizar, de forma programática, que uma condição de erro ou um estado inesperado ocorreu e que o método ou bloco de código atual não tem a capacidade de resolvê-lo. Ao lançar uma exceção, o fluxo normal de execução do programa é interrompido, e o runtime do .NET começa a procurar por um tratador de exceções compatível (um bloco `catch`) na pilha de chamadas.

## Analogia: A Linha de Montagem

Pense em uma linha de montagem em uma fábrica. Cada operário (método) tem uma tarefa específica. Se um operário encontra um defeito que ele não pode consertar (por exemplo, uma peça faltando que deveria ter vindo da estação anterior), ele não ignora o problema nem tenta continuar. Ele imediatamente puxa uma alavanca de emergência (`throw`).

Essa ação para a linha de montagem e aciona um alarme. Um supervisor (o bloco `catch`) é então notificado. A notificação pode incluir detalhes sobre qual foi o problema e onde ele ocorreu. O supervisor pode então decidir o que fazer: descartar o produto, registrar o incidente ou tentar consertar o problema. Se o supervisor local não souber o que fazer, ele pode escalar o problema para um gerente de nível superior (relançar a exceção).

## A Instrução `throw`

A sintaxe para lançar uma exceção é direta. Você usa a palavra-chave `throw` seguida por uma nova instância de um objeto de exceção.

```c#
// The expression after 'throw' must be an object derived from System.Exception
throw new ArgumentNullException(nameof(userName));
```

Quando esta linha é executada, o programa para o que está fazendo e começa a "desenrolar" a pilha de chamadas, procurando por um `catch` que possa lidar com uma `ArgumentNullException`.

### Quando Lançar uma Exceção?

Você deve lançar uma exceção quando um método não pode cumprir seu contrato ou propósito declarado.

-   **Argumentos inválidos**: Um método recebe um argumento que o impede de funcionar. Use `ArgumentException` ou seus derivados (`ArgumentNullException`, `ArgumentOutOfRangeException`).

    ```c#
    public void SetAge(int age)
    {
        if (age < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be negative.");
        }
        this.Age = age;
    }
    ```

-   **Estado de objeto inválido**: Uma operação é chamada em um objeto, mas o estado atual do objeto não permite essa operação. Use `InvalidOperationException`.

    ```c#
    public void SendEmail()
    {
        if (!this.IsConnected)
        {
            throw new InvalidOperationException("Cannot send email. No SMTP connection established.");
        }
        // ... sending logic
    }
    ```

## Relançando Exceções: `throw` vs. `throw ex`

Esta é uma das distinções mais importantes e que frequentemente causa bugs difíceis de rastrear. Às vezes, dentro de um bloco `catch`, você pode querer executar alguma ação (como registrar o erro) e depois deixar que a exceção continue sua jornada pela pilha de chamadas. Isso é chamado de relançar a exceção.

-   `throw;`: **A forma correta.** Esta sintaxe relança a exceção original, **preservando o stack trace original**. O stack trace é o "mapa" que mostra a sequência exata de chamadas de método que levaram ao erro. Preservá-lo é vital para a depuração.

-   `throw ex;`: **A forma incorreta.** Esta sintaxe lança a exceção como se ela estivesse se originando na linha atual. Isso **destrói o stack trace original**, fazendo parecer que o erro começou no bloco `catch`, escondendo a verdadeira causa raiz do problema.

### Exemplo Prático

```c#
public void ProcessData()
{
    try
    {
        // Call a method that might fail
        ConnectToDatabase("invalid_connection_string");
    }
    catch (SqlException ex)
    {
        // We log the error for later analysis
        Console.WriteLine("LOG: Failed to connect to the database.");

        // CORRECT way: The exception continues with its origin intact.
        // The next 'catch' will know the error came from 'ConnectToDatabase'.
        throw;

        // INCORRECT way: If we used 'throw ex;', the stack trace would be reset.
        // The next 'catch' would think the error originated here, in 'ProcessData'.
        // throw ex; // NEVER DO THIS!
    }
}
```

## Práticas Recomendadas

1.  **Não use exceções para controle de fluxo normal**: Exceções são para condições *excepcionais*. Para cenários esperados, como um usuário digitando um texto em vez de um número, use métodos como `int.TryParse`.

2.  **Lance a exceção mais específica possível**: Em vez de `throw new Exception("O argumento é nulo")`, prefira `throw new ArgumentNullException("nomeDoArgumento")`. Isso permite que os blocos `catch` sejam mais seletivos.

3.  **Documente as exceções que seu método lança**: Use a tag `<exception>` nos comentários XML para informar aos outros desenvolvedores quais exceções eles devem esperar.

    ```c#
    /// <summary>
    /// Calculates the factorial of a number.
    /// </summary>
    /// <param name="number">The number to calculate the factorial of.</param>
    /// <returns>The factorial value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the number is negative.</exception>
    public static long Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Factorial is not defined for negative numbers.");
        }
        // ... logic
    }
    ```

## Referências Oficiais da Microsoft

-   [Instrução `throw` (Referência de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/throw)
-   [Práticas recomendadas para exceções](https://learn.microsoft.com/pt-br/dotnet/standard/exceptions/best-practices-for-exceptions)
