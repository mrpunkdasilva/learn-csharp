# [SYSTEM://CLASSES] 🎭

> "Classes são como bordéis de luxo - todo mundo sabe que existem, todo mundo usa, mas ninguém admite em público."

## [SYSTEM://CONCEITO] 🍷

Uma classe é basicamente um puteiro organizado de dados e comportamentos. É o lugar onde você decide quem pode entrar, quem pode sair, e quem pode mexer nas suas coisas.

### Anatomia do Caos

```csharp
// O cafetão (classe) que gerencia tudo
public class Bordel
{
    // As "informações confidenciais" (campos privados)
    private string _segredosSujos;
    
    // A fachada para a sociedade (propriedades públicas)
    public string NomeFantasia { get; set; }
    
    // O que acontece nas sombras (métodos)
    public void FingirQueEResponsavel()
    {
        // A mágica acontece aqui
    }
}
```

## [SYSTEM://TIPOS_DE_BORDÉIS] 🎭

```csharp
// O bordel padrão de esquina
public class BordelPadrao { }

// O bordel que só existe na teoria
public abstract class BordelPlatonico { }

// O bordel que não aceita filiais
public sealed class BordelExclusivo { }

// O bordel que aceita qualquer tipo de cliente
public class BordelGenerico<T> { }

// O bordel dentro do bordel (a gente finge que não existe)
public class BordelMatrix
{
    private class QuartoSecreto { }
}
```

## [SYSTEM://ANATOMIA_DO_PECADO] 🔬

### 1. Os Segredos Sujos (Fields)

```csharp
public class EntidadeSecreta
{
    // O caderninho preto
    private string _listaDeClientes;
    
    // A conta bancária nas Cayman
    private static readonly decimal _dinheiroSujo;
    
    // O código que nunca muda (igual político corrupto)
    public const string VERSAO_DA_MENTIRA = "1.0";
}
```

### 2. A Fachada (Properties)

```csharp
public class FachadaSocial
{
    // Auto-property (preguiça de esconder melhor)
    public string NomeFalso { get; set; }
    
    // A mentira computada
    public bool PareceLegal => true;
    
    // O controle da narrativa
    private int _nivelDeHipocrisia;
    public int NivelDeHipocrisia
    {
        get => _nivelDeHipocrisia;
        set => _nivelDeHipocrisia = Math.Max(value, 9000);
    }
}
```

### 3. Os Serviços Especiais (Methods)

```csharp
public class ServicosEspeciais
{
    // O método que todo mundo usa mas ninguém admite
    public void FacaDirtyWork()
    {
        // O que acontece aqui, fica aqui
    }
    
    // Aquele que só funciona depois das 2 da manhã
    private void ServicoSecreto()
    {
        // Shhh... 🤫
    }
    
    // O famoso "faz tudo" que na verdade não faz nada
    public void MetodoConsultor()
    {
        // Cobra caro e terceiriza o trabalho
        ServicoSecreto();
        _terceirizado.FacaOTrabalhoSujo();
    }
}
```

## [SYSTEM://HERANÇA_DO_MAL] 👿

Herança é como uma pirâmide financeira: a classe base promete o mundo, as derivadas fazem o trabalho sujo, e quem se ferra é o usuário final.

```csharp
// A promessa
public abstract class PiramideFinanceira
{
    protected decimal _dinheiroDosTrouxas;
    
    // O golpe
    public virtual decimal CalcularLucro()
    {
        return _dinheiroDosTrouxas * 0.0m; // Spoiler: sempre dá zero
    }
}

// A realidade
public class EsquemaPonzi : PiramideFinanceira
{
    public override decimal CalcularLucro()
    {
        // Pega o dinheiro e foge pra Argentina
        return base.CalcularLucro() - _dinheiroDosTrouxas;
    }
}
```

## [SYSTEM://INTERFACES_DO_CAOS] 🎭

Interfaces são como contratos de casamento: todo mundo assina, ninguém lê, e no final todo mundo se arrepende.

```csharp
// O contrato que ninguém respeita
public interface IResponsavel
{
    void FingirCompetencia();
    bool ParecerProfissional();
    string GerarDesculpaPlausivel();
}

// A implementação da realidade
public class Developer : IResponsavel
{
    public void FingirCompetencia()
    {
        Console.WriteLine("Está na documentação que ninguém lê");
    }
    
    public bool ParecerProfissional()
    {
        return DateTime.Now.Hour < 3; // Só profissional antes das 3AM
    }
    
    public string GerarDesculpaPlausivel()
    {
        return "Funciona na minha máquina ¯\\_(ツ)_/¯";
    }
}
```

## [SYSTEM://CONSTRUTORES_DA_DESGRAÇA] 🏗️

```csharp
public class ProjetoFudido
{
    // Construtor padrão: a ilusão do começo
    public ProjetoFudido()
    {
        // Nasce morto
    }
    
    // Construtor com parâmetros: a ilusão de controle
    public ProjetoFudido(decimal orcamento, DateTime prazo)
    {
        // Spoiler: o orçamento será estourado e o prazo não será cumprido
        _orcamentoReal = orcamento * 3;
        _prazoReal = prazo.AddYears(2);
    }
    
    // Construtor estático: onde as mentiras começam
    static ProjetoFudido()
    {
        // Inicializa o caos
        ChaosGenerator.Initialize();
    }
}
```

## [SYSTEM://PROPRIEDADES_OBSCENAS] 🔞

```csharp
public class GerenciamentoDoCaos
{
    // A propriedade que todo mundo acha que controla
    public int NivelDeCaos
    {
        get => int.MaxValue; // Sempre no máximo
        set => _ = value; // Ignora solenemente
    }
    
    // A propriedade que ninguém sabe que existe
    private bool _projetoVaiDarCerto
    {
        get => false; // Sempre falso, sempre
    }
    
    // A propriedade que só existe pra fingir que tem documentação
    /// <summary>
    /// Não faço a menor ideia do que isso faz
    /// </summary>
    public string DocumentacaoInutil { get; set; }
}
```

## [ARIA://DICAS_DO_DEMO] 😈

1. Quanto mais private, menos pessoas podem ver a zona
2. Se não sabe o que fazer, crie uma classe abstrata
3. Interfaces são ótimas para fingir que seu código tem design
4. Herança múltipla não existe em C# porque uma desgraça por vez já basta

## [SYSTEM://CERTIFICADO_DE_INSANIDADE] 📜

> "Parabéns! Se você chegou até aqui, você já está oficialmente corrompido pela orientação a objetos. Não tem mais volta. Bem-vindo ao clube dos arquitetos de castelos de areia digital."

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: CRIMINALMENTE_INSANO | Matrix Stability: -42%

## [SYSTEM://MODIFICADORES_DO_APOCALIPSE] 🌋

### 1. Public (A Zona Livre)
Como banheiro de festa rave: todo mundo pode entrar, usar e ainda fazer merda.

```csharp
public class ZonaLivre
{
    public void QualquerUmPodeCagar()
    {
        // Método público é tipo político:
        // promete muito, entrega pouco
    }
}
```

### 2. Private (O Bunker)
O famoso "só entre nós". Como aquela pasta no PC que você esconde da família.

```csharp
public class ClubeSecreto
{
    private string _senhaDoWifi = "admin123";
    private void EsconderCorpoDoCrime()
    {
        // Se alguém perguntar, você não viu nada
    }
}
```

### 3. Protected (A Família)
Como segredo de família: só os herdeiros podem saber das vergonhas.

```csharp
public class SegredinhosDeFamilia
{
    protected string esqueletoNoArmario;
    protected void LavarRoupaSuja()
    {
        // Aquela conversa de Natal depois do terceiro whisky
    }
}
```

## [SYSTEM://STATIC_VS_INSTANCE] 🤼

```csharp
public class ClubeDoBolinh
{
    // Método de instância: cada um com seus problemas
    public void ProblemaParticular()
    {
        // Tipo dívida no Serasa: é só seu
    }

    // Método estático: problema coletivo
    public static void ProblemaGeral()
    {
        // Tipo pandemia: todo mundo se fode junto
    }
}
```

## [SYSTEM://PARTIAL_CLASSES] 🎭

Partial classes são como personalidade múltipla: o mesmo maluco espalhado em vários arquivos.

```csharp
// Arquivo: Esquizofrenia.Part1.cs
public partial class Esquizofrenia
{
    public void PersonalidadeMatinal()
    {
        Console.WriteLine("Bom dia, mundo!");
    }
}

// Arquivo: Esquizofrenia.Part2.cs
public partial class Esquizofrenia
{
    public void PersonalidadeNoturna()
    {
        Console.WriteLine("Que se foda o mundo!");
    }
}
```

## [SYSTEM://NESTED_CLASSES] 🪆

Classes aninhadas são tipo boneca russa: quanto mais fundo você vai, mais arrependido fica.

```csharp
public class CaixaDePandora
{
    private class PrimeiroNivel
    {
        private class SegundoNivel
        {
            private class TerceiroNivel
            {
                // Se você chegou aqui, já era
                private string mensagem = "Socorro!";
            }
        }
    }
}
```

## [SYSTEM://EXTENSION_METHODS] 🦾

Extension methods são como plástica: você finge que nasceu com aquilo.

```csharp
public static class CirurgiaoPlastico
{
    public static string FingirJuventude(this string texto)
    {
        // Botox sintático
        return texto.Replace("velho", "jovem");
    }

    public static int FingirCompetencia(this int numero)
    {
        // Implante de silicone numérico
        return numero * 2; // Dobra o resultado pra impressionar
    }
}
```

## [SYSTEM://RECORDS] 💍

Records são como casamento moderno: imutável na teoria, mas todo mundo dá um jeitinho.

```csharp
public record CasamentoModerno(
    string Aparencias = "Mantidas",
    bool FidelidadeEmocional = false,
    decimal ContaBancaria = decimal.MaxValue
)
{
    // A única coisa que realmente não muda é a prestação do apartamento
    public const decimal Divida = double.PositiveInfinity;
}
```

## [SYSTEM://EVENTOS_E_DELEGATES] 📢

Eventos são como fofoca de empresa: todo mundo fica escutando, e quando acontece algo, todo mundo fica sabendo.

```csharp
public class RadioCorredor
{
    // O delegate é o formato padrão da fofoca
    public delegate void FofocaEventHandler(string fofoca);

    // O evento é o grupo do WhatsApp
    public event FofocaEventHandler FofocaDispara;

    public void EspalharFofoca(string fofoca)
    {
        // Dispara a fofoca pra todo mundo que tá ouvindo
        FofocaDispara?.Invoke($"🗣️ {fofoca}");
    }
}
```

## [SYSTEM://FINALIZADORES] ⚰️

Finalizadores são como velório: ninguém sabe quando vai acontecer, mas quando rola, geralmente dá merda.

```csharp
public class UltimosDesejos
{
    ~UltimosDesejos()
    {
        // Aqui é onde você tenta limpar a bagunça
        // Mas provavelmente só vai piorar tudo
        try
        {
            Console.WriteLine("Tentando morrer com dignidade...");
        }
        catch
        {
            // Se der erro aqui, você tá mais fodido que defunto em cemitério lotado
        }
    }
}
```

## [ARIA://REGRAS_DO_SUBMUNDO] 📜

1. Se der erro, joga numa `try-catch` e finge que não viu
2. Se o código tá feio, faz uma interface pra esconder
3. Se não sabe onde colocar, joga num `static`
4. Se alguém reclamar, diz que é padrão de projeto

## [SYSTEM://PALAVRAS_FINAIS] ⚰️

> "Todo código é uma obra de arte... arte moderna, daquelas que ninguém entende mas todo mundo finge que é genial."

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: COMPLETAMENTE_INSANO | Matrix Stability: ERROR_OVERFLOW
