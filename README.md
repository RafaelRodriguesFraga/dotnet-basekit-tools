# DotnetBaseKit Tools

[:brazil: Brazilian Portuguese Version](./README.ptBr.md) 

DotnetBaseKit Tools is a lightweight project generator and template ecosystem for creating .NET 8 applications with a layered architecture inspired by Clean Architecture / DDD.

This repository contains:

* `DotnetBaseKit.Cli` — interactive command-line tool that creates new solutions from a template.

* `DotnetBaseKit.Templates` — reusable project template used by the CLI to scaffold the generated application.

## Quick Start

### 1. Installation

Install the CLI global tool and the project template package directly from [NuGet.org](https://www.nuget.org/):

```bash
dotnet tool install --global DotnetBaseKit.Cli
```

```bash
dotnet new install DotnetBaseKit.Templates
```

**Note:** If you already have an older version installed, update them with:

```bash
dotnet tool update --global DotnetBaseKit.Cli
dotnet new update
```

### 2. Usage

Run the generator from any terminal:

```bash
dotnet-basekit
```

or

```bash
dotnet basekit
```

The interactive CLI will prompt you for:

* **Project name** (e.g., `MyProject`)

* **Database provider** (e.g., `SQL Server`, `PostgreSQL`, `MySQL`, `MongoDB`)

* **Unit Tests project** (optional `y/n`, default is `y`)

Once generated, navigate into your new solution folder and build:

```bash
cd MyProject
dotnet build
```

## Repository Structure

```
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

## Main Purpose

The goal is to help developers quickly create new .NET 8 applications with a consistent structure, reducing boilerplate and standardizing:

* **API Layer** (Endpoints, Controllers, Swagger configuration)

* **Application Layer** (Use cases, DTOs, interfaces)

* **Domain Layer** (Entities, value objects, domain logic)

* **Infra Layer** (EF Core / MongoDB context, repositories, persistence)

* **Shared Layer** (Cross-cutting concerns, utilities)

* **Optional Test Project** (xUnit setup)

## Typical Generated Application Structure

```
MyProject/
├── MyProject.Api/
├── MyProject.Application/
├── MyProject.Domain/
├── MyProject.Infra/
├── MyProject.Shared/
├── MyProject.Tests/   (optional)
├── MyProject.sln
└── README.md
```

## Database Migrations

The CLI scaffolds the solution structure and configures the database provider settings. However, Entity Framework Core migrations must be generated manually after project creation:

```bash
# Add initial migration
dotnet ef migrations add InitialCreate --project MyProject.Infra --startup-project MyProject.Api

# Update database
dotnet ef database update --project MyProject.Infra --startup-project MyProject.Api
```

## Documentation

For detailed CLI configuration and localized docs, check:

* [DotnetBaseKit.Cli/README.md](DotnetBaseKit.Cli/README.md)

* [DotnetBaseKit.Cli/README.ptBr.md](DotnetBaseKit.Cli/README.ptBr.md)