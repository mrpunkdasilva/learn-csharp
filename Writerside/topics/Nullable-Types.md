# Nullable Types

O tipo `null` significa "nulo" ou "vazio". Em C#, o valor padrão de um tipo é sempre definido como nulo. Por exemplo, se você declarar uma variável do tipo inteiro e não atribuir nenhum valor a ela, seu valor será zero.

<note>

Null é diferente de 0 (zero) e uma string vazia ("")". Null indica que a variável não tem nenhum valor válido enquanto 0 é um valor numérico válido.

E todo tipo primitivo ou complexo pode  receber nulo
</note>

Podemos marcar como Nullable Type, podemos fazer isso com: 

<note>
A sintaxe para criar um tipo Nullable é colocando um ponto de interrogação após o nome do tipo.
</note>

```c#
int? x = null;
```

