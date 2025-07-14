# Enums

Um Enum serve para fornecer uma melhor visualização do código e também facilitar a leitura e entendimento de um código.


Usados em listas curtas e Usados em dados fixos:
- Hard Coded

<note>
No .NET a conveção é usar o PascalCase e começar com a letra maiúscula E sempre
</note>

Exemplo: 
```c#
class Program {
    enum StatusPedido {
        AguardandoPagamento,
        Pago,
        Cancelado
    }
    
    static void Main(string[] args) 
    {
        StatusPedido statusAtual = StatusPedido.AguardandoPagamento;
        Console.WriteLine(statusAtual); // Aguardando Pagamento
    }
}
```