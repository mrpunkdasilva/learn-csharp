# Programação Orientada a Objetos (POO)

A Programação Orientada a Objetos (OOP, do inglês *Object-Oriented Programming*) é mais do que apenas uma técnica de programação; é um **paradigma**, uma maneira de pensar e estruturar o código de software. Em vez de organizar o programa como uma sequência de comandos lógicos (como na programação procedural), a POO organiza o código em torno de "objetos" auto-contidos.

## Analogia: Construindo com LEGO®

Pense na diferença entre seguir um manual de instruções passo a passo e construir algo com peças de LEGO.

-   **Programação Procedural** é como o manual de instruções: "Pegue a peça vermelha 2x4, coloque-a na posição X, pegue a peça azul 1x2, coloque-a na posição Y...". O foco está no **processo**, na sequência de ações.

-   **Programação Orientada a Objetos** é como pensar com as próprias peças de LEGO. Primeiro, você cria ou utiliza componentes especializados: uma "Roda", um "Motor", um "Chassi". Cada um desses **objetos** possui suas próprias características (**propriedades**, como cor e tamanho) e suas próprias funções (**métodos**, como `Girar()` ou `Ligar()`). Para construir um carro, você não precisa saber os detalhes internos de como o motor funciona; você simplesmente o encaixa no chassi e o conecta às rodas. Você interage com ele através de uma interface simples.

A POO permite gerenciar a complexidade de sistemas grandes da mesma forma: construindo componentes independentes e reutilizáveis que interagem entre si.

## Os Quatro Pilares da POO

A Programação Orientada a Objetos é sustentada por quatro conceitos fundamentais, conhecidos como os pilares da POO. Eles trabalham juntos para criar um código robusto, flexível e de fácil manutenção.

1.  **Encapsulamento**: A ideia de agrupar dados (atributos) e os métodos que operam nesses dados dentro de uma única unidade, a "classe". O objeto esconde seus detalhes internos e expõe apenas o que é necessário para a interação, protegendo seus dados de modificações indevidas.

2.  **Abstração**: Focar nos aspectos essenciais de um objeto, ignorando os detalhes irrelevantes ou complexos. O volante de um carro é um exemplo de abstração: você o utiliza para dirigir sem precisar entender a mecânica complexa do sistema de direção.

3.  **Herança**: Um mecanismo que permite a uma nova classe (filha) herdar atributos e métodos de uma classe existente (mãe). Isso promove a reutilização de código. Por exemplo, as classes `Carro`, `Caminhão` e `Motocicleta` podem herdar de uma classe base `Veiculo`.

4.  **Polimorfismo**: Significa "muitas formas". É a capacidade de objetos de diferentes classes responderem à mesma mensagem (chamada de método) de maneiras específicas para cada um. Por exemplo, um método `Mover()` pode fazer um `Carro` andar na estrada, um `Barco` navegar na água e um `Pássaro` voar no ar.

Dominar estes quatro pilares é o caminho para escrever um código C# eficaz, escalável e verdadeiramente profissional.