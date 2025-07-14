# Palavras-Chave (Keywords)

Palavras-chave (ou *keywords*) são identificadores reservados que têm um significado especial para o compilador do C#. Elas são os blocos de construção fundamentais da linguagem e não podem ser usadas como nomes de variáveis, métodos ou classes (a menos que sejam prefixadas com `@`, o que é raro e geralmente desaconselhado).

<note>
Você não precisa memorizar todas. As IDEs modernas, como Visual Studio e Rider, destacam as palavras-chave e avisam se você tentar usá-las incorretamente. O objetivo aqui é entender as categorias e as mais comuns.
</note>

## Categorias de Palavras-Chave Comuns

### Modificadores de Acesso
Controlam a visibilidade (onde o código pode ser acessado).
-   `public`: Acesso não restrito.
-   `private`: Acesso limitado à classe que o contém.
-   `protected`: Acesso limitado à classe que o contém e a classes derivadas (herança).
-   `internal`: Acesso limitado ao assembly atual (ao projeto).

### Declaração de Tipos
Usadas para definir os diferentes tipos de estruturas de dados.
-   `class`: Define um tipo de referência que contém dados (campos) e comportamento (métodos).
-   `struct`: Define um tipo de valor, geralmente para pequenas estruturas de dados.
-   `interface`: Define um contrato (um conjunto de métodos e propriedades) que uma classe ou struct pode implementar.
-   `enum`: Define um conjunto de constantes nomeadas (ex: DiasDaSemana).
-   `delegate`: Define um tipo que representa uma referência a um método com uma assinatura específica.

### Modificadores de Membros
Alteram o comportamento de membros de uma classe.
-   `static`: Indica que um membro pertence ao tipo em si, não a uma instância.
-   `const`: Declara um campo cujo valor é uma constante de tempo de compilação.
-   `readonly`: Declara um campo cujo valor só pode ser definido na declaração ou no construtor.
-   `abstract`: Indica que uma classe ou membro tem uma implementação ausente ou incompleta (deve ser implementado por uma classe derivada).
-   `virtual`: Permite que um método em uma classe base seja sobrescrito por uma classe derivada.
-   `override`: Sobrescreve um método `virtual` ou `abstract` de uma classe base.

### Nível de Método
Usadas dentro de métodos ou para definir o comportamento de métodos.
-   `void`: Especifica que um método não retorna nenhum valor.
-   `return`: Retorna o controle (e opcionalmente um valor) do método para quem o chamou.
-   `params`: Permite que um método aceite um número variável de argumentos.
-   `ref`, `out`, `in`: Modificadores de parâmetro que controlam como os argumentos são passados para os métodos.

### Instruções e Controle de Fluxo
Controlam a ordem em que o código é executado.
-   `if`, `else`: Executam código condicionalmente.
-   `switch`, `case`, `default`: Executam código com base em uma correspondência de padrões.
-   `for`, `foreach`, `while`, `do`: Criam laços (loops).
-   `break`: Sai de um laço ou de um `switch`.
-   `continue`: Pula para a próxima iteração de um laço.
-   `try`, `catch`, `finally`, `throw`: Manipulação de exceções.

### Gerenciamento de Namespaces e Tipos
-   `using`: Importa um namespace ou gerencia recursos `IDisposable`.
-   `namespace`: Declara um escopo para organizar o código.
-   `new`: Cria uma nova instância de um tipo ou oculta um membro de uma classe base.
-   `typeof`: Obtém o objeto `System.Type` para um tipo.

---

Para uma lista exaustiva e detalhada de todas as palavras-chave, a **documentação oficial da Microsoft é a fonte definitiva**.

[Referência Completa de Palavras-Chave do C# (Microsoft Docs)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/)
