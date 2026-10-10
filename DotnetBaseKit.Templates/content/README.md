# ðŸ§± DotnetBaseKit

> Base project with layered architecture for .NET 8 applications, ready to scale for both monoliths and microservices.

[ðŸ‡§ðŸ‡· Brazilian Portuguese Version](./README.ptBr.md) 

This repository serves as a reusable template for .NET applications, with layered separation following Clean Architecture best practices.

---

## ðŸ“ Project Structure

```plaintext
â”œâ”€â”€ DotnetBaseKit.Api/                # Presentation layer
â”œâ”€â”€ DotnetBaseKit.Application/        # Use cases, interfaces, DTOs
â”œâ”€â”€ DotnetBaseKit.Domain/             # Business entities and rules
â”œâ”€â”€ DotnetBaseKit.Infra/              # Infrastructure (implementations)
â”œâ”€â”€ DotnetBaseKit.Infra.Shared/       # Common utilities and contracts  
â”œâ”€â”€ DotnetBaseKit.Infra.Tests/        # Automated tests (xUnit)
```

--- 


## ðŸ”§ How to use

1. Click `Use this template` at the top right
2. Rename your repository
3. Clone:

```bash

git clone https://github.com/your-username/your-new-repo.git
```

4. Run:

```bash

cd DotnetBaseKit.Api
dotnet run
```

Or simply clone the repository:

```bash

git clone https://github.com/RafaelRodriguesFraga/DotnetBaseKit.git
```

Access at:
ðŸ“ http://localhost:5101/swagger

<br>

##### Made with â¤ï¸ by Rafael Fraga
