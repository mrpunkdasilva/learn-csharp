# Atividade - 2: Comparação de Estruturas de Dados em C#

Nesta seção, são comparadas as três estruturas de dados mais comuns em C#: Arrays (Matrizes), Lists (Listas) e Dictionaries (Dicionários/Mapas). É fundamental entender as diferenças entre elas para escolher a estrutura mais adequada para cada cenário no desenvolvimento de software. A escolha correta da estrutura de dados pode impactar significativamente a performance e a manutenibilidade do código.

| Característica / Estrutura | Arrays (Matrizes) | Lists (Listas) | Dictionaries (Dicionários/Mapas) |
| :------------------------- | :---------------- | :--------------- | :--------------------------------- |
| **Definição**              | Uma coleção de elementos de tamanho fixo e tipo homogêneo, armazenados em posições de memória contíguas. São utilizados quando o número de elementos é conhecido e fixo, proporcionando acesso direto e eficiente. | Uma coleção dinâmica de elementos de tipo homogêneo, que pode crescer ou diminuir de tamanho conforme a necessidade. Oferece grande flexibilidade para adicionar ou remover itens, sendo uma escolha versátil para a maioria dos cenários. | Uma coleção de pares chave-valor, onde cada chave é única e mapeia para um valor. É ideal para cenários onde é necessário buscar informações rapidamente por uma chave específica, como em registros de banco de dados ou configurações. |
| **Tamanho**                | Fixo (definido na inicialização). Uma vez criado, seu tamanho não pode ser alterado. Qualquer tentativa de adicionar mais elementos do que a capacidade alocada resultará em erro ou exigirá a criação de um novo array. | Dinâmico (pode ser redimensionado). A lista gerencia automaticamente seu tamanho interno, realocando memória conforme necessário. Isso simplifica o gerenciamento de coleções de tamanho variável. | Dinâmico (pode ser redimensionado). O dicionário ajusta sua capacidade conforme pares chave-valor são adicionados ou removidos, otimizando o armazenamento e a performance de busca. |
| **Acesso a Elementos**     | Por índice (baseado em zero). O acesso é muito rápido, quase em tempo constante (O(1)), pois os elementos estão em posições contíguas na memória. Isso o torna ideal para operações de leitura frequentes. | Por índice (baseado em zero). O acesso também é rápido (O(1)), similar aos arrays, devido à sua implementação subjacente que geralmente utiliza arrays. | Por chave. O acesso é extremamente rápido (O(1) em média), independentemente do número de elementos, devido ao uso de tabelas hash. Isso o torna eficiente para operações de busca e recuperação. |
| **Ordem**                  | Mantém a ordem de inserção. Os elementos são armazenados na ordem em que são adicionados, e essa ordem é preservada. | Mantém a ordem de inserção. Os elementos permanecem na ordem em que são adicionados, o que é útil para coleções onde a sequência é importante. | Não garante a ordem de inserção (historicamente). Embora a partir do .NET 5, `Dictionary<TKey, TValue>` mantenha a ordem de inserção, não se deve depender disso para ordenação, pois o propósito principal é a busca por chave. |
| **Uso Comum**              | Arrays são usados quando o número de elementos é conhecido e fixo, e é necessária alta performance para acesso direto, como em buffers de dados ou matrizes matemáticas. | Listas são usadas quando o número de elementos é variável e é preciso adicionar ou remover elementos frequentemente, como em listas de itens de carrinho de compras ou logs de eventos. | Dicionários são usados quando é necessário mapear chaves para valores e buscar informações rapidamente por uma chave específica, como em caches, configurações de aplicativos ou índices de dados. |
| **Vantagens**              | Eficiente em memória e acesso muito rápido por índice. Ideal para coleções de tamanho fixo e operações de leitura intensivas. | Flexível, fácil de adicionar e remover elementos. Muito versátil para a maioria dos cenários de coleção de dados. | Busca extremamente rápida por chave, chaves únicas garantem integridade e eficiência na recuperação de dados. Ideal para mapeamentos e dicionários de termos. |
| **Desvantagens**           | Tamanho fixo, o que torna o redimensionamento custoso (cria um novo array e copia os elementos). Inserções e exclusões no meio do array são ineficientes. | Inserções ou remoções no meio da lista podem ser lentas (O(n)), pois exigem o deslocamento de elementos subsequentes. | Consome mais memória que arrays ou listas para armazenar as chaves e os valores, devido à sobrecarga da tabela hash. |

## Exemplos de Código C#

### Arrays (Matrizes)
```c#
int[] numbers = new int[3];
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;
Console.WriteLine(numbers[1]); // Saída: 20
```

### Lists (Listas)
```c#
List<string> names = new List<string>();
names.Add("Alice");
names.Add("Bob");
names.Remove("Alice");
Console.WriteLine(names[0]); // Saída: Bob
```

### Dictionaries (Dicionários/Mapas)
```c#
Dictionary<string, int> ages = new Dictionary<string, int>();
ages.Add("Alice", 30);
ages.Add("Bob", 25);
Console.WriteLine(ages["Alice"]); // Saída: 30
ages["Charlie"] = 35; // Adiciona ou atualiza
```
