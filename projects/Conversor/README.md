# Atividade Semana 1

Este é um projeto de console em C# desenvolvido como parte da Atividade da Semana 1. A aplicação demonstra a manipulação de parâmetros de linha de comando e realiza diversas conversões de tipos de dados.

## Funcionalidades

- **Leitura de Parâmetros:** Exibe no console todos os parâmetros que foram passados para a aplicação durante sua execução.
- **Conversões de Tipos de Dados:**
    - `int` para `short`, `long`, e `double`
    - `float` para `int`
    - `bool` para `string`
    - `int` para `string`
- **Boxing e Unboxing:**
    - **Boxing:** Converte tipos de valor (`int`, `float`, `bool`) para o tipo `object`.
    - **Unboxing:** Converte o tipo `object` de volta para seus tipos de valor originais.

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) ou superior.

## Como Executar

1.  Clone este repositório (ou baixe os arquivos).
2.  Abra um terminal na pasta raiz do projeto (`/home/mrpunkdasilva/RiderProjects/Jala/Jala/AtividadeSemana1`).
3.  Execute o comando para rodar a aplicação:

    ```bash
    dotnet run
    ```

4.  Para passar parâmetros para a aplicação, use `--` após o comando `run`, seguido pelos seus parâmetros:

    ```bash
    dotnet run -- parametro1 123 "outro parametro"
    ```

## Exemplo de Saída

Ao executar com parâmetros, a saída será semelhante a esta:

```
=== Laboratorio Semana 1 ===
Parametros fornecidos:
Parametro 1: parametro1
Parametro 2: 123
Parametro 3: outro parametro
====== INTEGER
INTEGER Int32  [12] => SHORT Int16 [12]
INTEGER Int32  [12] => DOUBLE Double [12]
INTEGER Int32  [12] => STRING Double [12]
====== FLOAT
FLOAT Single  [12.12] => INT Int32 [12]
====== BOOLEAN
BOOLEAN Boolean  [True] => DOUBLE String [True]
====== BOXING
INTEGER Int32      [12]     => boxedInt   Object   [12]
FLOAT   Single    [12.12]   => boxedFloat Object [12.12]
BOOLEAN Boolean  [True] => boxedBool  Object  [True]
====== UNBOXING
boxedInt   Object    [12]    => unboxedInt   Int32   [12]
boxedFloat Object  [12.12]  => unboxedFloat Single [12.12]
boxedBool  Object   [True]   => unboxedBool  Boolean  [True]
```
