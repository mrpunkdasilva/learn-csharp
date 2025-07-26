# Interpolação

## Concatenação

Interpolação é juntar uma string com outro valor:

```c#
var price = 12.2;
var texto = "O preço é " + price;

Console.WriteLine(texto); // O preço é 12.2
```

> Ou seja, é transformar uma `string` + `qualquer outro tipo` para uma `string`

---

## Format

Serve para interpolação e para interpolar, mas tem outras funções também 

```c#
var price = 10.2;
var texto = string.Format("O preço do produto é {0} apenas na promoção", price);
```

---

