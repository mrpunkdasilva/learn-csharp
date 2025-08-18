# Laço de Repetição while

O laço `while` em C# é uma estrutura de controle que executa um bloco de código repetidamente **enquanto** uma determinada condição booleana for `true`. Diferente do laço `for`, o `while` é ideal para situações em que o número de iterações não é conhecido de antemão.

A principal característica do `while` é que a condição é testada **antes** da execução do bloco de código. Se a condição for `false` na primeira verificação, o corpo do laço nunca será executado.

## Sintaxe

A sintaxe do laço `while` é simples e direta:

```c#
while (condição)
{
    // Bloco de código a ser executado
}
```

*   **`condição`**: Uma expressão booleana (`true` ou `false`). O laço continua enquanto esta expressão for `true`.

### Exemplo Prático

Vamos supor que queremos ler a entrada do usuário até que ele digite a palavra "sair".

```c#
string entrada = "";
while (entrada.ToLower() != "sair")
{
    Console.Write("Digite algo (ou 'sair' para terminar): ");
    entrada = Console.ReadLine();
    Console.WriteLine($"Você digitou: {entrada}");
}

Console.WriteLine("Programa encerrado.");
```

**Análise do Exemplo:**

1.  A variável `entrada` é inicializada como uma string vazia.
2.  A condição `entrada.ToLower() != "sair"` é verificada. Na primeira vez, `"" != "sair"` é `true`, então o laço começa.
3.  Dentro do laço, o programa solicita a entrada do usuário e a armazena na variável `entrada`.
4.  O laço se repete, e a condição é verificada novamente com o novo valor de `entrada`.
5.  Quando o usuário finalmente digita "sair", a condição se torna `false`, e o laço é encerrado.

## Cuidado com Laços Infinitos

Um erro comum ao usar o `while` é criar um laço infinito. Isso acontece se a condição de parada nunca for alcançada. É crucial garantir que alguma variável dentro da condição seja modificada no corpo do laço para que, em algum momento, a condição se torne `false`.

**Exemplo de laço infinito (EVITAR):**

```c#
int i = 0;
while (i < 10)
{
    // Erro: a variável 'i' nunca é incrementada.
    // Este laço executará para sempre.
    Console.WriteLine("Isso é um laço infinito!");
}
```

Para corrigir, basta adicionar o iterador:

```c#
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++; // Correção: garante que o laço terminará
}
```

O laço `while` é fundamental para algoritmos onde a repetição depende de um estado que muda durante a execução, como processamento de dados, interação com o usuário ou espera por um evento.
