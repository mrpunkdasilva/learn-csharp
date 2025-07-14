# Namespaces

Em C#, um `namespace` é um contêiner organizacional para classes e outros namespaces. Sua principal finalidade é fornecer um nível de separação para o código, ajudando a **evitar conflitos de nomes** e a estruturar grandes projetos de forma lógica.

Pense em um namespace como o sobrenome de uma classe. Você pode ter duas pessoas chamadas "João", mas elas são diferentes se uma for "João Silva" e a outra "João Souza". Da mesma forma, você pode ter duas classes `Cliente`, desde que elas estejam em namespaces diferentes (ex: `MeuApp.Vendas.Cliente` e `MeuApp.Suporte.Cliente`).

## Declaração e Estrutura

Um namespace é declarado com a palavra-chave `namespace`, seguida por um nome e um bloco de código `{}` contendo as classes.

```c#
// O nome do namespace geralmente segue a estrutura do projeto.
namespace MeuApp.Servicos
{
    public class EmailService
    {
        // ... código do serviço de email
    }
}
```

### Relação com a Estrutura de Pastas

Por convenção, a estrutura de namespaces de um projeto **espelha a estrutura de pastas**. Isso torna a navegação e a localização de arquivos muito mais intuitivas.

-   Se você tem um arquivo na pasta `Projeto/Models/User.cs`, o namespace dentro de `User.cs` deve ser `Projeto.Models`.
-   Se você tem um arquivo em `Projeto/Services/Payment/PayPalService.cs`, o namespace deve ser `Projeto.Services.Payment`.

As IDEs modernas, como o Visual Studio e o Rider, gerenciam essa estrutura automaticamente ao criar novos arquivos.

## Namespaces Aninhados

Você pode aninhar namespaces para criar hierarquias ainda mais detalhadas.

```c#
namespace MeuApp.Servicos
{
    namespace Notificacoes
    {
        public class PushService { }
    }
}

// A classe PushService pode ser acessada usando seu nome completo:
// MeuApp.Servicos.Notificacoes.PushService service;
```

## O Namespace Global

Qualquer tipo que não é declarado dentro de um namespace reside no *namespace global*. Isso é geralmente desaconselhado para evitar poluir o escopo global e criar possíveis conflitos com outras bibliotecas.

## Boas Práticas

1.  **Um Tipo por Arquivo:** Mantenha apenas uma classe, struct, interface ou enum por arquivo. O nome do arquivo deve corresponder ao nome do tipo (ex: `Cliente.cs` contém a classe `Cliente`).
2.  **Espelhe a Estrutura de Pastas:** Sempre faça seus namespaces corresponderem à hierarquia de pastas do seu projeto.
3.  **Nomes Significativos:** Use nomes que descrevam claramente a funcionalidade contida no namespace (ex: `MeuApp.Data`, `MeuApp.UI`, `MeuApp.Utilities`).