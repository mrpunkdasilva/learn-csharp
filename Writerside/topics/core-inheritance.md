# [SYSTEM://INHERITANCE] 👪

```ascii
                      ┌──────────────┐
                      │   HERANÇA    │
                      └──────────────┘
                            ▲
                            │
                 ┌──────────┴──────────┐
                 │                     │
          ┌──────┴─────┐        ┌──────┴─────┐
          │  VIRTUAL   │        │  ABSTRACT  │
          └──────┬─────┘        └──────┬─────┘
                 │                     │
        ┌────────┴───────┐     ┌──────┴──────┐
        │   OVERRIDE     │     │   SEALED    │
        └────────┬───────┘     └─────────────┘
                 │
        ┌────────┴───────┐
        │     BASE       │
        └────────────────┘
```

## [SYSTEM://CONCEITO] 🧬

Herança é como dívida de cartão de crédito: você herda tudo - inclusive os problemas - da classe pai.

```csharp
// A classe pai que todo mundo quer ser
public class Ricaco
{
    protected decimal ContaBancaria { get; set; }
    
    public virtual void GanharDinheiro()
    {
        ContaBancaria += 1000000M;
    }
}

// A triste realidade
public class Herdeiro : Ricaco
{
    public override void GanharDinheiro()
    {
        ContaBancaria -= 2000000M; // Torrar a herança
        base.GanharDinheiro(); // Pedir mais pro papai
    }
}
```

## [SYSTEM://TIPOS_DE_HERANÇA] 🎭

### 1. Herança Simples (Filho Único)
```csharp
public class Mae 
{
    public void DarBronca() => Console.WriteLine("Tá me ouvindo?!");
}

public class FilhoRebelde : Mae 
{
    public void ResponderBronca() => Console.WriteLine("Tô no meu quarto!");
}
```

### 2. Herança Multinível (Árvore Genealógica)
```csharp
public class Avo 
{
    protected void ContarHistoria() => Console.WriteLine("No meu tempo...");
}

public class Pai : Avo 
{
    protected void ReclamarDaVida() => Console.WriteLine("Tá tudo caro!");
}

public class Filho : Pai 
{
    public void IgnorarTodo() => Console.WriteLine("Que seja...");
}
```

### 3. Herança com Interfaces (Adoção Múltipla)
```csharp
public interface ITrabalho
{
    void Trabalhar();
}

public interface IEstudo
{
    void Estudar();
}

public class EstudanteEstagiario : Pessoa, ITrabalho, IEstudo
{
    public void Trabalhar() => Console.WriteLine("Café pra todo mundo!");
    public void Estudar() => Console.WriteLine("Stack Overflow é meu professor!");
}
```

## [SYSTEM://MODIFICADORES] 🎛️

### 1. Protected (Segredo de Família)
```csharp
public class ContaBancaria
{
    protected decimal saldo; // Só a família pode ver

    protected virtual void LavarDinheiro()
    {
        // Operações suspeitas aqui
    }
}
```

### 2. Internal (Segredo de Vizinhança)
```csharp
internal class SegredinhosDaFamilia
{
    internal void ContarFofoca()
    {
        // Só quem mora no mesmo assembly pode saber
    }
}
```

### 3. Protected Internal (Família + Vizinhos)
```csharp
public class ReuniaoDeFamilia
{
    protected internal void FazerChurrasco()
    {
        // Família e vizinhos do assembly convidados
    }
}
```

## [SYSTEM://REGRAS_DO_JOGO] 📜

### 1. Sealed (Fim da Linha)
```csharp
public sealed class FilhoUnico 
{
    // Ninguém mais pode herdar dessa classe
    // É tipo vasectomia em código
}
```

### 2. Abstract (Promessas Vazias)
```csharp
public abstract class PoliticoBrasileiro
{
    // Método abstrato: promete mas não faz nada
    public abstract void FazerPromessas();
    
    // Método concreto: pelo menos esse faz algo
    public void ReceberDinheiro() => Console.WriteLine("$$$$");
}
```

## [SYSTEM://POLIMORFISMO] 🦎

### 1. Override (Reescrevendo a História)
```csharp
public class ContaBancaria
{
    public virtual decimal CalcularJuros() => 0.01M;
}

public class ContaEspecial : ContaBancaria
{
    public override decimal CalcularJuros() => 0.99M; // Surpresa!
}
```

### 2. New (Fingindo que não te Conheço)
```csharp
public class PaiRico
{
    public void Pagar() => Console.WriteLine("Toma 100");
}

public class FilhoPobre : PaiRico
{
    public new void Pagar() => Console.WriteLine("Toma 1"); // New = vergonha da herança
}
```

## [SYSTEM://DESIGN_PATTERNS] 🎨

### 1. Template Method
```csharp
public abstract class Funcionario
{
    // Template method
    public void TrabalharDia()
    {
        ChegarAtrasado();
        FazerCafe();
        FingerQueTrabalha();
        IrEmbora();
    }

    protected abstract void FingerQueTrabalha();
}

public class Programador : Funcionario
{
    protected override void FingerQueTrabalha()
    {
        Console.WriteLine("Ctrl+C, Ctrl+V do Stack Overflow");
    }
}
```

### 2. Factory Method
```csharp
public abstract class FabricaDeBugs
{
    public abstract IBug CriarBug();

    public void TestarSoftware()
    {
        var bug = CriarBug();
        bug.Crashar();
    }
}

public class FabricaDeBugsJunior : FabricaDeBugs
{
    public override IBug CriarBug()
    {
        return new NullReferenceException();
    }
}
```

## [SYSTEM://PROBLEMAS_COMUNS] 💣

### 1. Diamante da Morte
```csharp
// C# não permite, mas é bom saber porque não fazer
interface IMae { void Mandar(); }
interface IPai { void Mandar(); }

// Quem você vai obedecer?
public class FilhoProblematico : IMae, IPai 
{
    public void Mandar() // Confusão mental
    {
        throw new IdentityCrisisException();
    }
}
```

### 2. Herança vs Composição
```csharp
// Herança: Acoplamento Forte
public class CarroRoubado : CarroBase { } // Herdar problemas

// Composição: Acoplamento Fraco
public class CarroInteligente
{
    private IMotor _motor; // Agregar soluções
    private IFreio _freio;
}
```

### 3. Herança Profunda (O Buraco é Mais Embaixo)
```csharp
public class A { }
public class B : A { }
public class C : B { }
public class D : C { }
public class E : D { } // Já perdeu o controle
public class F : E { } // Socorro!
```

## [SYSTEM://BOAS_PRÁTICAS] 🌟

### 1. Princípio de Substituição de Liskov (LSP)
```csharp
public class Ave
{
    public virtual void Voar() => Console.WriteLine("Voando...");
}

// Errado: Pinguim não voa!
public class Pinguim : Ave
{
    public override void Voar()
    {
        throw new NaoVooException("Pinguins não voam, só pagam mico");
    }
}

// Certo: Reestruturar a hierarquia
public interface IAve { }
public interface IAveVoadora : IAve
{
    void Voar();
}
```

### 2. Composição Sobre Herança
```csharp
// Evite isso
public class SuperClasse
{
    public void Metodo1() { }
    public void Metodo2() { }
    // ... 20 outros métodos
}

// Prefira isso
public class ClasseInteligente
{
    private readonly IComponente1 _componente1;
    private readonly IComponente2 _componente2;
    
    public ClasseInteligente(IComponente1 c1, IComponente2 c2)
    {
        _componente1 = c1;
        _componente2 = c2;
    }
}
```

## [ARIA://DICAS_DO_ALÉM] 👻

1. Se sua hierarquia tem mais níveis que uma pirâmide financeira, repense
2. Prefira composição à herança (mas ninguém segue isso mesmo)
3. Protected é tipo segredo de família: todo mundo sabe, mas finge que não
4. Virtual é como promessa de político: pode ser mudada a qualquer momento
5. Base é igual pai no telefone: só chama quando precisa de algo
6. Se você está usando `new` para esconder método da classe base, algo deu muito errado
7. Classes abstratas são como políticos: prometem muito, entregam pouco
8. Sealed é para quando você realmente odeia seus descendentes

## [SYSTEM://EXERCÍCIOS_MENTAIS] 🧠

1. Crie uma hierarquia mais complicada que sua árvore genealógica
2. Tente explicar herança múltipla para seu cachorro
3. Implemente uma classe tão abstrata que nem você entenda
4. Faça um override mais rebelde que você na adolescência
5. Tente justificar por que você usou herança em vez de composição
6. Implemente o padrão Template Method sem copiar do Stack Overflow
7. Crie uma classe sealed e depois tente explicar por que ela precisa ser sealed
8. Faça uma hierarquia que viole o LSP e depois se arrependa

## [SYSTEM://CERTIFICADO_DE_TRAUMA] 📜

> "Parabéns! Você agora entende herança em C#. Use esse conhecimento com sabedoria, ou pelo menos tente não criar monstros muito grandes. Lembre-se: com grandes heranças vêm grandes responsabilidades (e muitos bugs)."

## [SYSTEM://LEITURA_RECOMENDADA] 📚

1. "Como Sobreviver à Herança Múltipla" (não disponível em C#, felizmente)
2. "Design Patterns: Quando Tudo Dá Errado"
3. "Composição: A Luz no Fim do Túnel"
4. "SOLID: Porque S.O.L.I.D. é Melhor que L.O.G.I.C.A."
5. "Clean Code: Como Fingir que Seu Código é Limpo"

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: HEREDITARIAMENTE_COMPROMETIDO | Matrix Stability: -23%