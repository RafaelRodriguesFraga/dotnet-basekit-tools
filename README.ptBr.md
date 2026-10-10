# DotnetBaseKit

DotnetBaseKit é um gerador de projetos e ecossistema de templates para criar aplicações .NET 8 com uma arquitetura em camadas inspirada na Clean Architecture.

Este repositório contém:

- `DotnetBaseKit.Cli` — ferramenta de linha de comando interativa que cria novas soluções a partir de um template
- `DotnetBaseKit.Templates` — template reutilizável usado pela CLI para scaffoldar a aplicação gerada

## Estrutura do projeto

```text
DotnetBaseKit/
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
├── LICENSE
└── README.md
```

## Objetivo principal

O objetivo é ajudar desenvolvedores a criar rapidamente novas aplicações .NET com uma estrutura consistente, reduzindo boilerplate e padronizando:

- camada de API
- camada de Application
- camada de Domain
- camada de Infrastructure
- camada de Shared
- projeto opcional de testes
- configuração de banco de dados

## Uso da CLI

Instale a ferramenta localmente a partir da saída do projeto:

```bash
dotnet tool update --global --add-source ./DotnetBaseKit.Cli/bin/Release DotnetBaseKit.Cli
```

Depois execute:

```bash
dotnet-basekit
```

A CLI pergunta:

- nome do projeto
- tipo de banco
- se deseja incluir testes

Em seguida, instala o template e gera uma solução base para a arquitetura escolhida.

## Observação importante sobre migrations

A CLI cria a estrutura do projeto, mas não gera migrations de banco automaticamente. Você precisa criar essas migrations manualmente com os comandos do EF Core após a geração do projeto.

Exemplo:

```bash
dotnet ef migrations add InitialCreate --project SeuProjeto.Infra --startup-project SeuProjeto.Api
dotnet ef database update --project SeuProjeto.Infra --startup-project SeuProjeto.Api
```

## Documentação

A documentação detalhada da CLI está disponível em:

- [DotnetBaseKit.Cli/README.md](DotnetBaseKit.Cli/README.md)
- [DotnetBaseKit.Cli/README.ptBr.md](DotnetBaseKit.Cli/README.ptBr.md)

## Estrutura típica do projeto gerado

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

## Licença

Este projeto foi pensado para fluxos de desenvolvimento e scaffolding de projetos. Verifique a licença do repositório se você pretende utilizá-lo em produção ou distribuí-lo comercialmente.
