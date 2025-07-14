# Procedimentos

Em C#, o termo "procedimento" é mais conhecido como um **método** que não retorna nenhum valor, indicado pela palavra-chave `void`. O propósito principal de um método `void` é executar uma ação e causar um **efeito colateral** (*side effect*), como modificar o estado de uma variável externa, imprimir algo no console, ou interagir com um banco de dados.

A principal característica é que eles executam uma tarefa, mas **não retornam um valor** para o código que os chamou.

## Declaração

A sintaxe para declarar um método `void` é a seguinte:

```c#
[modificador_de_acesso] static void [NomeDoMetodo]([parametros])
{
    // Corpo do método: código a ser executado
}
```

- **`[modificador_de_acesso]`**: Define a visibilidade (`public`, `private`, etc.).
- **`static`**: Indica que o método pertence à própria classe e pode ser chamado sem criar uma instância.
- **`void`**: Palavra-chave que especifica que o método não retorna valor.
- **`[NomeDoMetodo]`**: O nome do método, que deve ser um verbo ou frase verbal que descreva a ação (ex: `CalcularImpostos`, `ImprimirRelatorio`).
- **`[parametros]`**: A lista de dados que o método recebe para trabalhar.

### Exemplo: Método com Parâmetros

Métodos `void` frequentemente usam parâmetros para direcionar sua ação.

```c#
// Declaração de um método que saúda um usuário
public static void SaudarUsuario(string nome)
{
    Console.WriteLine($"Olá, {nome}! Bem-vindo ao sistema.");
}

// Chamada ao método
SaudarUsuario("Ana"); // Saída: Olá, Ana! Bem-vindo ao sistema.
```

## Modificando Dados Externos com `ref`

Mesmo sem retornar um valor, um método `void` pode modificar variáveis que foram passadas a ele por referência usando a palavra-chave `ref`. Isso permite que o método altere o valor da variável original.

> **Atenção:** A variável passada como `ref` **deve ser inicializada** antes da chamada do método.

```c#
// Método que troca os valores de duas variáveis
public static void TrocarValores(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

// Uso
int x = 5;
int y = 10;
Console.WriteLine($"Antes: x = {x}, y = {y}");

TrocarValores(ref x, ref y);

Console.WriteLine($"Depois: x = {x}, y = {y}"); // Saída: Depois: x = 10, y = 5
```

## A Instrução `return` em Métodos `void`

Embora métodos `void` não retornem um valor, você pode usar a instrução `return;` para **encerrar a execução do método prematuramente**. Isso é uma técnica de controle de fluxo valiosa, conhecida como *early exit*.

```c#
public static void ProcessarPedido(int quantidade)
{
    if (quantidade <= 0)
    {
        Console.WriteLine("Erro: A quantidade deve ser positiva.");
        return; // Sai do método imediatamente
    }

    if (quantidade > 100)
    {
        Console.WriteLine("Erro: Pedido excede o limite de estoque.");
        return; // Outro ponto de saída
    }

    // Este código só será executado se as validações passarem
    Console.WriteLine($"Pedido de {quantidade} unidades processado com sucesso.");
}
```

<note>

Em C#, tanto os métodos que retornam valor (funções) quanto os que não retornam (procedimentos `void`) são chamados genericamente de **métodos**. A escolha entre um método `void` e um com retorno depende da sua intenção: você quer **realizar uma ação** (`void`) ou **obter um valor** (com retorno)?

</note>