# DotnetBaseKit CLI

O DotnetBaseKit CLI é uma ferramenta interativa em .NET que acelera a criação de novos projetos baseados na arquitetura DotnetBaseKit. Ela guia o usuário por um assistente simples e gera uma solução pronta para uso com estrutura em camadas para aplicações .NET 8.

A ferramenta foi criada como um .NET tool local e funciona instalando um template personalizado do projeto irmão `DotnetBaseKit.Templates`, e depois criando a solução via `dotnet new basekit`.

## Visão geral

Essa CLI ajuda a iniciar uma nova aplicação seguindo uma estrutura inspirada em Clean Architecture, com as camadas:

- API
- Application
- Domain
- Infrastructure
- Shared
- Tests (opcional)

Ela suporta vários tipos de banco de dados e pode incluir um projeto de testes automaticamente.

## Funcionalidades

- criação interativa de projetos via prompts no console
- instalação automática do template antes da geração
- suporte para:
  - MySQL
  - MongoDB
  - PostgreSQL
  - SQLite
- inclusão opcional de projeto de testes
- estrutura de solução .NET 8 pronta para uso
- interface amigável no terminal com `Spectre.Console`

## Pré-requisitos

Antes de usar a ferramenta, certifique-se de ter:

- .NET 8 SDK instalado
- acesso ao projeto localmente
- terminal ou PowerShell/CMD disponível

Verifique a instalação:

```bash
dotnet --version
```

## Instalação

Na pasta do projeto, empacote e instale a ferramenta localmente:

```bash
dotnet pack ./DotnetBaseKit.Cli.csproj -c Release
```

Em seguida, instale globalmente a partir do diretório do pacote gerado:

```bash
dotnet tool update --global --add-source ./bin/Release DotnetBaseKit.Cli
```

Se a ferramenta ainda não estiver instalada, use:

```bash
dotnet tool install --global --add-source ./bin/Release DotnetBaseKit.Cli
```

## Uso

Execute a CLI:

```bash
dotnet-basekit
```

A ferramenta perguntará:

1. o nome do projeto
2. o tipo de banco de dados
3. se deseja incluir um projeto de testes

Exemplo de fluxo:

```text
DotnetBaseKit
Interactive Project Generator v1.0.0

Enter project name: (Ex: MyProject): MyCustomerApi
Which Database do you want?
> MySql
Do you want to include a unit test project in the solution? (Y/n)
```

Após a confirmação, a CLI instala o template e gera a estrutura do projeto.

## Estrutura gerada

A ferramenta cria uma solução com uma estrutura semelhante a:

```text
MyProject/
├── MyProject.Api/
├── MyProject.Application/
├── MyProject.Domain/
├── MyProject.Infra/
├── MyProject.Shared/
├── MyProject.Tests/   (opcional)
└── MyProject.sln
```

## Bancos de dados suportados

A CLI mapeia a opção escolhida para o parâmetro do template:

| Opção | Flag do template |
|-------|------------------|
| MySql | `sql` |
| MongoDB | `mongodb` |
| PostgreSQL | `postgresql` |
| Sqlite | `sqlite` |
| Padrão | `none` |

## Como funciona internamente

A CLI realiza os seguintes passos:

1. exibe o banner inicial
2. coleta a configuração do projeto em `ConsoleUi`
3. valida o nome do projeto
4. chama `ProjectGenerator.EnsureTemplateInstalled()`
5. executa `dotnet new basekit` com os parâmetros escolhidos
6. mostra um painel de sucesso com a estrutura gerada

A lógica principal está em:

- `Program.cs`
- `UI/ConsoleUi.cs`
- `Services/ProjectGenerator.cs`

## Executando o projeto gerado

Após a geração, o fluxo padrão é:

```bash
cd MyProject

dotnet restore
dotnet build
dotnet run --project MyProject.Api
```

O projeto de API normalmente expõe o Swagger e fica disponível no ambiente local ao ser executado.

## Migrations do banco de dados

Importante: as migrations não são criadas automaticamente por esta CLI. Após gerar o projeto, você precisa criar as migrations manualmente com os comandos do Entity Framework Core, de acordo com o provedor de banco selecionado.

Exemplo:

```bash
cd MyProject

dotnet ef migrations add InitialCreate --project MyProject.Infra --startup-project MyProject.Api
```

Em seguida, aplique-as:

```bash
dotnet ef database update --project MyProject.Infra --startup-project MyProject.Api
```

Se o projeto estiver usando outro provedor, ajuste o comando conforme o pacote do banco e a configuração de conexão. A CLI apenas scaffolda a solução; a geração das migrations fica a cargo do desenvolvedor.

## Observações de desenvolvimento

Este projeto foi pensado para ser simples e focado em produtividade. Ele atua como gerador de base para um repositório de templates maior (`DotnetBaseKit.Templates`), tornando mais fácil criar scaffolds consistentes e limpos.

## Solução de problemas

### Comando não reconhecido

Se o comando não for encontrado, verifique se a ferramenta global foi instalada corretamente:

```bash
dotnet tool list --global
```

### Template não encontrado

Se a geração falhar, a CLI tenta reinstalar o template automaticamente. Você também pode fazer isso manualmente:

```bash
dotnet new install "C:\caminho\para\DotnetBaseKit.Templates\bin\Release" --force
```

### Falha na criação do projeto

A CLI captura a saída de erro do comando de template e a exibe no terminal. Essa saída costuma ser suficiente para identificar uma dependência inexistente ou uma configuração inválida do template.

## Licença

Este projeto foi pensado para scaffolding interno e pessoal. Verifique a política do repositório ou as configurações do controle de versão antes de uso comercial.

## Contribuições

Contribuições são bem-vindas. Se você quiser melhorar a CLI, o comportamento do template ou a arquitetura gerada, abra uma issue ou envie um pull request com as alterações pertinentes.
