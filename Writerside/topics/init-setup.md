# [SYSTEM://ENVIRONMENT_SETUP] 🛠️

```ascii
╔══════════════════════════════════════════════════════════════════╗
║ ███████╗███████╗████████╗██╗   ██╗██████╗                      ║
║ ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗                     ║
║ ███████╗█████╗     ██║   ██║   ██║██████╔╝                     ║
║ ╚════██║██╔══╝     ██║   ██║   ██║██╔═══╝                      ║
║ ███████║███████╗   ██║   ╚██████╔╝██║                          ║
║ ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═╝                          ║
╚══════════════════════════════════════════════════════════════════╝
```

## [ARIA://MENSAGEM] 📡

> "Desenvolvedor, antes de mergulharmos nas profundezas do código, precisamos configurar seu ambiente neural. Vamos preparar seu sistema para a conexão com a Matrix do C#, seja você um operador Windows ou Linux."

## [SYSTEM://REQUISITOS] 📋

### 🔧 Hardware Recomendado
```ascii
╔════════════════════════════════════════════════════╗
║ CPU: 2+ cores                                      ║
║ RAM: 8GB+                                         ║
║ DISK: 10GB+ livre                                 ║
║ NET: Conexão estável com a Matrix                 ║
╚════════════════════════════════════════════════════╝
```

## [SYSTEM://INSTALAÇÃO] 💉

### 1. .NET SDK

#### 🪟 Windows
```bash
# Verificar instalação atual
dotnet --version

# Opção 1: Usando winget
winget install Microsoft.DotNet.SDK.7

# Opção 2: Download direto
# Visite: https://dotnet.microsoft.com/download
```

#### 🐧 Linux
```bash
# Ubuntu/Debian
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt update
sudo apt install dotnet-sdk-7.0

# Fedora
sudo dnf install dotnet-sdk-7.0

# Arch Linux
sudo pacman -S dotnet-sdk

# Verificar instalação
dotnet --version
```

### 2. IDE Neural Interface

#### 🪟 Windows: Visual Studio 2022
```ascii
╔════════════════════════════════════════════════════╗
║ MÓDULOS NECESSÁRIOS:                               ║
║ ▓ .NET Desktop Development                        ║
║ ▓ ASP.NET Web Development                         ║
║ ▓ Universal Windows Platform                      ║
╚════════════════════════════════════════════════════╝
```

#### 🐧 Linux: VS Code + Extensões
```bash
# Ubuntu/Debian
sudo apt install code

# Fedora
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo sh -c 'echo -e "[code]\nname=Visual Studio Code\nbaseurl=https://packages.microsoft.com/yumrepos/vscode\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/yum.repos.d/vscode.repo'
sudo dnf install code

# Arch Linux
sudo pacman -S code
```

### 3. Extensões Recomendadas (VS Code)
```
public class NeuroEnhancers
{
    public static readonly string[] Extensions = 
    {
        "C# Dev Kit",
        "C# Extensions",
        "vscode-solution-explorer",
        "GitLens",
        "Material Icon Theme"
    };
}
```

## [SYSTEM://VERIFICAÇÃO] 🔍

Execute o seguinte código para verificar sua instalação:

```
using System;

class MatrixTest
{
    static void Main()
    {
        Console.WriteLine("Iniciando diagnóstico do sistema...");
        
        try
        {
            // Teste básico de compilação
            Console.WriteLine("Conexão neural estabelecida!");
            Console.WriteLine($"Versão do .NET: {Environment.Version}");
            Console.WriteLine($"OS: {Environment.OSVersion}");
            Console.WriteLine($"Platform: {Environment.OSVersion.Platform}");
            
            Console.WriteLine("\n[STATUS: OPERACIONAL]");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRO] Falha na conexão: {ex.Message}");
        }
    }
}
```

## [SYSTEM://TROUBLESHOOTING] 🔧

### Problemas Comuns

```ascii
╔════════════════════════════════════════════════════╗
║ ERRO                    SOLUÇÃO                    ║
║ ════════════════════════════════════════════════   ║
║ SDK não encontrado     Reinstalar .NET SDK         ║
║ Path incorreto         Verificar variáveis amb.    ║
║ Permissão negada      sudo chmod +x ./dotnet      ║
║ SSL cert error        Instalar ca-certificates    ║
╚════════════════════════════════════════════════════╝
```

### 🐧 Linux: Permissões e Certificados
```bash
# Corrigir permissões do dotnet
sudo chown -R $USER:$USER ~/.dotnet

# Instalar certificados SSL
sudo apt install ca-certificates
# ou
sudo dnf install ca-certificates
```

## [ARIA://PRÓXIMOS_PASSOS] 🎯

> "Seu ambiente neural está configurado. Independente do seu sistema operacional, você está pronto para começar sua jornada pelo C#. No próximo módulo, vamos escrever seu primeiro programa e estabelecer sua primeira conexão real com a Matrix."

```ascii
╔════════════════════════════════════════════════════╗
║ [!] SETUP COMPLETO                                ║
║     CARREGANDO PRÓXIMO MÓDULO...                  ║
╚════════════════════════════════════════════════════╝
```

---
> [SYSTEM://UPDATE] Last modified: {DATE} | Status: ONLINE | Matrix Stability: 98%