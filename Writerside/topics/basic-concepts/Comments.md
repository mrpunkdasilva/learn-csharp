# Comentários

Comentários são anotações no código-fonte que são **ignoradas pelo compilador**. Eles existem exclusivamente para os desenvolvedores, servindo para esclarecer partes complexas do código, deixar lembretes ou gerar documentação externa.

## A Regra de Ouro: Comente o "Porquê", não o "O Quê"

Um bom código deve ser autoexplicativo. O código em si já mostra **o que** ele está fazendo. Comentários eficazes devem explicar **por que** o código está fazendo algo de uma maneira específica, especialmente se a lógica não for óbvia.

-   **Comentário Ruim (redundante):**
    ```c#
    // Incrementa i em 1
    i++;
    ```

-   **Comentário Bom (explica a intenção):**
    ```c#
    // Usamos um algoritmo de ordenação customizado aqui porque os testes de performance
    // mostraram que ele é 2x mais rápido para o nosso conjunto de dados específico.
    CustomSort(minhaLista);
    ```

## Tipos de Comentários

### 1. Comentários de Linha Única (`//`)

Começam com `//` e continuam até o final da linha. São ideais para notas curtas e explicações pontuais.

```c#
// Verifica se o usuário tem permissão de administrador.
if (user.IsAdmin)
{
    // ...
}
```

### 2. Comentários de Múltiplas Linhas (`/* ... */`)

Começam com `/*` и terminam com `*/`. Podem abranger várias linhas e são úteis para desativar temporariamente grandes blocos de código ou para comentários mais longos.

```c#
/*
    Este é um método temporário para testes de carga.
    Ele simula a criação de 10.000 usuários e deve ser removido
    antes de enviarmos o código para produção.
*/
public void GerarCargaDeTeste()
{
    // ...
}
```

### 3. Comentários de Documentação XML (`///`)

Estes são os comentários mais poderosos do C#. Eles começam com `///` e usam tags XML para descrever o que classes, métodos e propriedades fazem. O Visual Studio e outras IDEs usam esses comentários para fornecer o **IntelliSense** (autocompletar com documentação), e eles podem ser usados para gerar arquivos de documentação HTML automaticamente.

**Tags XML Comuns:**

-   `<summary>`: Um resumo geral do que o membro faz.
-   `<param name="nomeDoParametro">`: Descreve um parâmetro do método.
-   `<returns>`: Descreve o valor de retorno do método.
-   `<exception cref="TipoDaExcecao">`: Descreve uma exceção que o método pode lançar.
-   `<remarks>`: Fornece informações adicionais mais detalhadas.

**Exemplo Completo:**

```c#
/// <summary>
/// Calcula o pagamento mensal de um empréstimo com base na taxa de juros, 
/// número de parcelas e valor do empréstimo.
/// </summary>
/// <param name="taxaAnual">A taxa de juros anual (ex: 0.05 para 5%).</param>
/// <param name="numParcelas">O número total de parcelas.</param>
/// <param name="valorEmprestimo">O valor total do empréstimo.</param>
/// <returns>O valor do pagamento mensal.</returns>
/// <exception cref="ArgumentException">Lançada quando um dos parâmetros numéricos é negativo.</exception>
public double CalcularPagamentoMensal(double taxaAnual, int numParcelas, decimal valorEmprestimo)
{
    if (taxaAnual < 0 || numParcelas < 0 || valorEmprestimo < 0)
    {
        throw new ArgumentException("Parâmetros não podem ser negativos.");
    }
    // ... lógica de cálculo
    return 0.0;
}
```

Ao usar a função `CalcularPagamentoMensal` em outro lugar, a IDE mostrará a `summary`, as descrições dos parâmetros e o que ela retorna, tornando o código muito mais fácil de usar.