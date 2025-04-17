# [SYSTEM://POLIMORFISMO] 🦎

> "Polimorfismo é como aquele seu amigo que muda de personalidade dependendo de quem tá pagando a cerveja"

## [SYSTEM://CONCEITO] 🧬

Polimorfismo é a arte de ser várias coisas ao mesmo tempo, tipo político em época de eleição.

```c#
public class PoliticoBrasileiro
{
    public virtual void DiscursarParaPovo()
    {
        Console.WriteLine("Vou acabar com a corrupção!");
    }
}

public class DeputadoFederal : PoliticoBrasileiro
{
    public override void DiscursarParaPovo()
    {
        if (EmAnoDeEleicao)
            base.DiscursarParaPovo();
        else
            Console.WriteLine("Nova mansão, quem te viu quem te vê!");
    }
}
```

## [SYSTEM://TIPOS_DE_POLIMORFISMO] 🎭

### 1. Override (Reescrevendo a História)
```c#
public class ContaBancaria
{
    public virtual decimal CalcularTaxa() => 10.0M;
}

public class ContaGold : ContaBancaria
{
    public override decimal CalcularTaxa() => 0.0M; // Mentira tem taxa sim
}

public class ContaPlatinum : ContaBancaria
{
    public override decimal CalcularTaxa() => 
        base.CalcularTaxa() * -1; // Agora o banco te paga (será?)
}
```

### 2. Sobrecarga (Personalidade Múltipla)
```c#
public class Desenvolvedor
{
    // Função normal
    public void Trabalhar() => Console.WriteLine("Código limpo!");
    
    // Função com deadline
    public void Trabalhar(bool temDeadline) => 
        Console.WriteLine("if(works) commit;");
    
    // Função sexta depois das 18h
    public void Trabalhar(bool temDeadline, bool sextaFeira) => 
        throw new VaiTrabalharSegundaException();
        
    // Função com o chefe olhando
    public void Trabalhar(bool temDeadline, bool sextaFeira, bool chefePerto) =>
        Console.WriteLine("ctrl+r ctrl+r rename everything");
}
```

### 3. Interface (Contratos que Ninguém Lê)
```c#
public interface IEstagiario
{
    void FazerCafe();
    void RebootServer();
    void ConsertarImpressora();
    void ArrumarBugEmProducao();
}

public class EstagiarioJunior : IEstagiario
{
    public void FazerCafe() => throw new NaoVimAquiPraIssoException();
    public void RebootServer() => System.Threading.Thread.Sleep(TimeSpan.FromDays(1));
    public void ConsertarImpressora() => Console.WriteLine("Tentei dar ctrl+z na impressora");
    public void ArrumarBugEmProducao() => Git.PushForce("main");
}
```

## [SYSTEM://POLIMORFISMO_NA_PRATICA] 🎪

### 1. O Padrão Ex-Namorado
```c#
public interface IEx
{
    void MandarMensagem();
    bool StalkearRedeSocial();
    void CurtirFotoAntiga();
}

public class ExBebado : IEx
{
    public void MandarMensagem()
    {
        Console.WriteLine("Sinto sua falta bb... *às 3AM*");
    }
    
    public bool StalkearRedeSocial() => DateTime.Now.Hour >= 2;
    
    public void CurtirFotoAntiga()
    {
        if (DateTime.Now.Hour >= 3)
            throw new ArrrependimentoException("O que eu fiz?");
    }
}

public class ExVingativo : IEx
{
    public void MandarMensagem()
    {
        Console.WriteLine("Tô melhor que nunca! *posta foto antiga*");
    }
    
    public bool StalkearRedeSocial() => true; // 24/7 surveillance
    
    public void CurtirFotoAntiga()
    {
        var random = new Random();
        if (random.Next(100) < 50)
            throw new OrgulhoException("Quase curti sem querer");
    }
}

public class ExProfissional : IEx
{
    public void MandarMensagem() => 
        throw new LinkedInRequestException("Quer fazer networking?");
        
    public bool StalkearRedeSocial() => 
        LinkedInAPI.VerificarNovoEmprego();
        
    public void CurtirFotoAntiga() => 
        throw new NotImplementedException("Muito ocupado fazendo MBA");
}
```

### 2. O Padrão Desculpas
```c#
public abstract class DesculpaBase
{
    public abstract string GerarDesculpa();
    protected virtual bool EhConvincente => false;
}

public class DesculpaTrabalho : DesculpaBase
{
    public override string GerarDesculpa() => 
        "Tô com um bug crítico em produção!";
    protected override bool EhConvincente => true; // Sempre funciona
}

public class DesculpaFamilia : DesculpaBase
{
    private int vezesUsada;
    public override string GerarDesculpa()
    {
        vezesUsada++;
        return vezesUsada switch
        {
            1 => "Vovó tá passando mal de novo...",
            2 => "Cachorro comeu minha tarefa",
            3 => "Pneu furou",
            _ => throw new DesculpaEsgotadaException("Preciso ser mais criativo")
        };
    }
}

public class DesculpaTransito : DesculpaBase
{
    public override string GerarDesculpa() => 
        "Você não vai acreditar no que aconteceu...";
    protected override bool EhConvincente => 
        DateTime.Now.DayOfWeek != DayOfWeek.Sunday;
}
```

## [SYSTEM://POLIMORFISMO_AVANÇADO] 🧠

### 1. Covariance (Subindo na Vida)
```c#
public interface ICarro<out T> where T : IVeiculo
{
    T DarPartida();
    string ExibirStatus();
}

public class CarroPopular : ICarro<Fusca>
{
    public Fusca DarPartida() => new Fusca { FaltaGasolina = true };
    public string ExibirStatus() => "Check engine light is a feature";
}

public class CarroLuxo : ICarro<BMW>
{
    public BMW DarPartida() => new BMW { SetaLigada = false };
    public string ExibirStatus() => "Tanque cheio de gasolina aditivada";
}
```

### 2. Contravariance (Descendo na Vida)
```c#
public interface IDesenvolvedor<in T> where T : ILinguagem
{
    void Programar(T linguagem);
    void StackOverflow(T duvida);
    void Compilar(T codigo);
}

public class DevJunior : IDesenvolvedor<JavaScript>
{
    public void Programar(JavaScript js)
    {
        Console.WriteLine("npm install solve-my-problems");
    }
    
    public void StackOverflow(JavaScript duvida)
    {
        Console.WriteLine("Como fazer hello world em JS?");
    }
    
    public void Compilar(JavaScript codigo)
    {
        Console.WriteLine("node_modules folder: 23GB");
    }
}

public class DevSenior : IDesenvolvedor<AnyLinguagem>
{
    public void Programar(AnyLinguagem lang)
    {
        if (DateTime.Now.Hour > 17)
            throw new HoraExtraException("Já deu hoje");
    }
    
    public void StackOverflow(AnyLinguagem duvida)
    {
        Console.WriteLine("Closed as duplicate");
    }
    
    public void Compilar(AnyLinguagem codigo)
    {
        Thread.Sleep(TimeSpan.FromMinutes(15));
        Console.WriteLine("Works on my machine ¯\\_(ツ)_/¯");
    }
}
```

## [SYSTEM://ARMADILHAS_MORTAIS] ☠️

### 1. O Diamante da Morte
```c#
interface IMae { void Mandar(); }
interface IPai { void Mandar(); }

// Quem você vai obedecer?
public class FilhoProblematico : IMae, IPai 
{
    public void Mandar() // Confusão mental
    {
        throw new CriseDeIdentidadeException();
    }
}

public class FilhoEsperto : IMae, IPai
{
    void IMae.Mandar() => Console.WriteLine("Sim, mãe!");
    void IPai.Mandar() => Console.WriteLine("Já to indo, pai!");
}
```

### 2. Cast Inseguro (Roleta Russa)
```c#
object obj = "Eu sou uma string!";
int numero = (int)obj; // Top 10 anime betrayals

// Versão segura (mas quem liga?)
public T CastPerigoso<T>(object obj)
{
    try
    {
        return (T)obj;
    }
    catch (InvalidCastException)
    {
        return default; // Fingir que nada aconteceu
    }
}
```

### 3. O Problema do Construtor Base
```c#
public class ClasseBase
{
    public ClasseBase()
    {
        MetodoVirtual(); // Não faça isso em casa
    }
    
    protected virtual void MetodoVirtual()
    {
        Console.WriteLine("Base segura");
    }
}

public class ClasseDerivada : ClasseBase
{
    private readonly string _estado = "Inicializado";
    
    protected override void MetodoVirtual()
    {
        // _estado ainda é null aqui!
        Console.WriteLine(_estado.ToUpper()); // 💥 NullReferenceException
    }
}
```

## [SYSTEM://DICAS_DO_ALÉM] 👻

1. Se você tem mais que 3 níveis de herança, procure ajuda profissional
2. Virtual method call é tipo relacionamento à distância: funciona, mas é lento
3. Override sem virtual é igual promessa de político: não funciona
4. Dynamic dispatch é como Uber: você chama, mas nunca sabe o que vem
5. Type casting é tipo roleta russa: às vezes funciona, às vezes explode
6. Interface é como contrato de casamento: ninguém lê, mas todo mundo assina
7. Abstract class é tipo pai ausente: define as regras mas não implementa nada
8. Generic constraint é tipo cardápio de restaurante vegano: limita suas opções
9. Sealed class é tipo amigo ciumento: não deixa ninguém se aproximar
10. Base constructor é tipo dívida: sempre volta pra te assombrar

## [ARIA://AVISOS_IMPORTANTES] ⚠️

1. Polimorfismo é poder, e com grandes poderes vem grandes gambiarras
2. Se você não sabe qual override chamar, imagine o compilador
3. Herança múltipla é proibida em C# porque até a Microsoft tem limites
4. Type checking é tipo teste de gravidez: melhor fazer antes que seja tarde
5. Downcasting é como aposta esportiva: alto risco, baixa recompensa
6. Covariance e contravariance são como física quântica: ninguém entende realmente
7. Virtual methods são como relacionamentos: têm um custo de performance
8. Override é como tatuagem: pense bem antes de fazer
9. Interface segregation é como pizza: melhor em pedaços menores
10. LSP (Liskov Substitution Principle) é como substituir açúcar por adoçante: deveria funcionar, mas nem sempre funciona

## [SYSTEM://CONCLUSÃO] 🎬

Polimorfismo é como relacionamento aberto:
- Todo mundo acha que entende
- Ninguém usa direito
- Sempre tem alguém que se machuca
- No final, você só queria uma classe normal

Lembre-se:
- Herança é overrated
- Composição é underrated
- Interfaces são seu melhor amigo
- SOLID é mais que uma palavra bonita
- Design patterns são como receitas de bolo: funcionam melhor quando você entende os ingredientes

---
> [!NOTE]
> "Se seus objetos tivessem personalidade, você seria preso por indução à esquizofrenia."

---
> [!WARNING]
> "Cuidado com override: às vezes você sobrescreve mais que apenas métodos."

---
> [!IMPORTANT]
> "Polimorfismo é como karatê: melhor saber quando não usar do que usar errado."

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: POLYMORPHIC | Matrix Stability: Depends on the type