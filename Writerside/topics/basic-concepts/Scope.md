# Escopo

Em C#, "escopo" refere-se à região do código onde uma variável ou um membro de uma classe pode ser acessado. Entender o escopo é fundamental para escrever um código organizado e livre de erros, pois ele determina o ciclo de vida e a visibilidade das suas variáveis.

O escopo em C# é geralmente definido por blocos de código, que são delimitados por chaves `{}`.

## Níveis de Escopo

### 1. Escopo de Classe (Campos ou *Fields*)

Variáveis declaradas diretamente dentro de uma classe, mas fora de qualquer método, são chamadas de **campos** (*fields*) ou variáveis de membro. Elas estão disponíveis para **todos os métodos** (e outros membros) dentro daquela classe.

-   Seu ciclo de vida é o mesmo do objeto da classe.
-   Podem ser acessadas usando a palavra-chave `this`.

```c#
public class Personagem
{
    // 'nome' e 'pontosDeVida' são campos com escopo de classe.
    private string nome;
    private int pontosDeVida = 100;

    public Personagem(string nomeInicial)
    {
        this.nome = nomeInicial; // Acessando o campo 'nome'
    }

    public void ReceberDano(int dano)
    {
        // Acessando e modificando o campo 'pontosDeVida'
        this.pontosDeVida -= dano;
        Console.WriteLine($"{this.nome} recebeu {dano} de dano e agora tem {this.pontosDeVida} HP.");
    }
}
```

### 2. Escopo de Método (Variáveis Locais)

Variáveis declaradas dentro de um método são chamadas de **variáveis locais**. Elas só podem ser acessadas **dentro do método** onde foram declaradas.

-   Elas são criadas quando o método é chamado e destruídas quando o método termina.
-   Não podem ser acessadas por outros métodos.

```c#
public class Calculadora
{
    public int Somar(int a, int b)
    {
        // 'resultado' é uma variável local com escopo de método.
        int resultado = a + b;
        return resultado;
    }

    public void OutroMetodo()
    {
        // A linha abaixo causaria um erro de compilação, pois 'resultado'
        // não existe neste escopo.
        // Console.WriteLine(resultado); 
    }
}
```

### 3. Escopo de Bloco

Variáveis declaradas dentro de um bloco de código (como um `if`, `for`, `while` ou mesmo um bloco `{}` avulso) só existem dentro daquele bloco.

-   Este é o nível de escopo mais restrito.

```c#
public void TestarEscopoDeBloco()
{
    int a = 10;

    if (a > 5)
    {
        // 'b' só existe dentro deste bloco 'if'.
        int b = 20;
        Console.WriteLine(a + b); // Válido: 'a' e 'b' estão em escopo.
    }

    // A linha abaixo causaria um erro de compilação, pois 'b' está fora de escopo.
    // Console.WriteLine(b);
}
```

## Sombreamento de Variáveis (*Variable Shadowing*)

O C# **impede** que você declare uma variável local com o mesmo nome de outra variável local que já esteja em um escopo externo (pai). Isso evita bugs e confusão.

```c#
int x = 10; // Escopo do método

if (x > 5)
{
    int y = 20; // Escopo do bloco
    // int x = 30; // Erro de compilação! Não se pode declarar 'x' aqui porque já existe no escopo pai.
}
```

No entanto, uma variável local **pode** ter o mesmo nome de um campo da classe. Nesse caso, a variável local "sombra" (ou esconde) o campo. Para acessar o campo da classe, você **deve** usar a palavra-chave `this`.

```c#
public class Exemplo
{
    private string nome = "Classe"; // Campo da classe

    public void MeuMetodo(string nome) // Parâmetro do método
    {
        // 'nome' aqui se refere ao parâmetro do método ("Método").
        Console.WriteLine($"Variável local: {nome}");

        // Para acessar o campo da classe, usamos 'this.nome'.
        Console.WriteLine($"Campo da classe: {this.nome}");
    }
}

// Uso:
Exemplo ex = new Exemplo();
ex.MeuMetodo("Método");
// Saída:
// Variável local: Método
// Campo da classe: Classe
```
