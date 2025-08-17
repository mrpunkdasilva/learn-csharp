# Datas

Manipular datas e horas é uma das tarefas mais comuns e, surpreendentemente, uma das mais complexas na programação. Um simples carimbo de data pode esconder armadilhas relacionadas a fusos horários, formatação e performance.

Este guia vai além do básico do `DateTime` e apresenta as ferramentas e práticas recomendadas para manipular datas e horas em C# de forma profissional e robusta.

## A Família de Tipos de Data e Hora

O .NET oferece uma família de tipos para trabalhar com datas e horas. É crucial escolher a ferramenta certa para cada trabalho.

| Tipo | Descrição | Quando Usar |
| :--- | :--- | :--- |
| `DateTime` | Representa um ponto no tempo, geralmente expresso como uma data e hora do dia. | Usado para necessidades simples, mas pode ser ambíguo em relação ao fuso horário. |
| `DateTimeOffset` | Representa um ponto no tempo, incluindo um deslocamento (offset) do Tempo Universal Coordenado (UTC). | **Recomendado para a maioria dos casos**, especialmente em APIs e bancos de dados, pois não é ambíguo. |
| `TimeSpan` | Representa uma duração ou intervalo de tempo. | Para medir o tempo entre dois pontos ou representar uma quantidade de tempo (ex: 24 horas). |
| `DateOnly` | (.NET 6+) Representa apenas a parte da data, sem a hora. | Quando você só precisa do dia, mês e ano (ex: data de nascimento). |
| `TimeOnly` | (.NET 6+) Representa apenas a hora do dia, sem a data. | Quando você só precisa da hora (ex: horário de funcionamento de uma loja). |
| `TimeZoneInfo` | Representa um fuso horário. | Para converter datas e horas entre diferentes fusos horários. |

---

## O `DateTime` e sua Armadilha: `DateTime.Kind`

O `DateTime` parece simples, mas ele carrega uma propriedade traiçoeira chamada `Kind`. Ela define como o valor da data deve ser interpretado em relação ao fuso horário e pode ser de três tipos:

-   `DateTimeKind.Utc`: A data e hora são expressas em Tempo Universal Coordenado. É um padrão global, o mesmo em todo o mundo.
-   `DateTimeKind.Local`: A data e hora estão no fuso horário local da máquina onde o código está rodando. Isso pode variar de servidor para servidor.
-   `DateTimeKind.Unspecified`: O fuso horário não foi especificado. **Este é o padrão para datas criadas manualmente e a principal fonte de bugs.**

### Exemplo de Bug com `DateTimeKind.Unspecified`

Imagine que um usuário no Brasil (UTC-3) agenda uma tarefa para as `14:00`. Você salva isso no banco de dados como `new DateTime(2025, 10, 20, 14, 0, 0)`. O `Kind` será `Unspecified`.

Um serviço rodando em um servidor na Europa (UTC+1) lê essa data. Ao tentar converter para a hora local, o .NET pode assumir que `14:00` era a hora local do servidor, e não do usuário. A tarefa que deveria rodar às `14:00` no Brasil acaba rodando em um horário completamente diferente.

```csharp
// Kind is DateTimeKind.Unspecified
var unspecifiedTime = new DateTime(2025, 1, 1, 14, 0, 0); 

// This conversion is unreliable because the source Kind is Unspecified.
// The .NET runtime will assume it's a Local time according to the server's timezone.
var convertedTime = unspecifiedTime.ToUniversalTime();

Console.WriteLine($"Original: {unspecifiedTime} (Kind: {unspecifiedTime.Kind})");
Console.WriteLine($"Converted to UTC: {convertedTime}"); // The result depends on the server's timezone!
```

## A Solução Profissional: `DateTimeOffset`

Para evitar a ambiguidade do `DateTime.Kind`, use `DateTimeOffset`. Ele armazena a mesma informação que o `DateTime`, mas também inclui o **offset**, que é a diferença de tempo em relação ao UTC. Isso torna o momento no tempo absoluto e inequívoco.

Um offset de `-03:00` significa "três horas a menos que o UTC".

```csharp
// This object represents an absolute moment in time.
// The offset (-03:00) makes it unambiguous.
var specificMoment = new DateTimeOffset(2025, 8, 16, 15, 0, 0, TimeSpan.FromHours(-3));
Console.WriteLine(specificMoment);

// You can easily convert it to another timezone's offset, for example, India (UTC+5:30)
var indiaTime = specificMoment.ToOffset(TimeSpan.FromMinutes(330));
Console.WriteLine($"Same moment in India: {indiaTime}");

// And you can always get the pure UTC value
Console.WriteLine($"UTC value: {specificMoment.ToUniversalTime()}");
```

Com `DateTimeOffset`, o momento `16/08/2025 15:00:00 -03:00` é sempre o mesmo, não importa se o servidor que processa essa informação está no Brasil, no Japão ou na Lua.

## Os Especialistas: `DateOnly` e `TimeOnly`

Introduzidos no .NET 6, esses tipos resolvem um problema antigo: a necessidade de carregar uma data e hora completas quando você só precisa de uma parte. Eles são mais eficientes (usam menos memória) e deixam a intenção do seu código mais clara.

### `DateOnly`
Use para representar uma data de calendário. Mapeia perfeitamente para o tipo `date` em SQL.

```csharp
// Represents a birth date, time is irrelevant.
var birthDate = new DateOnly(1990, 10, 20);
Console.WriteLine($"Birth date: {birthDate.ToLongDateString()}");
```

### `TimeOnly`
Use para representar uma hora do dia. Mapeia para o tipo `time` em SQL.

```csharp
// Represents the opening time of a store
var openingTime = new TimeOnly(9, 0, 0);
Console.WriteLine($"Store opens at: {openingTime.ToLongTimeString()}");
```

---

## Convertendo Texto em Datas (`Parse`)

Receber datas como strings é muito comum. Para convertê-las em objetos, use os métodos `Parse` ou `TryParse`. A melhor prática é ser o mais explícito possível sobre o formato esperado.

### A Forma Mais Segura: `TryParseExact`

Para evitar exceções (`try-catch`), que podem impactar a performance, e garantir que apenas um formato específico seja aceito, use `TryParseExact`. Ele retorna `true` se a conversão for bem-sucedida e `false` caso contrário.

```csharp
using System.Globalization;

var dateString = "2025-08-16";
var format = "yyyy-MM-dd";

// We use CultureInfo.InvariantCulture for machine-to-machine communication
// to ensure the format is consistent regardless of system culture.
// DateTimeStyles.None ensures no extra assumptions are made.
if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
{
    Console.WriteLine($"Successfully parsed: {parsedDate:D}");
}
else
{
    Console.WriteLine("Could not parse the date string.");
}
```

---

## Boas Práticas para Manipulação de Datas

1.  **Prefira `DateTimeOffset` a `DateTime`**. Use-o como padrão para APIs, bancos de dados e logs. Ele elimina a ambiguidade de fuso horário e torna seu sistema mais robusto.

2.  **Use `DateTime.UtcNow` para Timestamps.** Ao registrar quando um evento ocorreu (ex: data de criação de um registro), use sempre `DateTime.UtcNow` (ou `DateTimeOffset.UtcNow`). O tempo do servidor local é irrelevante e pode mudar com o horário de verão ou com a localização do servidor.

3.  **Use `DateOnly` e `TimeOnly`** quando a informação de hora ou data for irrelevante. Isso torna seu modelo de dados mais claro, eficiente e evita bugs relacionados a partes da data que deveriam ser ignoradas.

4.  **Seja Explícito ao Fazer `Parse` de Strings.** Sempre use `TryParseExact`. Para datas de máquina para máquina (ex: JSON, XML), use `CultureInfo.InvariantCulture` e um formato bem definido (como o padrão ISO 8601: `yyyy-MM-ddTHH:mm:ssZ`). Para datas inseridas por usuários, use a cultura específica deles (`new CultureInfo("pt-BR")`).

5.  **Armazene Datas em UTC e Converta na Apresentação.** A regra de ouro: seu back-end e seu banco de dados devem viver em UTC. A conversão para o fuso horário do usuário deve ser a última etapa, realizada pela interface do usuário (UI).

```mermaid
graph TD
    subgraph Servidor/Banco de Dados (Sempre em UTC)
        A[DateTimeOffset.UtcNow] --> B{Armazenar em UTC};
    end

    subgraph Cliente/UI (Fuso do Usuário)
        C[Ler data do BD] --> D{Converter para Fuso Local};
        D --> E[Exibir para o Usuário];
    end

    B --> C;
```

## Veja Também (Referências Oficiais)

-   [Estrutura `DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime)
-   [Estrutura `DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)
-   [Estruturas `DateOnly` e `TimeOnly`](https://learn.microsoft.com/dotnet/standard/datetime/dateonly-timeonly)
-   [Escolhendo entre `DateTime` e `DateTimeOffset`](https://learn.microsoft.com/dotnet/standard/datetime/choosing-between-datetime-datetimeoffset-and-timezoneinfo)
-   [Strings de Formato de Data e Hora Padrão](https://learn.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings)
-   [Analisando Strings de Data e Hora em .NET](https://learn.microsoft.com/dotnet/standard/base-types/parsing-datetime)
