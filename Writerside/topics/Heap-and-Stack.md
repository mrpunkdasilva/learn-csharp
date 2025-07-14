# Stack vs. Heap: Gerenciamento de Memória em C#

Todo programa .NET utiliza duas áreas de memória fundamentais para sua execução: a **Stack (Pilha)** e a **Heap (Monte)**. Compreender como elas funcionam e o que é armazenado em cada uma é crucial para escrever código eficiente e prever seu comportamento, especialmente no que diz respeito a performance e ciclo de vida das variáveis.

## A Stack (Pilha)

A Stack é uma estrutura de dados do tipo **LIFO (Last-In, First-Out)**, ou seja, o último item a entrar é o primeiro a sair. É uma área de memória extremamente rápida e eficiente, usada para gerenciar o fluxo de execução do programa.

**O que é armazenado na Stack?**

1.  **Tipos de Valor (`Value Types`):** Variáveis locais de tipos como `int`, `double`, `bool`, `char`, e `structs` são armazenadas diretamente na Stack.
2.  **Parâmetros de Métodos:** Os valores passados como argumentos para um método são colocados na Stack.
3.  **Referências a Objetos:** Quando você cria um objeto (um tipo de referência), o objeto em si vai para a Heap, mas a **variável que aponta para ele** (a referência/ponteiro) é armazenada na Stack.
4.  **Controle de Execução:** A Stack gerencia qual método está em execução no momento. Cada chamada de método cria um "quadro" (*stack frame*) que contém suas variáveis locais e parâmetros. Quando o método termina, seu quadro é removido da pilha.

**Características Principais:**

-   **Velocidade:** Alocação e desalocação são instantâneas (apenas o ponteiro da Stack é movido).
-   **Tamanho Fixo:** A memória para um quadro de pilha é alocada no início da chamada do método.
-   **Gerenciamento Automático:** A memória é liberada automaticamente quando a variável sai de escopo (o método termina). O Garbage Collector **não atua** na Stack.
-   **Limitação de Tamanho:** A Stack tem um tamanho limitado. Chamadas recursivas infinitas podem causar um `StackOverflowException`.

### Diagrama da Stack

```text
// Código
void MetodoA() {
    int x = 10;
    MetodoB();
}

void MetodoB() {
    bool y = true;
}
```

```text
      STACK (Durante a execução de MetodoB)
+--------------------+
| Frame do MetodoB:  |  <-- Topo da Stack
|   y = true         |
+--------------------+
| Frame do MetodoA:  |
|   x = 10           |
+--------------------+
| ... (outros frames) ...
+--------------------+
```

## A Heap (Monte)

A Heap é uma área de memória maior e mais flexível, usada para alocação dinâmica. É aqui que os objetos (instâncias de classes) residem.

**O que é armazenado na Heap?**

1.  **Instâncias de Tipos de Referência (`Reference Types`):** Qualquer objeto criado com a palavra-chave `new` (como instâncias de `class`, `arrays`, `string`, `delegates`) é alocado na Heap.

**Características Principais:**

-   **Alocação Dinâmica:** Objetos podem ser alocados e desalocados em qualquer ordem.
-   **Velocidade:** A alocação na Heap é mais lenta que na Stack, pois o sistema precisa encontrar um bloco de memória livre que seja grande o suficiente.
-   **Gerenciamento pelo Garbage Collector (GC):** A memória na Heap não é liberada automaticamente. O GC é um processo que roda em segundo plano, identifica objetos na Heap que não são mais referenciados por nenhuma variável na Stack e libera o espaço que eles ocupavam.
-   **Tamanho Maior:** A Heap é muito maior que a Stack, limitada apenas pela memória virtual disponível no sistema.

## Exemplo Combinado: Stack e Heap em Ação

Vamos analisar um exemplo que usa ambos os tipos e visualizar a memória.

```c#
public class Estudante // Reference Type
{
    public int Matricula { get; set; }
}

public void Executar()
{
    int idade = 25; // Value Type
    Estudante aluno = new Estudante(); // Reference Type
    aluno.Matricula = 101;
}
```

### Diagrama da Memória Durante a Execução

```text
          STACK                                  HEAP
+-------------------------+          +----------------------------+
| Frame do método Executar: |
|                         |
|   idade = 25            |          // Objeto alocado na Heap
|                         |
|   aluno (ref: 0xA1B2)   |--------->+ Objeto Estudante (0xA1B2)  |
|                         |          |   - Matricula: 101         |
+-------------------------+          +----------------------------+
| ... (outros frames) ... |
+-------------------------+
```

**Análise:**

1.  A variável `idade` (tipo `int`) é um tipo de valor, então seu dado (`25`) é armazenado diretamente na Stack.
2.  A variável `aluno` é uma referência. Ela também fica na Stack, mas seu valor não é o objeto em si, e sim o **endereço** (`0xA1B2`) onde o objeto `Estudante` foi alocado na Heap.
3.  O objeto `Estudante` real, com seu campo `Matricula`, reside na Heap.

## Tabela Comparativa

| Característica | Stack (Pilha) | Heap (Monte) |
| :--- | :--- | :--- |
| **Velocidade** | Muito Rápida | Mais Lenta |
| **Gerenciamento** | Automático (LIFO) | Garbage Collector (GC) |
| **Armazena** | Tipos de Valor, Referências | Instâncias de Tipos de Referência |
| **Ciclo de Vida** | Curto (limitado ao escopo do método) | Longo (até não ser mais referenciado) |
| **Tamanho** | Pequeno e Fixo (por thread) | Grande e Dinâmico |