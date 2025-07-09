# Comentários

Servem apenas para o desenvolvedor. Não são executados pelo compilador. São úteis para explicar o código e deixá-lo mais legível.

## Sintaxe

- Inline:

```c#
// Este é um comentário de uma linha.
```

- Multiline:

```c#
/* Este é um comentário de várias linhas */
```

O comentário de múltiplas linhas pode ser usado em blocos de comentários maiores, como no exemplo abaixo:

```c#
/*
Este é um comentário de várias linhas
que ocupa duas linhas.
*/
```

- Doc Comments:

```c#
/// <summary>
/// Este é um comentário de documentação.
/// </summary>
```

Doc comments são usados para gerar documentação automática do código. Eles começam com três barras (`///`) seguidas por uma tag `<summary>` que contém a descrição do método ou classe.

<note>

Veja mais em: [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/comments)

</note>

