# Namespace

## Definição

Os namespaces são usados para organizar o código de forma lógica. E assim como não podemos dois arquivos de mesmo nome em uma pasta, não podemos ter duas classes com o mesmo nome em um `namespace`.

<note>

O ideal como boa prática é termos apenas **um namespace e uma classe por** arquivo

</note>

## Implementação

```c#
namespace MilfGoApp 
{
    // code...
} 

```

- Sempre que criamos uma nova classe devemos colocar ela dentro do namespace
- Podemos criar vários namespaces dentro de um projeto. Mas o namespace deve ser único no projeto
- Um namespace pode ser reutilizado em outros projetos

<note>
Normalmente o nome do namespace é igual ao nome da solução ou projeto.
</note>


