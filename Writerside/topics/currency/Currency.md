# Moeda

## Tipo de Dado

Uma grande questão ao se tratar de moedas, o melhor formato é `decimal`, no melhor dos casos, mas se precisar podemos ir
para outros dados caso precisemos de mais performance ou precisão

## Formatar moeda

```c#
decimal value = 10.21;

// indica que é para formatar como moeda BRL
Console.WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
```

