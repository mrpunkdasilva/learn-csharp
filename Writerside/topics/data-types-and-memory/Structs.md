# Structs

Tipos de dados estruturado, servem apenas para definir a estrutura 

Sendo tipo de valor

Armazenam apenas outros tipos de dados, e é definido pela palavra:

```c#
struct NomeDaEstrutura{
    //Aqui vai as propriedades da estrutura
}
```

Composto por metodos e propriedades

Nome sempre com letras maiuscula
- Igual para propriedades e métodos

Criado apartir da palavra `new`
- Neste momento que temos os valores iniciais das propriedades

Exemplo:

```c#
struct Pessoa{
    public string nome;
}
Pessoa pessoa = new Pessoa();
pessoa.nome = "João";
Console.WriteLine(pessoa.nome);
```
Também podemos criar um construtor padrão para inicializar o objeto:

```c#
struct Pessoa{
    public string nome;
    public int idade;
    public Pessoa(string nome){
        this.nome = nome;
    }
}
Pessoa pessoa = new Pessoa("João");
Console.WriteLine(pessoa.nome);
```

E assim criamos metodos dentro do struct:

```c#
struct Pessoa{
    public string nome;
    public int idade;
    public void MostrarDados(){
        Console.WriteLine($"Nome: {nome} Idade: {idade}");
    }
}
Pessoa pessoa = new Pessoa("João", 20);
pessoa.MostrarDados();
```

Podemos também usar o método `ToString()` para retornar uma string com os dados do objeto:

```c#
struct Pessoa{
    public string nome;
    public int idade;
    public override string ToString(){
        return $"Nome: {nome} Idade: {idade}";
    }
}
Pessoa pessoa = new Pessoa("João", 20);
Console.WriteLine(pessoa.ToString());
```