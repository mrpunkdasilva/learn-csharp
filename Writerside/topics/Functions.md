# Funções 

As Funções são blocos de código que servem para executar tarefas específicas e reutilizáveis **que possuem retorno**

<note>

Podem chamar funções de metodos 

</note>

## Declaração

```c#
public static int Soma(int a, int b)
{
    return a + b;
}
```

Onde:
- `public` é o modificador de acesso da função.
- `static` indica que a função pode ser chamada sem instanciar um objeto.
- `int` é o tipo de dado retornado pela função (nesse caso inteiro).
- `Soma` é o nome da função.
- `(int a, int b)` são os parâmetros da função.
- `{}` são as chaves que delimitam o corpo da função.
- `a` e `b` são variáveis locais que recebem os valores passados como argumento na chamada da função.
- `return a + b;` é a instrução que retorna o resultado da soma dos dois números.

