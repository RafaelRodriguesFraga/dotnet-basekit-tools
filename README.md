# DotnetBaseKit

DotnetBaseKit is a lightweight project generator and template ecosystem for creating .NET 8 applications with a layered architecture inspired by Clean Architecture.

This repository contains:

- `DotnetBaseKit.Cli` — interactive command-line tool that creates new solutions from a template
- `DotnetBaseKit.Templates` — reusable project template used by the CLI to scaffold the generated application

## Project structure

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

## Main purpose

The goal is to help developers quickly create new .NET applications with a consistent structure, reducing boilerplate and standardizing:

- API layer
- Application layer
- Domain layer
- Infrastructure layer
- Shared layer
- optional tests project
- database configuration

## CLI usage

Install the tool locally from the project output:

```bash
dotnet tool update --global --add-source ./DotnetBaseKit.Cli/bin/Release DotnetBaseKit.Cli
```

Then run:

```bash
dotnet-basekit
```

The CLI asks for:

- project name
- database type
- whether to include tests

It then installs the template and generates a base solution for the chosen architecture.

## Important note about migrations

The CLI creates the project structure, but it does not generate database migrations automatically. You must create them manually with EF Core commands after the project is generated.

Example:

```bash
dotnet ef migrations add InitialCreate --project YourProject.Infra --startup-project YourProject.Api
dotnet ef database update --project YourProject.Infra --startup-project YourProject.Api
```

## Documentation

Detailed documentation for the CLI is available here:

- [DotnetBaseKit.Cli/README.md](DotnetBaseKit.Cli/README.md)
- [DotnetBaseKit.Cli/README.ptBr.md](DotnetBaseKit.Cli/README.ptBr.md)

## Typical generated application structure

```text
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

## License

This project is intended for development and project scaffolding workflows. Check the repository license if you plan to use it in production or distribute it commercially.
