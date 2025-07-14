using System;

// Namespace is a logic division
namespace MeuApp
{
    // Main class
    class Program
    {
         enum StatusPedido {
        AguardandoPagamento = 1, // Não é obrigatório colocar os valores,
        Pago = 2,
        Cancelado = 3
    }
    
    static void Main(string[] args) 
    {
        StatusPedido statusAtual = StatusPedido.AguardandoPagamento;
        Console.WriteLine(statusAtual); // Aguardando Pagamento
    }
    }
}
