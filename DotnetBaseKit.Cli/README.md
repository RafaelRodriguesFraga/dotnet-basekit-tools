# DotnetBaseKit CLI

DotnetBaseKit CLI is an interactive .NET tool that accelerates the creation of new projects based on the DotnetBaseKit architecture. It guides the user through a simple wizard and generates a ready-to-use layered solution for .NET 8 projects.

It was built as a .NET local tool and works by installing the custom template from the sibling project `DotnetBaseKit.Templates`, then creating a new solution through `dotnet new basekit`.

## Overview

This CLI helps you bootstrap a new application following a Clean Architecture-inspired structure with the following layers:

- API
- Application
- Domain
- Infrastructure
- Shared
- Tests (optional)

It supports multiple database choices and can include a test project automatically.

## Features

- interactive project creation via console prompts
- automatic template installation before generation
- support for:
  - MySQL
  - MongoDB
  - PostgreSQL
  - SQLite
- optional integration of a test project
- ready-to-use .NET 8 solution skeleton
- built with `Spectre.Console` for a cleaner terminal experience

## Prerequisites

Before using the tool, make sure you have:

- .NET 8 SDK installed
- access to the project folder locally
- a terminal or PowerShell/CMD prompt

Check your installation:

```bash
dotnet --version
```

## Installation

From the project folder, package and install the tool locally:

```bash
dotnet pack ./DotnetBaseKit.Cli.csproj -c Release
```

Then install it globally from the generated package directory:

```bash
dotnet tool update --global --add-source ./bin/Release DotnetBaseKit.Cli
```

If the tool is not yet installed, use:

```bash
dotnet tool install --global --add-source ./bin/Release DotnetBaseKit.Cli
```

## Usage

Run the CLI:

```bash
dotnet-basekit
```

The tool will ask you for:

1. the project name
2. the database type
3. whether you want to include a test project

Example flow:

```text
DotnetBaseKit
Interactive Project Generator v1.0.0

Enter project name: (Ex: MyProject): MyCustomerApi
Which Database do you want?
> MySql
Do you want to include a unit test project in the solution? (Y/n)
```

After confirmation, the CLI installs the template and generates the project structure.

## Generated Structure

The tool creates a solution with a structure similar to:

```text
MyProject/
├── MyProject.Api/
├── MyProject.Application/
├── MyProject.Domain/
├── MyProject.Infra/
├── MyProject.Shared/
├── MyProject.Tests/   (optional)
└── MyProject.sln
```

## Supported Database Options

The CLI currently maps the selected database to the template argument:

| Option | Template flag |
|--------|---------------|
| MySql | `sql` |
| MongoDB | `mongodb` |
| PostgreSQL | `postgresql` |
| Sqlite | `sqlite` |
| Default | `none` |

## How it Works Internally

The CLI does the following:

1. displays the welcome banner
2. collects the project configuration through `ConsoleUi`
3. validates the project name
4. calls `ProjectGenerator.EnsureTemplateInstalled()`
5. runs `dotnet new basekit` with the chosen flags
6. shows a success panel with the generated structure

The main logic is implemented in:

- `Program.cs`
- `UI/ConsoleUi.cs`
- `Services/ProjectGenerator.cs`

## Running the Generated Project

After generation, the typical flow is:

```bash
cd MyProject

dotnet restore
dotnet build
dotnet run --project MyProject.Api
```

The API project usually exposes Swagger and will be available in the local development environment when launched.

## Database Migrations

Important: migrations are not created automatically by this CLI. After generating the project, you must create them manually with Entity Framework Core commands, depending on the selected database provider.

Example:

```bash
cd MyProject

dotnet ef migrations add InitialCreate --project MyProject.Infra --startup-project MyProject.Api
```

Then apply them:

```bash
dotnet ef database update --project MyProject.Infra --startup-project MyProject.Api
```

If the project uses a different provider, adjust the command according to the database package and connection configuration. The CLI only scaffolds the solution; database migration generation is the responsibility of the developer.

## Development Notes

This project is intentionally simple and focused on productivity. It acts as a bootstrapper for a larger template repository (`DotnetBaseKit.Templates`), making it easier to generate clean project scaffolds consistently.

## Troubleshooting

### Tool not recognized

If the command is not found, verify that the global tool is installed correctly:

```bash
dotnet tool list --global
```

### Template not found

If generation fails, the CLI tries to reinstall the template automatically. You can also run manually:

```bash
dotnet new install "C:\path\to\DotnetBaseKit.Templates\bin\Release" --force
```

### Project creation failed

The CLI captures the error output from the template command and displays it in the terminal. That output is often enough to identify the missing dependency or invalid template configuration.

## License

This project is intended for internal and personal project scaffolding. Check the repository policy or source control settings for licensing details before commercial use.

## Contributing

Contributions are welcome. If you want to improve the CLI, the template behavior, or the generated architecture, open an issue or submit a pull request with the relevant changes.
