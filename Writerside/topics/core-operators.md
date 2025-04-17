# [SYSTEM://OPERATORS] 🔣

```ascii
╔══════════════════════════════════════════════════════════════════╗
║ ██████╗ ██████╗ ███████╗██████╗  █████╗ ████████╗ ██████╗ ██████╗║
║██╔═══██╗██╔══██╗██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔══██║
║██║   ██║██████╔╝█████╗  ██████╔╝███████║   ██║   ██║   ██║██████╔║
║██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗██╔══██║   ██║   ██║   ██║██╔══██║
║╚██████╔╝██║     ███████╗██║  ██║██║  ██║   ██║   ╚██████╔╝██║  ██║
║ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═║
╚══════════════════════════════════════════════════════════════════╝
```

## [ARIA://MENSAGEM] 📡

> "Desenvolvedor, aqui você encontrará os operadores que manipulam a Matrix. Cada símbolo é uma chave para transformar e combinar dados em sua forma mais fundamental. Domine-os, e você poderá dobrar a realidade digital ao seu comando."

## [SYSTEM://OVERVIEW] 🌐

```ascii
╔════════════════════════════════════════════════════╗
║ MÓDULO: OPERADORES                                ║
║ STATUS: FUNDAMENTAL                               ║
║ PRIORIDADE: ALTA                                 ║
║ CLEARANCE: NÍVEL-1                               ║
║ COMPLEXIDADE: MÉDIA                              ║
║ PREREQUISITOS: VARIÁVEIS, TIPOS DE DADOS         ║
╚════════════════════════════════════════════════════╝
```

## [SYSTEM://CATEGORIAS] 📊

### 1. Operadores Aritméticos
```csharp
public class OperadoresAritmeticos
{
    public void ExemplosBasicos()
    {
        int a = 10, b = 3;
        
        int soma = a + b;        // 13
        int subtracao = a - b;   // 7
        int multiplicacao = a * b;// 30
        int divisao = a / b;     // 3
        int modulo = a % b;      // 1
        
        int incremento = ++a;    // a = 11
        int decremento = --b;    // b = 2
    }

    public void ExemplosAvancados()
    {
        // Overflow e Underflow
        checked
        {
            int maxValue = int.MaxValue;
            // int overflow = maxValue + 1; // Throws OverflowException
        }

        // Divisão com números decimais
        decimal preco = 10.99m;
        int quantidade = 3;
        decimal total = preco * quantidade; // 32.97

        // Arredondamento
        double d = 3.14159;
        double arredondado = Math.Round(d, 2); // 3.14
    }

    public void OperacoesEspeciais()
    {
        // Potenciação
        double quadrado = Math.Pow(5, 2);    // 25
        double cubo = Math.Pow(2, 3);        // 8

        // Raiz quadrada
        double raiz = Math.Sqrt(16);         // 4

        // Valor absoluto
        double absoluto = Math.Abs(-42.5);   // 42.5
    }
}
```

### 2. Operadores de Comparação
```csharp
public class OperadoresComparacao
{
    public void ExemplosBasicos()
    {
        int x = 5, y = 10;
        
        bool igual = x == y;         // false
        bool diferente = x != y;     // true
        bool maior = x > y;          // false
        bool menor = x < y;          // true
        bool maiorIgual = x >= y;    // false
        bool menorIgual = x <= y;    // true
    }

    public void ComparacaoObjetos()
    {
        string str1 = "Matrix";
        string str2 = "matrix";
        
        // Comparação sensível a maiúsculas/minúsculas
        bool exatamenteIgual = str1 == str2;                     // false
        bool ignorarCase = str1.Equals(str2, 
            StringComparison.OrdinalIgnoreCase);                 // true

        // Comparação de referências
        object obj1 = new object();
        object obj2 = obj1;
        bool mesmaReferencia = ReferenceEquals(obj1, obj2);      // true
    }

    public void ComparacaoNumerica()
    {
        double d1 = 0.1 + 0.2;
        double d2 = 0.3;
        
        // Comparação com precisão
        bool aproximadamenteIgual = Math.Abs(d1 - d2) < 0.000001;
    }
}
```

### 3. Operadores Lógicos
```csharp
public class OperadoresLogicos
{
    public void ExemplosBasicos()
    {
        bool a = true, b = false;
        
        bool e = a && b;     // false
        bool ou = a || b;    // true
        bool nao = !a;       // false
        
        // Curto-circuito
        bool resultado = a && MetodoNaoExecutado();
    }
    
    private bool MetodoNaoExecutado() => true;

    public void OperacoesComplexas()
    {
        bool x = true, y = false, z = true;

        // Combinações complexas
        bool expressaoComposta = (x || y) && (!z || x);
        
        // Precedência de operadores lógicos
        bool precedencia = x || y && z;  // Equivalente a: x || (y && z)
        
        // XOR lógico
        bool xor = x ^ y;    // true se apenas um for true
    }

    public void ExemplosAvancados()
    {
        // Operadores bit a bit como lógicos
        bool a = true, b = true;
        bool andBitwise = a & b;    // Sempre avalia ambos os operandos
        bool orBitwise = a | b;     // Sempre avalia ambos os operandos

        // Null coalescing com lógica
        bool? nullableBool = null;
        bool resultado = nullableBool ?? true;  // true
    }
}
```

### 4. Operadores de Atribuição
```csharp
public class OperadoresAtribuicao
{
    public void ExemplosBasicos()
    {
        int x = 10;
        
        x += 5;     // x = x + 5
        x -= 3;     // x = x - 3
        x *= 2;     // x = x * 2
        x /= 4;     // x = x / 4
        x %= 3;     // x = x % 3
        x &= 1;     // x = x & 1
        x |= 1;     // x = x | 1
        x ^= 1;     // x = x ^ 1
    }

    public void AtribuicoesAvancadas()
    {
        // Atribuição múltipla
        int a, b, c;
        a = b = c = 0;  // Todas recebem 0

        // Atribuição com operação
        string texto = "Matrix";
        texto += " " += "Reloaded";  // "Matrix Reloaded"

        // Atribuição com expressão
        int resultado = (a = 5) + (b = 3);  // resultado = 8
    }

    public void AtribuicoesComTuplas()
    {
        // Troca de valores com tuplas
        int x = 1, y = 2;
        (x, y) = (y, x);

        // Atribuição múltipla com tuplas
        var (nome, idade) = ("Neo", 35);
    }
}
```

### 5. Operadores Bit a Bit
```csharp
public class OperadoresBitwise
{
    public void ExemplosBasicos()
    {
        int a = 5;  // 101 em binário
        int b = 3;  // 011 em binário
        
        int and = a & b;     // 001 = 1
        int or = a | b;      // 111 = 7
        int xor = a ^ b;     // 110 = 6
        int not = ~a;        // ...11111010
        int left = a << 1;   // 1010 = 10
        int right = a >> 1;  // 010 = 2
    }

    public void OperacoesBitwiseAvancadas()
    {
        // Máscara de bits
        const int PERMISSION_READ = 4;    // 100
        const int PERMISSION_WRITE = 2;   // 010
        const int PERMISSION_EXEC = 1;    // 001

        int permissions = PERMISSION_READ | PERMISSION_WRITE;  // 110

        // Verificar permissão
        bool canRead = (permissions & PERMISSION_READ) != 0;   // true
        bool canExec = (permissions & PERMISSION_EXEC) != 0;   // false

        // Toggle de bit específico
        permissions ^= PERMISSION_WRITE;  // Remove WRITE
        permissions ^= PERMISSION_EXEC;   // Adiciona EXEC
    }

    public void ManipulacaoBitsAvancada()
    {
        // Rotação de bits
        uint valor = 0x0000_00FF;
        uint rotacionado = (valor << 8) | (valor >> 24);

        // Contagem de bits
        int numero = 255;  // 11111111
        int contagem = 0;
        while (numero != 0)
        {
            contagem += numero & 1;
            numero >>= 1;
        }
    }
}
```

### 6. Operadores Especiais
```csharp
public class OperadoresEspeciais
{
    public void ExemplosBasicos()
    {
        // Operador Ternário
        int idade = 20;
        string status = idade >= 18 ? "Adulto" : "Menor";
        
        // Operador Null Coalescing
        string nome = null;
        string nomeDefault = nome ?? "Anônimo";
        
        // Operador Null Conditional
        string? texto = null;
        int? comprimento = texto?.Length;
        
        // Operador is e as
        object obj = "teste";
        bool isString = obj is string;
        string? str = obj as string;
    }

    public void ExemplosAvancados()
    {
        // Pattern Matching com is
        object valor = 42;
        if (valor is int n && n > 0)
        {
            Console.WriteLine($"Número positivo: {n}");
        }

        // Switch Expression
        string tipo = valor switch
        {
            int i when i > 0 => "Positivo",
            int i when i < 0 => "Negativo",
            0 => "Zero",
            _ => "Não é um número"
        };

        // Null Coalescing Assignment
        string? texto = null;
        texto ??= "Valor Padrão";
    }

    public void OperadoresPersonalizados()
    {
        // Exemplo de classe com operadores personalizados
        public readonly struct ComplexNumber
        {
            public double Real { get; }
            public double Imaginary { get; }

            public ComplexNumber(double real, double imaginary)
            {
                Real = real;
                Imaginary = imaginary;
            }

            public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
                => new(a.Real + b.Real, a.Imaginary + b.Imaginary);

            public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
                => new(
                    a.Real * b.Real - a.Imaginary * b.Imaginary,
                    a.Real * b.Imaginary + a.Imaginary * b.Real
                );
        }
    }
}
```

## [SYSTEM://PRECEDÊNCIA] 🎯

```ascii
╔════════════════════════════════════════════════════╗
║ ORDEM DE PRECEDÊNCIA (DO MAIOR PARA O MENOR)      ║
║ ────────────────────────────────────────────────  ║
║ 1. Primários                                     ║
║    a. x.y  f(x)  a[x]  x++  x--  new  typeof    ║
║    b. checked  unchecked                         ║
║                                                  ║
║ 2. Unários                                       ║
║    +  -  !  ~  ++x  --x  (T)x                   ║
║                                                  ║
║ 3. Multiplicativos                               ║
║    *  /  %                                       ║
║                                                  ║
║ 4. Aditivos                                      ║
║    +  -                                          ║
║                                                  ║
║ 5. Shift                                         ║
║    <<  >>                                        ║
║                                                  ║
║ 6. Relacionais e Type-testing                    ║
║    <  >  <=  >=  is  as                         ║
║                                                  ║
║ 7. Igualdade                                     ║
║    ==  !=                                        ║
║                                                  ║
║ 8. AND Bit a Bit                                 ║
║    &                                             ║
║                                                  ║
║ 9. XOR Bit a Bit                                 ║
║    ^                                             ║
║                                                  ║
║ 10. OR Bit a Bit                                 ║
║     |                                            ║
║                                                  ║
║ 11. AND Lógico                                   ║
║     &&                                           ║
║                                                  ║
║ 12. OR Lógico                                    ║
║     ||                                           ║
║                                                  ║
║ 13. Null Coalescing                              ║
║     ??                                           ║
║                                                  ║
║ 14. Condicional                                  ║
║     ?:                                           ║
║                                                  ║
║ 15. Atribuição                                   ║
║     =  *=  /=  %=  +=  -=  <<=  >>=  &=  ^=  |= ║
║                                                  ║
║ 16. Lambda Expression                            ║
║     =>                                           ║
╚════════════════════════════════════════════════════╝
```

## [ARIA://BOAS_PRÁTICAS] 💡

1. **Clareza Acima de Tudo**
   - Use parênteses para tornar a precedência explícita
   - Evite expressões muito complexas
   - Quebre operações complexas em passos menores

2. **Operadores de Incremento/Decremento**
   - Evite usar em expressões complexas
   - Prefira forma pré-fixada (++i) quando o valor é importante
   - Use em linhas separadas para maior clareza

3. **Operadores Lógicos**
   - Use operadores de curto-circuito (&&, ||) por padrão
   - Reserve operadores bit a bit (&, |) para casos específicos
   - Mantenha expressões booleanas simples e legíveis

4. **Null Checking**
   - Utilize o operador null-conditional (?.) para navegação segura
   - Combine com null-coalescing (??) para valores padrão
   - Considere null-coalescing assignment (??=) para inicialização

5. **Operadores Bit a Bit**
   - Documente o propósito das operações bit a bit
   - Use constantes nomeadas para máscaras de bits
   - Considere métodos auxiliares para operações complexas

6. **Operadores Personalizados**
   - Implemente apenas quando o significado for óbvio
   - Mantenha a simetria (se implementar +, considere -)
   - Siga as convenções da linguagem

## [SYSTEM://EXERCÍCIOS] 🏋️

```csharp
public class OperatorExercises
{
    // Exercício 1: Implementar calculadora avançada
    public double Calcular(double a, double b, string operador)
    {
        return operador switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" when b != 0 => a / b,
            "%" when b != 0 => a % b,
            "^" => Math.Pow(a, b),
            _ => throw new ArgumentException("Operador inválido")
        };
    }
    
    // Exercício 2: Verificar número par/ímpar usando bitwise
    public bool IsEven(int numero)
    {
        return (numero & 1) == 0;
    }
    
    // Exercício 3: Implementar toggle de flags usando operadores bit a bit
    public int ToggleFlag(int flags, int flag)
    {
        // TODO: Implementar toggle de flag
        throw new NotImplementedException();
    }
}
```

## [SYSTEM://PRÓXIMOS_PASSOS] 🚀

```ascii
╔════════════════════════════════════════════════════╗
║ CONTINUE SEU TREINAMENTO:                         ║
║     → Expressões                                  ║
║     → Controle de Fluxo                          ║
║     → Conversões de Tipo                         ║
║     → Operadores Avançados                       ║
╚════════════════════════════════════════════════════╝
```

## [ARIA://AVISO_FINAL] ⚠️

> "Operadores são as ferramentas fundamentais para manipular a Matrix. Use-os com precisão e entenda suas nuances para dobrar a realidade digital ao seu comando."

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: ONLINE | Matrix Stability: 99.9%...