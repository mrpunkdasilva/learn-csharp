# Casting

Em C#, "casting" (ou conversão explícita) é o processo de instruir o compilador a tratar uma variável de um tipo como se fosse de outro tipo. É uma operação fundamental, mas que deve ser compreendida para evitar perda de dados ou erros em tempo de execução.

O casting é diferente de usar classes utilitárias como `Convert` ou métodos como `Parse`. O casting é uma operação mais direta e de nível mais baixo, usada principalmente entre tipos numericamente compatíveis ou dentro de uma hierarquia de classes (herança).

## Conversão Implícita (Casting Implícito)

A conversão implícita, também conhecida como *widening conversion*, ocorre automaticamente quando um valor de um tipo "menor" é atribuído a uma variável de um tipo "maior", onde não há risco de perda de dados. É uma operação segura, e o compilador a realiza por você.

```c#
// Um int (32 bits) cabe facilmente em um long (64 bits).
int meuInt = 2147483647;
long meuLong = meuInt; // Conversão implícita, totalmente segura.

// Um int (inteiro) cabe facilmente em um double (ponto flutuante).
int numero = 10;
double meuDouble = numero; // Conversão implícita. O valor se torna 10.0.

Console.WriteLine(meuDouble); // Saída: 10
```

## Conversão Explícita (Casting Explícito)

A conversão explícita, também chamada de *narrowing conversion*, é necessária quando há risco de perda de dados. Você deve instruir o compilador explicitamente usando a sintaxe de cast `(novoTipo)`. Ao fazer isso, você está dizendo ao compilador: "Eu sei que isso pode falhar ou perder dados, mas eu assumo a responsabilidade."

```c#
double salario = 2599.95;

// Forçar a conversão de double para int. A parte decimal será perdida (truncada).
// Você DEVE usar o (int) para que o código compile.
int salarioInteiro = (int)salario;

Console.WriteLine(salarioInteiro); // Saída: 2599 (a informação .95 foi perdida)

// Outro exemplo de risco: converter um número grande para um tipo menor
long numeroGrande = 3000000000; // 3 bilhões

// int só pode armazenar até ~2.1 bilhões. Isso causará um Overflow.
// O resultado será um número inesperado e incorreto, sem lançar exceção em um contexto unchecked.
int intPequeno = (int)numeroGrande;

Console.WriteLine(intPequeno); // Saída: -1294967296 (lixo de memória)
```

<warning>
O casting explícito de tipos numéricos pode levar à **perda de dados** (truncamento) ou **estouro de capacidade** (overflow), resultando em valores incorretos. Use-o apenas quando tiver certeza de que o valor de origem caberá no tipo de destino.
</warning>

## Casting em Programação Orientada a Objetos

O casting é essencial ao trabalhar com herança de classes.

```c#
// Cenário de exemplo
public class Animal { }
public class Cachorro : Animal { public void Latir() { } }
public class Gato : Animal { public void Miar() { } }
```

### Upcasting (Implícito e Seguro)

Upcasting é converter uma referência de uma classe derivada (filha) para uma de sua classe base (mãe). Isso é sempre seguro e, portanto, implícito.

```c#
Cachorro meuCachorro = new Cachorro();

// Upcasting: tratando um Cachorro como um Animal genérico.
// Isso é útil para criar listas de diferentes tipos de animais.
Animal animalGenerico = meuCachorro; // Upcasting implícito.
```

### Downcasting (Explícito e Arriscado)

Downcasting é o oposto: tentar converter uma referência de classe base de volta para sua classe derivada original. Isso é arriscado porque o `Animal` genérico poderia ser um `Gato`, e não um `Cachorro`. Tentar um downcast inválido lança uma `InvalidCastException`.

```c#
// ...continuando de cima

// Tentativa de Downcasting
// O compilador exige o (Cachorro) porque a operação pode falhar.
Cachorro cachorroEspecifico = (Cachorro)animalGenerico; 
cachorroEspecifico.Latir(); // Funciona!

// Exemplo de falha
Animal outroAnimal = new Gato();
// A linha abaixo compila, mas lançará uma InvalidCastException em tempo de execução,
// porque um Gato não pode ser tratado como um Cachorro.
// Cachorro caoImpossivel = (Cachorro)outroAnimal; 
```

## Alternativas Seguras para Downcasting: `as` e `is`

Para evitar exceções, o C# fornece operadores mais seguros para downcasting.

-   **`is`**: Verifica se a conversão é possível, retornando `true` ou `false`.
-   **`as`**: Tenta a conversão. Se for bem-sucedida, retorna o objeto convertido. Se falhar, retorna `null` em vez de lançar uma exceção.

```c#
Animal animalMisterioso = new Gato();

// Usando 'is' para verificar antes de converter
if (animalMisterioso is Cachorro)
{
    Cachorro caoVerificado = (Cachorro)animalMisterioso; // Seguro, mas verboso
    caoVerificado.Latir();
}
else
{
    Console.WriteLine("O animal misterioso não é um cachorro.");
}

// Usando 'as' para uma conversão segura e concisa (a abordagem preferida)
Cachorro caoComAs = animalMisterioso as Cachorro;
if (caoComAs != null)
{
    caoComAs.Latir();
}
else
{
    Console.WriteLine("A conversão com 'as' falhou, o animal não é um cachorro.");
}
```

## Guia Rápido: Casting vs. `Convert` vs. `Parse`

| Operação | Quando Usar | Exemplo |
| :--- | :--- | :--- |
| **Casting** | Entre tipos numéricos ou em hierarquias de classes. | `int i = (int)10.5;` |
| **`Convert`** | Conversão segura entre muitos tipos base, especialmente com `nulls`. | `int i = Convert.ToInt32(null);` |
| **`Parse`** | **Apenas** para converter uma `string` para seu tipo correspondente. | `int i = int.Parse("10");` |
