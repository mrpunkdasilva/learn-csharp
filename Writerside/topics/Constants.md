# Constantes

São valores imutaveis, ou seja, não podem ser alteradas durante a execução do programa. Assim que criamos somos obrigados a atribuir valor a ela.

```c#
const int IDADE = 20;
```

<note>
Por convenção o nome de uma constante é escrito em maiúsculo
</note>

E caso não iniarmos com um valor ela sera inicializada com um valor padrão do tipo:

```c#
const int IDADE; // será inicializado como zero (0)
const string NOME; // será inicializado como null
const bool ATIVO; // será inicializado como false
const double SALARIO; // será inicializado como zero (0)
const decimal PRECO; // será inicializado como zero (0)
const float ALTURA; // será inicializado como zero (0)
const char SEXO; // será inicializado como '\0'
```