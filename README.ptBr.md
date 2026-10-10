# DotnetBaseKit Tools

[:us: English Version](./README.md) 

O DotnetBaseKit Tools é um gerador de projetos leve e um ecossistema de templates para criar aplicações .NET 8 com uma arquitetura em camadas inspirada em Clean Architecture / DDD.

Este repositório contém:

- `DotnetBaseKit.Cli` — ferramenta de linha de comando interativa que cria novas soluções a partir de um template.
- `DotnetBaseKit.Templates` — template de projeto reutilizável utilizado pela CLI para gerar a estrutura inicial da aplicação.

## Início rápido

### 1. Instalação

Instale a ferramenta global da CLI e o pacote de templates diretamente do [NuGet.org](https://www.nuget.org/):

```bash
dotnet tool install --global DotnetBaseKit.Cli
```

```bash
dotnet new install DotnetBaseKit.Templates
```

**Observação:** se você já tiver uma versão anterior instalada, atualize os pacotes com:

```bash
dotnet tool update --global DotnetBaseKit.Cli
dotnet new update
```

### 2. Utilização

Execute o gerador a partir de qualquer terminal:

```bash
dotnet-basekit
```

ou

```bash
dotnet basekit
```

A CLI interativa solicitará as seguintes informações:

- **Nome do projeto** (por exemplo, `MeuProjeto`).
- **Provedor de banco de dados** (por exemplo, `SQL Server`, `PostgreSQL`, `MySQL` ou `MongoDB`).
- **Projeto de testes unitários** (opcional: `y/n`, com `y` como padrão).

Após a geração, acesse a pasta da nova solução e compile o projeto:

```bash
cd MyProject
dotnet build
```

## Estrutura do repositório

```text
dotnet-basekit-tools/
├── DotnetBaseKit.Cli/
│   ├── Program.cs
│   ├── Services/
│   ├── UI/
│   ├── README.md
│   └── README.ptBr.md
├── DotnetBaseKit.Templates/
│   ├── content/
│   └── ...
├── .gitignore
└── README.md
```

## Objetivo principal

O objetivo é ajudar desenvolvedores a criar rapidamente novas aplicações .NET 8 com uma estrutura consistente, reduzindo o código repetitivo (*boilerplate*) e padronizando:

- **Camada de API** — endpoints, controllers e configuração do Swagger.
- **Camada de aplicação** — casos de uso, DTOs e interfaces.
- **Camada de domínio** — entidades, objetos de valor (*value objects*) e lógica de domínio.
- **Camada de infraestrutura** — contexto do EF Core / MongoDB, repositórios e persistência.
- **Camada compartilhada** — funcionalidades transversais (*cross-cutting concerns*) e utilitários.
- **Projeto de testes opcional** — configuração inicial do xUnit.

## Estrutura típica da aplicação gerada

```text
MeuProjeto/
├── MeuProjeto.Api/
├── MeuProjeto.Application/
├── MeuProjeto.Domain/
├── MeuProjeto.Infra/
├── MeuProjeto.Shared/
├── MeuProjeto.Tests/   (opcional)
├── MeuProjeto.sln
└── README.md
```

## Migrações de banco de dados

A CLI gera a estrutura da solução e configura as definições do provedor de banco de dados. No entanto, as migrações do Entity Framework Core precisam ser criadas manualmente após a geração do projeto:

```bash
# Adicionar a migração inicial
dotnet ef migrations add InitialCreate --project MeuProjeto.Infra --startup-project MeuProjeto.Api

# Atualizar o banco de dados
dotnet ef database update --project MeuProjeto.Infra --startup-project MeuProjeto.Api
```

## Documentação

Para obter informações detalhadas sobre a configuração da CLI e consultar a documentação em português, acesse:

- [DotnetBaseKit.Cli/README.md](DotnetBaseKit.Cli/README.md)
- [DotnetBaseKit.Cli/README.ptBr.md](DotnetBaseKit.Cli/README.ptBr.md)
